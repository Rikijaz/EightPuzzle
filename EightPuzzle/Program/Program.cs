#region

using System;

#endregion

namespace EightPuzzle.Program
{
	internal static class Program
	{
		private const uint PuzzleLength = 8;

		private static readonly uint PuzzleGridDimension =
			(uint) Math.Ceiling(Math.Sqrt(PuzzleLength));

		public static void Main(string[] args) => TestSuite.RunTests();
	}
}