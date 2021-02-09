#region

using EightPuzzle.Program.Tiles;
using EightPuzzle.Program.Utility;

#endregion

namespace EightPuzzle.Program
{
	public class Problem
	{
		public Problem(
			TileGrid initialGrid,
			Solution solution)
		{
			InitialGrid = initialGrid;
			Solution = solution;
		}

		public TileGrid InitialGrid { get; }

		public Solution Solution { get; }

		public bool Solve(ITileGridState tileGridState)
		{
			for (int x = 0; x < tileGridState.GridDimension; x++)
			{
				for (int y = 0; y < tileGridState.GridDimension; y++)
				{
					TilePosition tilePosition = new TilePosition(x, y);

					Tile tile = tileGridState[tilePosition];

					Tile answerTile = Solution.GridState[tilePosition];

					if (tile == answerTile)
					{
						continue;
					}

					LogUtility.Log(
						$"Puzzle is not solved. The value at {tilePosition} should be {answerTile}, not {tile}.",
						LogLevel.Trace);

					return false;
				}
			}

			return true;
		}
	}
}