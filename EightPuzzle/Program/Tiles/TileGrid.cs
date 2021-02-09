#region

using System.Text;
using EightPuzzle.Program.Utility;

#endregion

namespace EightPuzzle.Program.Tiles
{
	public class TileGrid : ITileGridState
	{
		public TileGrid(Tile[,] tiles, uint gridLength)
		{
			Tiles = tiles;
			GridLength = gridLength;
		}

		public Tile[,] Tiles { get; }

		public Tile this[TilePosition tilePosition]
		{
			get { return Tiles[tilePosition.X, tilePosition.Y]; }
			private set { Tiles[tilePosition.X, tilePosition.Y] = value; }
		}

		public uint GridLength { get; }

		public bool IsValidCoordinate(int coordinate) =>
			(coordinate >= 0) && (coordinate < GridLength);

		public void Swap(in TilePosition tilePositionA, in TilePosition tilePositionB)
		{
			LogUtility.Log($"Swapping {tilePositionA} with {tilePositionB}", LogLevel.Trace);

			Tile tileA = this[tilePositionA];
			this[tilePositionA] = this[tilePositionB];
			this[tilePositionB] = tileA;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();

			for (uint y = 0; y < GridLength; ++y)
			{
				for (uint x = 0; x < GridLength; ++x)
				{
					stringBuilder.Append(Tiles[x, y] + " ");
				}

				stringBuilder.AppendLine();
			}

			return stringBuilder.ToString();
		}
	}
}