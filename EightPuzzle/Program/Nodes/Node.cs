#region

using System.Collections.Generic;
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
			CurrentCost = cost;
			TilePositionHistory = new HashSet<TilePosition>();
		}

		private HashSet<TilePosition> TilePositionHistory { get; }

		private TileGrid TileGrid { get; }

		private TilePosition EmptyTilePosition { get; set; }

		public uint CurrentCost { get; set; }

		public uint StartCost { get; set; }

		public ITileGridState TileGridState
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

		public bool MoveEmptyTileDown()
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

		public Node DeepClone() => new Node(TileGrid.DeepClone(), EmptyTilePosition, CurrentCost);

		private bool ProcessMovement(int changedCoordinate, TilePosition newEmptyTilePosition)
		{
			if (TilePositionHistory.Contains(newEmptyTilePosition))
			{
				LogUtility.Log($"{newEmptyTilePosition} has already been visited.", LogLevel.Trace);

				return false;
			}

			if (!TileGrid.IsValidCoordinate(changedCoordinate))
			{
				LogUtility.Log(
					$"{EmptyTilePosition} to {newEmptyTilePosition} is an invalid move",
					LogLevel.Trace);

				return false;
			}

			TileGrid.Swap(EmptyTilePosition, newEmptyTilePosition);
			EmptyTilePosition = newEmptyTilePosition;

			TilePositionHistory.Add(EmptyTilePosition);

			return true;
		}
	}
}