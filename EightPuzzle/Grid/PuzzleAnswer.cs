#region

using System.Collections.Generic;

#endregion

namespace EightPuzzle.Grid
{
	public class PuzzleAnswer
	{
		public PuzzleAnswer(IReadOnlyList<IReadOnlyList<Tile>> tiles)
		{
			Tiles = tiles;
		}

		private IReadOnlyList<IReadOnlyList<Tile>> Tiles { get; }

		public bool IsPuzzleSolved(IGridReader gridReader)
		{
			IReadOnlyList<IReadOnlyList<Tile>> gridTiles = gridReader.Tiles;

			for (int x = 0; x < gridTiles.Count; x++)
			{
				IReadOnlyList<Tile> gridTileRow = gridTiles[x];

				for (int y = 0; y < gridTileRow.Count; y++)
				{
					Tile gridTile = gridTileRow[y];

					Tile answerTile = Tiles[x][y];

					if (answerTile != gridTile)
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}