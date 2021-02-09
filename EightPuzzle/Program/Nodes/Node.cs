#region

using EightPuzzle.Program.Tiles;
using EightPuzzle.Program.Utility;

#endregion

namespace EightPuzzle.Program.Nodes
{
	/**
	 * Contains tiles information and provides read and write operations.
	 */
	public class Node : INodeState,
		INodeController
	{
		public Node(in TileGrid tileGrid, in TilePosition emptyTilePosition)
		{
			TileGrid = tileGrid;
			EmptyTilePosition = emptyTilePosition;
		}

		private TileGrid TileGrid { get; }

		private TilePosition EmptyTilePosition { get; }

		public bool MoveLeft()
		{
			int newEmptyTileXPosition = EmptyTilePosition.X - 1;

			TilePosition newEmptyTilePosition = new TilePosition(
				newEmptyTileXPosition,
				EmptyTilePosition.Y);

			if (!TileGrid.IsValidCoordinate(newEmptyTileXPosition))
			{
				LogInvalidMove(newEmptyTilePosition);

				return false;
			}

			TileGrid.Swap(EmptyTilePosition, newEmptyTilePosition);
			LogUtility.Log("Moving left", LogLevel.Trace);

			return true;
		}

		public bool MoveRight()
		{
			int newEmptyTileXPosition = EmptyTilePosition.X + 1;

			TilePosition newEmptyTilePosition = new TilePosition(
				newEmptyTileXPosition,
				EmptyTilePosition.Y);

			if (!TileGrid.IsValidCoordinate(newEmptyTileXPosition))
			{
				LogInvalidMove(newEmptyTilePosition);

				return false;
			}

			TileGrid.Swap(EmptyTilePosition, newEmptyTilePosition);
			LogUtility.Log("Moving right", LogLevel.Trace);

			return true;
		}

		public bool MoveUp()
		{
			int newEmptyTileYPosition = EmptyTilePosition.Y + 1;

			TilePosition newEmptyTilePosition = new TilePosition(
				EmptyTilePosition.X,
				newEmptyTileYPosition);

			if (!TileGrid.IsValidCoordinate(newEmptyTileYPosition))
			{
				LogInvalidMove(newEmptyTilePosition);

				return false;
			}

			TileGrid.Swap(EmptyTilePosition, newEmptyTilePosition);
			LogUtility.Log("Moving up", LogLevel.Trace);

			return true;
		}

		public bool MoveDown()
		{
			int newEmptyTileYPosition = EmptyTilePosition.Y - 1;

			TilePosition newEmptyTilePosition = new TilePosition(
				EmptyTilePosition.X,
				newEmptyTileYPosition);

			if (!TileGrid.IsValidCoordinate(newEmptyTileYPosition))
			{
				LogInvalidMove(newEmptyTilePosition);

				return false;
			}

			TileGrid.Swap(EmptyTilePosition, newEmptyTilePosition);

			LogUtility.Log("Moving down", LogLevel.Trace);

			return true;
		}

		public ITileGridState TileGridState
		{
			get { return TileGrid; }
		}

		private void LogInvalidMove(in TilePosition newEmptyTilePosition) =>
			LogUtility.Log(
				$"{EmptyTilePosition} to {newEmptyTilePosition} is an invalid move",
				LogLevel.Trace);
	}
}