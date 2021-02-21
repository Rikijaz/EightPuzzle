#region

using System.Collections.Generic;
using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program.Problem
{
	public class Solution
	{
		public Solution(
			TileGridState gridState,
			IReadOnlyDictionary<Tile, TilePosition> startTilePositionsByTile,
			IReadOnlyDictionary<Tile, TilePosition> finalTilePositionsByTile)
		{
			GridState = gridState;
			StartTilePositionsByTile = startTilePositionsByTile;
			FinalTilePositionsByTile = finalTilePositionsByTile;
		}

		public TileGridState GridState { get; }

		public IReadOnlyDictionary<Tile, TilePosition> StartTilePositionsByTile { get; }

		public IReadOnlyDictionary<Tile, TilePosition> FinalTilePositionsByTile { get; }

		public TilePosition GetFinalTilePosition(Tile tile) => FinalTilePositionsByTile[tile];

		public TilePosition GetStartTilePosition(Tile tile) => StartTilePositionsByTile[tile];
	}
}