#region

using System;
using EightPuzzle.Program.Nodes;
using EightPuzzle.Program.Tiles;
using EightPuzzle.Program.Utility;

#endregion

namespace EightPuzzle.Program
{
	internal static class Program
	{
		private const uint PuzzleLength = 8;

		private static readonly uint PuzzleGridDimension =
			(uint) Math.Ceiling(Math.Sqrt(PuzzleLength));

		public static void Main(string[] args)
		{
			uint[,] inputs = new uint[PuzzleGridDimension, PuzzleGridDimension];

			uint value = 0;

			for (int y = 0; y < PuzzleGridDimension; y++)
			{
				for (int x = 0; x < PuzzleGridDimension; x++)
				{
					inputs[x, y] = value;
					value++;
				}
			}

			TileGrid initialTileGrid =
				TileGridUtility.CreateInputInstance(inputs, PuzzleGridDimension);

			ITileGridState answerTileGridState =
				TileGridUtility.CreateAnswerInstance(PuzzleGridDimension);

			Problem problem = new Problem(
				initialTileGrid.DeepClone(),
				answerTileGridState);

			Node node = new Node(initialTileGrid, new TilePosition(0, 0), 0);
			LogUtility.Log($"Initial state:\n{initialTileGrid}", LogLevel.Trace);
			LogUtility.Log($"Answer state:\n{answerTileGridState}", LogLevel.Trace);

			node.MoveRight();
			LogUtility.Log(initialTileGrid.ToString(), LogLevel.Trace);
			node.MoveRight();
			LogUtility.Log(initialTileGrid.ToString(), LogLevel.Trace);

			node.MoveDown();
			LogUtility.Log(initialTileGrid.ToString(), LogLevel.Trace);

			node.MoveDown();
			LogUtility.Log(initialTileGrid.ToString(), LogLevel.Trace);
			problem.Solve(node.TileGridState);
		}
	}
}