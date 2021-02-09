#region

using System.Collections.Generic;
using EightPuzzle.Program.Nodes;
using EightPuzzle.Program.Nodes.PriorityQueue;
using EightPuzzle.Program.QueueingStrategy;
using EightPuzzle.Program.Tiles;
using EightPuzzle.Program.Utility;

#endregion

namespace EightPuzzle.Program
{
	public static class Solver
	{
		public static bool GeneralSearch(Problem problem, QueuingStrategy queuingStrategy)
		{
			NodePriorityQueue nodePriorityQueue = CreateInitialNodes(
				problem.InitialGrid,
				queuingStrategy,
				problem.Solution);

			while (nodePriorityQueue.Count > 0)
			{
				Node node = nodePriorityQueue.Dequeue();

				if (problem.Solve(node.TileGridState))
				{
					return true;
				}

				List<Node> expandedNodes = ExpandNodes(node);

				nodePriorityQueue = queuingStrategy.CreateNodes(
					nodePriorityQueue,
					expandedNodes,
					problem.Solution);
			}

			return false;
		}

		private static NodePriorityQueue CreateInitialNodes(
			TileGrid problemInitialGrid,
			QueuingStrategy queuingStrategy,
			Solution solution)
		{
			if (!TileGridUtility.TryFindEmptyTilePosition(
				problemInitialGrid,
				out TilePosition emptyTilePosition))
			{
				LogUtility.Log("Problem does not contain an empty tile", LogLevel.Error);
			}

			Node baseNode = new Node(problemInitialGrid, emptyTilePosition);

			uint baseCost = queuingStrategy.CalculateCurrentCost(
				baseNode,
				solution);

			baseNode.StartCost = baseCost;
			baseNode.CurrentCost = 0;

			return NodePriorityQueueBuilder.CreateInstance(baseNode);
		}

		private static List<Node> ExpandNodes(Node baseNode)
		{
			List<Node> expandedNodes = new List<Node>();

			Node baseNodeClone = baseNode.DeepClone();

			if (baseNodeClone.MoveEmptyTileLeft())
			{
				baseNodeClone = ProcessNodeExpansion(baseNode, baseNodeClone, expandedNodes);
			}

			if (baseNodeClone.MoveEmptyTileRight())
			{
				baseNodeClone = ProcessNodeExpansion(baseNode, baseNodeClone, expandedNodes);
			}

			if (baseNodeClone.MoveEmptyTileDown())
			{
				baseNodeClone = ProcessNodeExpansion(baseNode, baseNodeClone, expandedNodes);
			}

			if (baseNodeClone.MoveEmptyTileUp())
			{
				ProcessNodeExpansion(baseNode, baseNodeClone, expandedNodes);
			}

			return expandedNodes;
		}

		private static Node ProcessNodeExpansion(
			Node baseNode,
			Node baseNodeClone,
			ICollection<Node> expandedNodes)
		{
			baseNodeClone.StartCost += baseNodeClone.CurrentCost;
			baseNodeClone.CurrentCost = 0;
			expandedNodes.Add(baseNodeClone);

			return baseNode.DeepClone();
		}
	}
}