#region

using System.Text;
using EightPuzzle.Program.Utility;

#endregion

namespace EightPuzzle.Program.Tiles
{
	public class TileGrid : ITileGridState
	{
		public TileGrid(Tile[,] tiles, uint gridDimension)
		{
			Tiles = tiles;
			GridDimension = gridDimension;
		}

		public Tile[,] Tiles { get; }

		public Tile this[TilePosition tilePosition]
		{
			get { return Tiles[tilePosition.X, tilePosition.Y]; }
			private set { Tiles[tilePosition.X, tilePosition.Y] = value; }
		}

		public uint GridDimension { get; }

		public bool IsValidCoordinate(int coordinate) =>
			(coordinate >= 0) && (coordinate < GridDimension);

		public void Swap(in TilePosition tilePositionA, in TilePosition tilePositionB)
		{
			LogUtility.Log($"Swapping {tilePositionA} with {tilePositionB}", LogLevel.Trace);

			Tile tileA = this[tilePositionA];
			this[tilePositionA] = this[tilePositionB];
			this[tilePositionB] = tileA;
		}

		public TileGrid DeepClone()
		{
			Tile[,] tiles = new Tile[GridDimension, GridDimension];

			for (uint y = 0; y < GridDimension; ++y)
			{
				for (uint x = 0; x < GridDimension; ++x)
				{
					tiles[x, y] = Tiles[x, y];
				}
			}

			return new TileGrid(tiles, GridDimension);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();

			for (uint y = 0; y < GridDimension; ++y)
			{
				for (uint x = 0; x < GridDimension; ++x)
				{
					stringBuilder.Append(Tiles[x, y] + " ");
				}

				stringBuilder.AppendLine();
			}

			return stringBuilder.ToString();
		}
	}
}