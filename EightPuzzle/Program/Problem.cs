#region

using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program
{
	public class Problem
	{
		public Problem(ITileGridState initialGridState, ITileGridState finalGridState)
		{
			InitialGridState = initialGridState;
			FinalGridState = finalGridState;
		}

		public ITileGridState InitialGridState { get; }

		private ITileGridState FinalGridState { get; }

		public bool IsPuzzleSolved(ITileGridState tileGridState)
		{
			for (int x = 0; x < tileGridState.GridLength; x++)
			{
				for (int y = 0; y < tileGridState.GridLength; y++)
				{
					TilePosition tilePosition = new TilePosition(x, y);

					if (tileGridState[tilePosition] != FinalGridState[tilePosition])
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}