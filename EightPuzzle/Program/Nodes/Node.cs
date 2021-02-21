#region

using System.Collections.Generic;
using EightPuzzle.Program.Logging;
using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program.Nodes
{
	/**
	 * Contains tiles information and provides read and write operations.
	 */
	public class Node : INodeHeuristicProvider
	{
		public Node(
			in TileGrid tileGrid,
			in TilePosition emptyTilePosition,
			TileGridState parentTileGridState)
		{
			TileGrid = tileGrid;
			EmptyTilePosition = emptyTilePosition;
			ParentTileGridState = parentTileGridState;
			TilePositionHistory = new HashSet<TilePosition>();
		}

		private Node(
			in TileGrid tileGrid,
			in TilePosition emptyTilePosition,
			HashSet<TilePosition> tilePositionHistory,
			TileGridState parentTileGridState,
			uint depth)
		{
			TileGrid = tileGrid;
			EmptyTilePosition = emptyTilePosition;
			TilePositionHistory = tilePositionHistory;
			ParentTileGridState = parentTileGridState;
			Depth = depth;
		}

		public uint Depth { get; set; }

		public uint Id { get; set; }

		private HashSet<TilePosition> TilePositionHistory { get; }

		public TileGridState ParentTileGridState { get; }

		private TileGrid TileGrid { get; }

		public uint Cost { get; set; }

		public TilePosition EmptyTilePosition { get; private set; }

		public TileGridState TileGridState
		{
			get { return TileGrid; }
		}

		public bool MoveEmptyTileLeft()
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

		public bool MoveEmptyTileRight()
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

		public bool MoveEmptyTileUp()
		{
			int newEmptyTileYCoordinate = EmptyTilePosition.Y + 1;

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

		public bool MoveEmptyTileDown()
		{
			int newEmptyTileYCoordinate = EmptyTilePosition.Y - 1;

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

		public Node DeepClone(TileGridState parentTileGridState) =>
			new Node(
				TileGrid.DeepClone(),
				EmptyTilePosition,
				TilePositionHistory,
				parentTileGridState,
				Depth);

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