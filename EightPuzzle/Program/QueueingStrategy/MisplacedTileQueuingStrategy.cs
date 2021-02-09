﻿#region

using EightPuzzle.Program.Nodes;
using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program.QueueingStrategy
{
	public class MisplacedTileQueuingStrategy : QueuingStrategy
	{
		public static readonly MisplacedTileQueuingStrategy Instance =
			new MisplacedTileQueuingStrategy();

		private MisplacedTileQueuingStrategy()
		{
		}

		public override uint CalculateCurrentCost(
			INodeHeuristicProvider nodeHeuristicProvider,
			Solution solution)
		{
			uint misplacedTileCount = 0;

			ITileGridState tileGridState = nodeHeuristicProvider.TileGridState;

			for (int x = 0; x < tileGridState.GridDimension; x++)
			{
				for (int y = 0; y < tileGridState.GridDimension; y++)
				{
					TilePosition tilePosition = new TilePosition(x, y);

					if ((tileGridState[tilePosition] != solution.GridState[tilePosition]) &&
						(nodeHeuristicProvider.EmptyTilePosition != tilePosition))
					{
						misplacedTileCount++;
					}
				}
			}

			return misplacedTileCount;
		}
	}
}