#region

using EightPuzzle.Program.Nodes;
using EightPuzzle.Program.Tiles;
using EightPuzzle.Program.Utility;

#endregion

namespace EightPuzzle.Program
{
	internal static class Program
	{
		private const uint PuzzleLength = 8;

		public static void Main(string[] args)
		{
			uint[,] inputs = new uint[PuzzleLength, PuzzleLength];

			uint value = 0;

			for (int y = 0; y < PuzzleLength; y++)
			{
				for (int x = 0; x < PuzzleLength; x++)
				{
					inputs[x, y] = value;
					value++;
				}
			}

			TileGrid tileGrid = TileGridUtility.CreateInstance(inputs, PuzzleLength);

			Node node = new Node(tileGrid, new TilePosition(0, 0));
			LogUtility.Log(tileGrid.ToString(), LogLevel.Trace);

			node.MoveUp();

			LogUtility.Log(tileGrid.ToString(), LogLevel.Trace);

			node.MoveDown();

			LogUtility.Log(tileGrid.ToString(), LogLevel.Trace);

			node.MoveRight();

			LogUtility.Log(tileGrid.ToString(), LogLevel.Trace);

			node.MoveLeft();

			LogUtility.Log(tileGrid.ToString(), LogLevel.Trace);

			node.MoveLeft();

			LogUtility.Log(tileGrid.ToString(), LogLevel.Trace);
		}
	}
}