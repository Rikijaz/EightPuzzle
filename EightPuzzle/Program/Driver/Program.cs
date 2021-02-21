#region

using System.Diagnostics;
using EightPuzzle.Program.Logging;
using EightPuzzle.Program.Problem;
using EightPuzzle.Program.QueueingStrategies;

#endregion

namespace EightPuzzle.Program.Driver
{
	internal static class Program
	{
		public const LogLevel LogLevel = Logging.LogLevel.Info;

		private static readonly Stopwatch Stopwatch = new Stopwatch();

		public static void Main(string[] args)
		{
			Problem.Problem problem = Controller.CreateProblem();
			QueueingStrategy queueingStrategy = Controller.SelectQueueingStrategy();

			LogUtility.Log("Solving problem ...", LogLevel.Info);
			LogUtility.Log(problem.InitialGrid.ToString(), LogLevel.Info);

			Stopwatch.Reset();
			Stopwatch.Start();
			SolutionAnalysis solutionAnalysis = Solver.GeneralSearch(problem, queueingStrategy);
			Stopwatch.Stop();

			LogUtility.Log(solutionAnalysis.ToString(), LogLevel.Info);

			//TestSuite.RunTest();
		}
	}
}