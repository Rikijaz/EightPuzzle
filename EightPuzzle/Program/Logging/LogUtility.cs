#region

using System;

#endregion

namespace EightPuzzle.Program.Logging
{
	public static class LogUtility
	{
		public static void Log(object message, LogLevel logLevel)
		{
			if (logLevel >= Driver.Program.LogLevel)
			{
				Console.WriteLine(message);
			}
		}
	}
}