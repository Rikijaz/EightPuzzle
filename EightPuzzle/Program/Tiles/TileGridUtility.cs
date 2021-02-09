#region

using System;

#endregion

namespace EightPuzzle.Program.Tiles
{
	public static class TileGridUtility
	{
		private const uint EmptyTileValue = 0;

		public static TileGrid CreateInstance(uint[,] inputs, uint gridLength)
		{
			Tile[,] tiles =
				new Tile[gridLength, gridLength];

			for (uint x = 0; x < gridLength; x++)
			{
				for (uint y = 0; y < gridLength; y++)
				{
					tiles[x, y] = new Tile(inputs[x, y]);
				}
			}

			return new TileGrid(tiles, gridLength);
		}

		public static uint[,] CreateInputCollection(uint puzzleSize)
		{
			uint gridLength = (uint) Math.Ceiling(Math.Sqrt(puzzleSize));

			uint[,] inputCollection = new uint[gridLength, gridLength];

			for (uint y = 0; y < gridLength; y++)
			{
				for (int x = 0; x < gridLength; x++)
				{
					inputCollection[y, x] = EmptyTileValue;
				}
			}

			return inputCollection;
		}
	}
}