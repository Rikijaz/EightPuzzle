#region

using EightPuzzle.Program.Nodes;
using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program.QueueingStrategy
{
	public class ManhattanDistanceQueuingStrategy : QueuingStrategy
	{
		public static readonly ManhattanDistanceQueuingStrategy Instance =
			new ManhattanDistanceQueuingStrategy();

		private ManhattanDistanceQueuingStrategy()
		{
		}

		public override uint CalculateCurrentCost(
			INodeHeuristicProvider nodeHeuristicProvider,
			Solution solution)
		{
			uint currentCost = 0;

			ITileGridState tileGridState = nodeHeuristicProvider.TileGridState;

			for (int x = 0; x < tileGridState.GridDimension; x++)
			{
				for (int y = 0; y < tileGridState.GridDimension; y++)
				{
					TilePosition tilePosition = new TilePosition(x, y);

					if (tileGridState[tilePosition] != solution.GridState[tilePosition])
					{
						currentCost++;
					}
				}
			}

			return currentCost;
		}
	}
}