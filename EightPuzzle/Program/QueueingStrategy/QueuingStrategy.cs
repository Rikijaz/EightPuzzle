#region

using System.Collections.Generic;
using EightPuzzle.Program.Nodes;
using EightPuzzle.Program.Nodes.PriorityQueue;
using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program.QueueingStrategy
{
	public abstract class QueuingStrategy
	{
		public NodePriorityQueue CreateNodes(
			NodePriorityQueue nodePriorityQueue,
			List<Node> expandedNodes,
			ITileGridState finalGridState)
		{
			for (int i = 0; i < expandedNodes.Count; i++)
			{
				Node newNode = expandedNodes[i];
				newNode.CurrentCost = CalculateCurrentCost(newNode.TileGridState, finalGridState);
				nodePriorityQueue.Enqueue(newNode);
			}

			return nodePriorityQueue;
		}

		public abstract uint CalculateCurrentCost(
			ITileGridState gridState,
			ITileGridState finalGridState);
	}
}