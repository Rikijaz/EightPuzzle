#region

using System.Text;

#endregion

namespace EightPuzzle.Program.Problem
{
	public readonly struct SolutionAnalysis
	{
		public SolutionAnalysis(bool isSolved, uint depth, uint expandedNodes, uint maxQueueSize)
		{
			IsSolved = isSolved;
			Depth = depth;
			ExpandedNodes = expandedNodes;
			MaxQueueSize = maxQueueSize;
		}

		public bool IsSolved { get; }

		public uint Depth { get; }

		public uint ExpandedNodes { get; }

		public uint MaxQueueSize { get; }

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.AppendLine($"Solved: {IsSolved}");
			stringBuilder.AppendLine($"Depth: {Depth}");
			stringBuilder.AppendLine($"Expanded Nodes Count: {ExpandedNodes}");
			stringBuilder.AppendLine($"Max Queue Size: {MaxQueueSize}");

			return stringBuilder.ToString();
		}
	}
}