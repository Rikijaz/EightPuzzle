#region

using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program.QueueingStrategy
{
	public class MisplacedTileQueuingStrategy : QueuingStrategy
	{
		public static readonly MisplacedTileQueuingStrategy Instance = new MisplacedTileQueuingStrategy();

		private MisplacedTileQueuingStrategy()
		{
		}

		public override uint CalculateCurrentCost(
			ITileGridState gridState,
			ITileGridState finalGridState)
		{
			uint cost = 0;

			for (int x = 0; x < gridState.GridDimension; x++)
			{
				for (int y = 0; y < gridState.GridDimension; y++)
				{
					TilePosition tilePosition = new TilePosition(x, y);

					if (gridState[tilePosition] != finalGridState[tilePosition])
					{
						cost++;
					}
				}
			}

			return cost;
		}
	}
}