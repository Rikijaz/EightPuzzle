#region

using System;
using EightPuzzle.Program.Nodes;
using EightPuzzle.Program.Problem;
using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program.QueueingStrategies
{
	public class ManhattanDistanceQueueingStrategy : QueueingStrategy
	{
		public static readonly ManhattanDistanceQueueingStrategy Instance =
			new ManhattanDistanceQueueingStrategy();

		private ManhattanDistanceQueueingStrategy() : base(QueueingStrategyType.ManhattanDistance)
		{
		}

		public override uint CalculateCurrentCost(
			INodeHeuristicProvider nodeHeuristicProvider,
			Solution solution)
		{
			uint totalManhattanDistance = 0;

			TileGridState tileGridState = nodeHeuristicProvider.TileGridState;

			for (int column = 0; column < tileGridState.GridDimension; column++)
			{
				for (int row = 0; row < tileGridState.GridDimension; row++)
				{
					TilePosition tilePosition = new TilePosition(column, row);
					Tile tile = tileGridState[tilePosition];

					if (tile.Value == 0)
					{
						continue;
					}

					TilePosition solutionTilePosition = solution.GetFinalTilePosition(tile);

					totalManhattanDistance += CalculateManhattanDistance(
						tilePosition,
						solutionTilePosition);
				}
			}

			return totalManhattanDistance;
		}

		private static uint CalculateManhattanDistance(
			TilePosition position,
			TilePosition solutionTilePosition)
		{
			if (position == solutionTilePosition)
			{
				return 0;
			}

			long horizontalDistance = Math.Abs(position.X - solutionTilePosition.X);

			long verticalDistance = Math.Abs(position.Y - solutionTilePosition.Y);

			return (uint) (horizontalDistance + verticalDistance);
		}
	}
}