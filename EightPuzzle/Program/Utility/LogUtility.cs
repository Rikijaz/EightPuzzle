#region

using System;

#endregion

namespace EightPuzzle.Program.Utility
{
	public static class LogUtility
	{
		private const LogLevel Level = LogLevel.Debug;

		public static void Log(string message, LogLevel logLevel)
		{
			if (logLevel >= Level)
			{
				Console.WriteLine(message);
			}
		}
	}
}