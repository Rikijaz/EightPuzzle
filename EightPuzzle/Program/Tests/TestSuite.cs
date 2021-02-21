#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using EightPuzzle.Program.Logging;
using EightPuzzle.Program.Problem;
using EightPuzzle.Program.QueueingStrategies;

#endregion

namespace EightPuzzle.Program.Tests
{
	public static class TestSuite
	{
		public static void RunTest(QueueingStrategy queueingStrategy)
		{
			Stopwatch stopWatch = new Stopwatch();

			foreach (KeyValuePair<uint, Problem.Problem> pair in TestCases.ProblemsByDepth)
			{
				uint depth = pair.Key;

				Problem.Problem problem = pair.Value;

				LogUtility.Log($"Solving problem with depth {depth}...", LogLevel.Info);
				LogUtility.Log(problem.InitialGrid.ToString(), LogLevel.Info);

				stopWatch.Reset();
				stopWatch.Start();
				SolutionAnalysis solutionAnalysis = Solver.GeneralSearch(problem, queueingStrategy);

				stopWatch.Stop();
				LogUtility.Log(solutionAnalysis, LogLevel.Info);

				LogTimeElapsed(stopWatch.Elapsed);
			}

			LogTimeElapsed(stopWatch.Elapsed);
		}

		public static void RunTest(QueueingStrategy queueingStrategy, uint depth)
		{
			Stopwatch stopWatch = new Stopwatch();

			Problem.Problem problem = TestCases.ProblemsByDepth[depth];

			LogUtility.Log(
				$"Solving problem with depth {depth} using {queueingStrategy}...",
				LogLevel.Info);

			LogUtility.Log(problem.InitialGrid.ToString(), LogLevel.Info);

			stopWatch.Reset();
			stopWatch.Start();
			Solver.GeneralSearch(problem, queueingStrategy);
			stopWatch.Stop();

			SolutionAnalysis solutionAnalysis = Solver.GeneralSearch(problem, queueingStrategy);
			LogTimeElapsed(stopWatch.Elapsed);
			LogUtility.Log(solutionAnalysis.ToString(), LogLevel.Info);
		}

		private static void LogTimeElapsed(TimeSpan timeSpan) =>
			LogUtility.Log($"Time elapsed: {timeSpan.ToString()}", LogLevel.Info);
	}
}