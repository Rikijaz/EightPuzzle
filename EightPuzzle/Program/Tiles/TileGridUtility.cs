namespace EightPuzzle.Program.Tiles
{
	public static class TileGridUtility
	{
		private const uint EmptyTileValue = 0;

		public static TileGrid CreateInputInstance(uint[,] inputs, uint gridDimension)
		{
			Tile[,] tiles = new Tile[gridDimension, gridDimension];

			for (uint y = 0; y < gridDimension; y++)
			{
				for (uint x = 0; x < gridDimension; x++)
				{
					tiles[y, x] = new Tile(inputs[y, x]);
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

					Tile tile = tileGridState[tilePosition];

					if (tileGridState[tilePosition].Value == EmptyTileValue)
					{
						return true;
					}
				}
			}

			tilePosition = default;

			return false;
		}

		public static ITileGridState CreateAnswerInstance(uint gridDimension)
		{
			Tile[,] tiles = new Tile[gridDimension, gridDimension];

			uint value = 1;

			for (uint y = 0; y < gridDimension; y++)
			{
				for (uint x = 0; x < gridDimension; x++)
				{
					if (value == tiles.Length)
					{
						tiles[x, y] = new Tile(EmptyTileValue);
					}
					else
					{
						tiles[x, y] = new Tile(value);
						value++;
					}
				}
			}

			return new TileGrid(tiles, gridDimension);
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