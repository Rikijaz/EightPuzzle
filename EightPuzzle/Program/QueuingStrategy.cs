#region

using System.Collections.Generic;
using EightPuzzle.Program.Nodes;
using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program
{
	public abstract class QueuingStrategy
	{
		public Queue<Node> CreateNodes(
			IEnumerable<INodeHeuristicProvider> nodes,
			IEnumerable<INodeHeuristicProvider> expandedNodes,
			ITileGridState finalGridState)
		{
		}

		public abstract void SetHeuristicCost(
			INodeHeuristicProvider node,
			ITileGridState finalGridState);
	}
}