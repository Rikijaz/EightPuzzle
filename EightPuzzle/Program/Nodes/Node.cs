#region

using EightPuzzle.Program.Tiles;
using EightPuzzle.Program.Utility;

#endregion

namespace EightPuzzle.Program.Nodes
{
	/**
	 * Contains tiles information and provides read and write operations.
	 */
	public class Node : INodeHeuristicProvider
	{
		public Node(in TileGrid tileGrid, in TilePosition emptyTilePosition, uint cost)
		{
			TileGrid = tileGrid;
			EmptyTilePosition = emptyTilePosition;
			Cost = cost;
		}

		private TileGrid TileGrid { get; }

		private TilePosition EmptyTilePosition { get; set; }

		public uint Cost { get; set; }

		public ITileGridState TileGridState
		{
			get { return TileGrid; }
		}

		public bool MoveLeft()
		{
			int newEmptyTileXCoordinate = EmptyTilePosition.X - 1;

			TilePosition newEmptyTilePosition = new TilePosition(
				newEmptyTileXCoordinate,
				EmptyTilePosition.Y);

			if (!ProcessMovement(newEmptyTileXCoordinate, newEmptyTilePosition))
			{
				return false;
			}

			LogUtility.Log("Moving left", LogLevel.Trace);

			return true;
		}

		public bool MoveRight()
		{
			int newEmptyTileXCoordinate = EmptyTilePosition.X + 1;

			TilePosition newEmptyTilePosition = new TilePosition(
				newEmptyTileXCoordinate,
				EmptyTilePosition.Y);

			if (!ProcessMovement(newEmptyTileXCoordinate, newEmptyTilePosition))
			{
				return false;
			}

			LogUtility.Log("Moving right", LogLevel.Trace);

			return true;
		}

		public bool MoveUp()
		{
			int newEmptyTileYCoordinate = EmptyTilePosition.Y - 1;

			TilePosition newEmptyTilePosition = new TilePosition(
				EmptyTilePosition.X,
				newEmptyTileYCoordinate);

			if (!ProcessMovement(newEmptyTileYCoordinate, newEmptyTilePosition))
			{
				return false;
			}

			LogUtility.Log("Moving up", LogLevel.Trace);

			return true;
		}

		public bool MoveDown()
		{
			int newEmptyTileYCoordinate = EmptyTilePosition.Y + 1;

			TilePosition newEmptyTilePosition = new TilePosition(
				EmptyTilePosition.X,
				newEmptyTileYCoordinate);

			if (!ProcessMovement(newEmptyTileYCoordinate, newEmptyTilePosition))
			{
				return false;
			}

			LogUtility.Log("Moving down", LogLevel.Trace);

			return true;
		}

		public Node DeepClone() => new Node(TileGrid.DeepClone(), EmptyTilePosition, Cost);

		private bool ProcessMovement(int changedCoordinate, TilePosition newEmptyTilePosition)
		{
			if (!TileGrid.IsValidCoordinate(changedCoordinate))
			{
				LogUtility.Log(
					$"{EmptyTilePosition} to {newEmptyTilePosition} is an invalid move",
					LogLevel.Trace);

				return false;
			}

			TileGrid.Swap(EmptyTilePosition, newEmptyTilePosition);
			EmptyTilePosition = newEmptyTilePosition;

			return true;
		}
	}
}