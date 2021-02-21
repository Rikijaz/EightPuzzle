#region

using EightPuzzle.Program.Nodes;
using EightPuzzle.Program.Problem;

#endregion

namespace EightPuzzle.Program.QueueingStrategies
{
	public class UniformedSearchQueueingStrategy : QueueingStrategy
	{
		public static readonly UniformedSearchQueueingStrategy Instance =
			new UniformedSearchQueueingStrategy();

		private UniformedSearchQueueingStrategy() : base(QueueingStrategyType.UniformedSearch)
		{
		}

		public override uint CalculateCurrentCost(
			INodeHeuristicProvider nodeHeuristicProvider,
			Solution solution) =>
			0;
	}
}