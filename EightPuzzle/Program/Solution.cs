#region

using System.Collections.Generic;
using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program
{
	public class Solution
	{
		public Solution(
			ITileGridState gridState,
			IReadOnlyDictionary<Tile, TilePosition> tilePositionsByTile)
		{
			GridState = gridState;
			TilePositionsByTile = tilePositionsByTile;
		}

		public ITileGridState GridState { get; }

		public TilePosition GetTilePosition(Tile tile) => TilePositionsByTile[tile];

		private IReadOnlyDictionary<Tile, TilePosition> TilePositionsByTile { get; }
	}
}