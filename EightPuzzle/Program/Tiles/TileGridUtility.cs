#region

using System.Collections.Generic;

#endregion

namespace EightPuzzle.Program.Tiles
{
	public static class TileGridUtility
	{
		private const uint EmptyTileValue = 0;

		public static TileGrid CreateInputInstance(uint[,] inputs, uint gridDimension)
		{
			Tile[,] tiles = new Tile[gridDimension, gridDimension];

			for (uint column = 0; column < gridDimension; column++)
			{
				for (uint row = 0; row < gridDimension; row++)
				{
					tiles[row, column] = new Tile(inputs[column, row]);
				}
			}

			return new TileGrid(tiles, gridDimension);
		}

		public static bool TryFindEmptyTilePosition(
			ITileGridState tileGridState,
			out TilePosition tilePosition)
		{
			for (int x = 0; x < tileGridState.GridDimension; x++)
			{
				for (int y = 0; y < tileGridState.GridDimension; y++)
				{
					tilePosition = new TilePosition(x, y);

					if (tileGridState[tilePosition].Value == EmptyTileValue)
					{
						return true;
					}
				}
			}

			tilePosition = default;

			return false;
		}

		public static Solution CreateAnswerInstance(uint gridDimension)
		{
			Tile[,] tiles = new Tile[gridDimension, gridDimension];

			Dictionary<Tile, TilePosition> tilePositionsByTile =
				new Dictionary<Tile, TilePosition>(tiles.Length);

			uint value = 1;

			for (int column = 0; column < gridDimension; column++)
			{
				for (int row = 0; row < gridDimension; row++)
				{
					if (value == tiles.Length)
					{
						tiles[row, column] = new Tile(EmptyTileValue);
					}
					else
					{
						tiles[row, column] = new Tile(value);
					}

					TilePosition tilePosition = new TilePosition(row, column);
					tilePositionsByTile.Add(tiles[row, column], tilePosition);
					value++;
				}
			}

			TileGrid tileGrid = new TileGrid(tiles, gridDimension);

			return new Solution(tileGrid, tilePositionsByTile);
		}

		public static TileGrid DeepClone(uint gridDimension)
		{
			Tile[,] tiles = new Tile[gridDimension, gridDimension];

			uint value = 1;

			for (uint y = 0; y < gridDimension; y++)
			{
				for (uint x = 0; x < gridDimension; x++)
				{
					if (value == tiles.Length)
					{
						tiles[y, x] = new Tile(EmptyTileValue);
					}
					else
					{
						tiles[y, x] = new Tile(value);
						value++;
					}
				}
			}

			return new TileGrid(tiles, gridDimension);
		}

		public static uint[,] CreateInputCollection(uint gridDimension)
		{
			uint[,] inputCollection = new uint[gridDimension, gridDimension];

			for (uint y = 0; y < gridDimension; y++)
			{
				for (int x = 0; x < gridDimension; x++)
				{
					inputCollection[y, x] = EmptyTileValue;
				}
			}

			return inputCollection;
		}
	}
}