#region

using System.Collections.Generic;

#endregion

namespace EightPuzzle.Grid
{
	public class Grid : IGridReader,
		IGridController
	{
		public Grid(Tile[][] tiles, int emptyTileXPosition, int emptyTileYPosition, uint tileLength)
		{
			Tiles = tiles;
			EmptyTileXPosition = emptyTileXPosition;
			EmptyTileYPosition = emptyTileYPosition;
			TileLength = tileLength;
		}

		private Tile[][] Tiles { get; }

		private uint TileLength { get; }

		private int EmptyTileXPosition { get; set; }

		private int EmptyTileYPosition { get; set; }

		public bool MoveLeft()
		{
			int newEmptyTileXPosition = EmptyTileXPosition - 1;

			if (!IsPositionValid(newEmptyTileXPosition))
			{
				return false;
			}

			EmptyTileXPosition = newEmptyTileXPosition;

			return true;
		}

		public bool MoveRight()
		{
			int newEmptyTileXPosition = EmptyTileXPosition + 1;

			if (!IsPositionValid(newEmptyTileXPosition))
			{
				return false;
			}

			EmptyTileXPosition = newEmptyTileXPosition;

			return true;
		}

		public bool MoveUp()
		{
			int newEmptyTileYPosition = EmptyTileYPosition + 1;

			if (!IsPositionValid(newEmptyTileYPosition))
			{
				return false;
			}

			EmptyTileYPosition = newEmptyTileYPosition;

			return true;
		}

		public bool MoveDown()
		{
			int newEmptyTileYPosition = EmptyTileYPosition - 1;

			if (!IsPositionValid(newEmptyTileYPosition))
			{
				return false;
			}

			EmptyTileYPosition = newEmptyTileYPosition;

			return true;
		}

		IReadOnlyList<IReadOnlyList<Tile>> IGridReader.Tiles
		{
			get { return Tiles; }
		}

		private bool IsPositionValid(int position) => (position >= 0) && (position < TileLength);
	}
}