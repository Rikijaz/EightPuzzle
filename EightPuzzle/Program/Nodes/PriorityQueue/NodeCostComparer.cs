#region

using System.Collections.Generic;

#endregion

namespace EightPuzzle.Program.Nodes.PriorityQueue
{
	public class NodeCostComparer : IComparer<uint>
	{
		public int Compare(uint costA, uint costB) => (int) costA - (int) costB;
	}
}