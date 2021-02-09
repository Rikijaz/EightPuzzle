#region

using System.Collections.Generic;
using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program
{
	public static class TestCases
	{
		private const uint PuzzleGridDimension = 3;

		private static readonly IReadOnlyDictionary<uint, uint[,]> InputCasesByDepth =
			new Dictionary<uint, uint[,]>
			{
				{
					0,
					new uint[,]
					{
						{ 1, 2, 3 },
						{ 4, 5, 6 },
						{ 7, 8, 0 },
					}
				},
				{
					2,
					new uint[,]
					{
						{ 1, 2, 3 },
						{ 4, 5, 6 },
						{ 0, 7, 8 },
					}
				},
				{
					4,
					new uint[,]
					{
						{ 1, 2, 3 },
						{ 5, 0, 6 },
						{ 4, 7, 8 },
					}
				},
				{
					8,
					new uint[,]
					{
						{ 1, 3, 6 },
						{ 5, 0, 2 },
						{ 4, 7, 8 },
					}
				},
				{
					12,
					new uint[,]
					{
						{ 1, 3, 6 },
						{ 5, 0, 7 },
						{ 4, 8, 2 },
					}
				},
				{
					16,
					new uint[,]
					{
						{ 1, 6, 7 },
						{ 5, 0, 3 },
						{ 4, 8, 2 },
					}
				},
				{
					20,
					new uint[,]
					{
						{ 7, 1, 2 },
						{ 4, 8, 5 },
						{ 6, 3, 0 },
					}
				},
				{
					25,
					new uint[,]
					{
						{ 0, 7, 2 },
						{ 4, 6, 1 },
						{ 3, 5, 8 },
					}
				},
			};

		public static readonly IReadOnlyDictionary<uint, Problem> ProblemsByDepth;

		private static readonly ITileGridState SolutionGridState =
			TileGridUtility.CreateAnswerInstance(PuzzleGridDimension);

		static TestCases()
		{
			Dictionary<uint, Problem> problemsByDepth =
				new Dictionary<uint, Problem>(InputCasesByDepth.Count);

			foreach (KeyValuePair<uint, uint[,]> pair in InputCasesByDepth)
			{
				uint depth = pair.Key;

				uint[,] testCase = pair.Value;

				Problem problem = new Problem(
					TileGridUtility.CreateInputInstance(testCase, PuzzleGridDimension),
					SolutionGridState);

				problemsByDepth.Add(depth, problem);
			}

			ProblemsByDepth = problemsByDepth;
		}
	}
}