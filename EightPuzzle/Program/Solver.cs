#region

using System.Collections.Generic;
using EightPuzzle.Program.Nodes;
using EightPuzzle.Program.Tiles;
using EightPuzzle.Program.Utility;

#endregion

namespace EightPuzzle.Program
{
	public class Solver
	{
		public bool GeneralSearch(Problem problem, QueuingStrategy queuingStrategy)
		{
			Queue<Node> nodes = CreateInitialNodes(problem.InitialGrid);

			while (nodes.Count > 0)
			{
				Node node = nodes.Dequeue();

				if (problem.Solve(node.TileGridState))
				{
					return true;
				}

				List<Node> expandedNodes = ExpandNodes(node);
				nodes = queuingStrategy.CreateNodes(nodes, expandedNodes, problem.FinalGridState);
			}

			return false;
		}

		private static Queue<Node> CreateInitialNodes(TileGrid problemInitialGrid)
		{
			if (!TileGridUtility.TryFindEmptyTilePosition(
				problemInitialGrid,
				out TilePosition emptyTilePosition))
			{
				LogUtility.Log("Problem does not contain an empty tile", LogLevel.Error);
			}

			Node[] initialNodes =
			{
				new Node(problemInitialGrid, emptyTilePosition, 0),
			};

			return new Queue<Node>(initialNodes);
		}

		private static List<Node> ExpandNodes(Node node)
		{
			List<Node> expandedNodes = new List<Node>();

			Node expandedNode = node.DeepClone();

			if (expandedNode.MoveLeft())
			{
				expandedNodes.Add(expandedNode);
				expandedNode = node.DeepClone();
			}

			if (expandedNode.MoveRight())
			{
				expandedNodes.Add(expandedNode);
				expandedNode = node.DeepClone();
			}

			if (expandedNode.MoveDown())
			{
				expandedNodes.Add(expandedNode);
				expandedNode = node.DeepClone();
			}

			if (expandedNode.MoveUp())
			{
				expandedNodes.Add(expandedNode);
			}

			return expandedNodes;
		}
	}
}