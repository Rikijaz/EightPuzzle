#region

using System.Collections.Generic;
using EightPuzzle.Program.Logging;
using EightPuzzle.Program.Nodes;
using EightPuzzle.Program.Nodes.PriorityQueue;
using EightPuzzle.Program.QueueingStrategies;
using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program.Problem
{
	public static class Solver
	{
		public static SolutionAnalysis GeneralSearch(
			Problem problem,
			QueueingStrategy queueingStrategy)
		{
			NodePriorityQueue nodePriorityQueue = CreateInitialNodes(
				problem.InitialGrid,
				queueingStrategy,
				problem.Solution);

			uint iterationCount = 0;

			while (nodePriorityQueue.Count > 0)
			{
				LogUtility.Log($"Iteration {iterationCount}", LogLevel.Debug);
				LogUtility.Log($"Current Queue:\n {nodePriorityQueue}", LogLevel.Trace);

				Node node = nodePriorityQueue.Dequeue();
				LogUtility.Log("Best state to expand", LogLevel.Info);
				LogUtility.Log($"g(n) = {node.Depth}", LogLevel.Info);
				LogUtility.Log($"h(n) = {node.Cost}", LogLevel.Info);
				LogUtility.Log(node.TileGridState, LogLevel.Info);

				if (problem.Solve(node.TileGridState))
				{
					return new SolutionAnalysis(
						true,
						nodePriorityQueue.Depth,
						nodePriorityQueue.NodeIdCounter,
						nodePriorityQueue.HighestCount);
				}

				List<Node> expandedNodes = ExpandNodes(node);

				nodePriorityQueue = queueingStrategy.ProcessNodes(
					nodePriorityQueue,
					expandedNodes,
					problem.Solution);

				iterationCount++;
			}

			return new SolutionAnalysis(
				false,
				nodePriorityQueue.Depth,
				nodePriorityQueue.NodeIdCounter,
				nodePriorityQueue.HighestCount);
		}

		private static NodePriorityQueue CreateInitialNodes(
			TileGrid problemInitialGrid,
			QueueingStrategy queueingStrategy,
			Solution solution)
		{
			if (!TileGridUtility.TryFindEmptyTilePosition(
				problemInitialGrid,
				out TilePosition emptyTilePosition))
			{
				LogUtility.Log("Problem does not contain an empty tile", LogLevel.Error);
			}

			Node baseNode = new Node(problemInitialGrid, emptyTilePosition, problemInitialGrid);

			uint baseCost = queueingStrategy.CalculateCurrentCost(
				baseNode,
				solution);

			baseNode.Cost = baseCost;
			baseNode.Depth = 0;

			return NodePriorityQueueBuilder.CreateInstance(baseNode);
		}

		private static List<Node> ExpandNodes(Node baseNode)
		{
			LogUtility.Log(
				$"Expanding state with ID {baseNode.Id} with cost {baseNode.Cost} :\n{baseNode.TileGridState}",
				LogLevel.Debug);

			List<Node> expandedNodes = new List<Node>();

			Node baseNodeClone = baseNode.DeepClone(baseNode.TileGridState);

			if (baseNodeClone.MoveEmptyTileDown())
			{
				baseNodeClone = ProcessNodeExpansion(baseNode, baseNodeClone, expandedNodes);
			}

			if (baseNodeClone.MoveEmptyTileLeft())
			{
				baseNodeClone = ProcessNodeExpansion(baseNode, baseNodeClone, expandedNodes);
			}

			if (baseNodeClone.MoveEmptyTileRight())
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
			if (baseNodeClone.TileGridState == baseNode.ParentTileGridState)
			{
				return baseNode.DeepClone(baseNode.TileGridState);
			}

			baseNodeClone.Depth++;
			expandedNodes.Add(baseNodeClone);

			return baseNode.DeepClone(baseNode.TileGridState);
		}
	}
}