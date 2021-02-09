#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using EightPuzzle.Program.QueueingStrategy;
using EightPuzzle.Program.Utility;

#endregion

namespace EightPuzzle.Program
{
	public static class TestSuite
	{
		public static void RunTests()
		{
			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();
			stopWatch.Stop();

			foreach (KeyValuePair<uint, Problem> pair in TestCases.ProblemsByDepth)
			{
				uint depth = pair.Key;

				Problem problem = pair.Value;

				LogUtility.Log($"Solving problem with depth {depth}...", LogLevel.Info);
				LogUtility.Log(problem.InitialGrid.ToString(), LogLevel.Info);

				stopWatch.Reset();
				stopWatch.Start();
				Solver.GeneralSearch(problem, MisplacedTileQueuingStrategy.Instance);
				stopWatch.Stop();

				LogUtility.Log($"Solved problem with depth {depth}.", LogLevel.Info);
				LogTimeElapsed(stopWatch.Elapsed);
			}

			LogTimeElapsed(stopWatch.Elapsed);
		}

		private static void LogTimeElapsed(TimeSpan timeSpan)
		{
			string elapsedTime =
				$"{timeSpan.Hours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}.{timeSpan.Milliseconds / 10:00}";

			LogUtility.Log($"Time elapsed: {timeSpan.ToString()}", LogLevel.Info);
		}
	}
}