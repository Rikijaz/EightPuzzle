#region

using System.Collections.Generic;
using EightPuzzle.Program.Logging;
using EightPuzzle.Program.Nodes;
using EightPuzzle.Program.Nodes.PriorityQueue;
using EightPuzzle.Program.Problem;

#endregion

namespace EightPuzzle.Program.QueueingStrategies
{
	public abstract class QueueingStrategy
	{
		protected QueueingStrategy(QueueingStrategyType queueingStrategyType)
		{
			QueueingStrategyType = queueingStrategyType;
		}

		private QueueingStrategyType QueueingStrategyType { get; }

		public override string ToString() => QueueingStrategyType.ToString();

		public NodePriorityQueue ProcessNodes(
			NodePriorityQueue nodePriorityQueue,
			List<Node> expandedNodes,
			Solution solution)
		{
			for (int i = 0; i < expandedNodes.Count; i++)
			{
				Node expandedNode = expandedNodes[i];

				expandedNode.Cost =
					CalculateCurrentCost(expandedNode, solution) + expandedNode.Depth;

				nodePriorityQueue.Enqueue(expandedNode);

				LogUtility.Log(
					$"Expanded state {i} ID: {expandedNode.Id} Depth: {expandedNode.Depth} Cost: {expandedNode.Cost}:\n{expandedNode.TileGridState}",
					LogLevel.Debug);
			}

			return nodePriorityQueue;
		}

		public abstract uint CalculateCurrentCost(
			INodeHeuristicProvider nodeHeuristicProvider,
			Solution solution);
	}
}