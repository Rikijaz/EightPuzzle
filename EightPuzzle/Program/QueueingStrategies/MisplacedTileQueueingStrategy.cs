#region

using EightPuzzle.Program.Nodes;
using EightPuzzle.Program.Problem;
using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program.QueueingStrategies
{
	public class MisplacedTileQueueingStrategy : QueueingStrategy
	{
		public static readonly MisplacedTileQueueingStrategy Instance =
			new MisplacedTileQueueingStrategy();

		private MisplacedTileQueueingStrategy() : base(QueueingStrategyType.MisplacedTile)
		{
		}

		public override uint CalculateCurrentCost(
			INodeHeuristicProvider nodeHeuristicProvider,
			Solution solution)
		{
			uint misplacedTileCount = 0;

			TileGridState tileGridState = nodeHeuristicProvider.TileGridState;

			for (int x = 0; x < tileGridState.GridDimension; x++)
			{
				for (int y = 0; y < tileGridState.GridDimension; y++)
				{
					TilePosition tilePosition = new TilePosition(x, y);

					if ((tileGridState[tilePosition] != solution.GridState[tilePosition]) &&
						(nodeHeuristicProvider.EmptyTilePosition != tilePosition))
					{
						misplacedTileCount++;
					}
				}
			}

			return misplacedTileCount;
		}
	}
}