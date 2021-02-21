#region

using System;
using System.Collections.Generic;
using EightPuzzle.Program.Problem;
using EightPuzzle.Program.QueueingStrategies;
using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program.Driver
{
	public static class Controller
	{
		private static readonly IReadOnlyDictionary<QueueingStrategyType, QueueingStrategy>
			QueuingStrategiesByType =
				new Dictionary<QueueingStrategyType, QueueingStrategy>
				{
					{
						QueueingStrategyType.UniformedSearch,
						UniformedSearchQueueingStrategy.Instance
					},
					{
						QueueingStrategyType.MisplacedTile, MisplacedTileQueueingStrategy.Instance
					},
					{
						QueueingStrategyType.ManhattanDistance,
						ManhattanDistanceQueueingStrategy.Instance
					},
				};

		public static Problem.Problem CreateProblem()
		{
			uint boardDimension = ReadNumericInput("Enter board dimension.");
			uint[,] inputBoard = new uint[boardDimension, boardDimension];

			for (uint y = 0; y < boardDimension; y++)
			{
				for (int x = 0; x < boardDimension; x++)
				{
					inputBoard[y, x] =
						ReadNumericInput($"Enter board value at row {x}, column {y}");
				}
			}

			TileGrid tileGrid = TileGridUtility.CreateInputInstance(inputBoard, boardDimension);

			Console.WriteLine($"Board created:\n{tileGrid} ");

			Solution solution = TileGridUtility.CreateAnswerInstance(tileGrid, boardDimension);

			return new Problem.Problem(
				tileGrid,
				solution);
		}

		public static QueueingStrategy SelectQueueingStrategy()
		{
			string input;
			QueueingStrategyType inputValue;

			do
			{
				Console.WriteLine("Select an algorithm:");

				foreach (KeyValuePair<QueueingStrategyType, QueueingStrategy> pair in
					QueuingStrategiesByType)
				{
					QueueingStrategyType queueingStrategyType = pair.Key;

					Console.WriteLine(
						$"{(uint) queueingStrategyType}. {queueingStrategyType.ToString()}");
				}

				input = Console.ReadLine();
			}
			while (!Enum.TryParse(input, out inputValue));

			return QueuingStrategiesByType[inputValue];
		}

		private static uint ReadNumericInput(string instructionText)
		{
			string input;
			uint inputValue;

			do
			{
				Console.WriteLine(instructionText);
				input = Console.ReadLine();
			}
			while (!uint.TryParse(input, out inputValue));

			return inputValue;
		}
	}
}