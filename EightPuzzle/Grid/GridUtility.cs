#region

using System;

#endregion

namespace EightPuzzle.Grid
{
	public class GridUtility
	{
		public const uint EmptyTileValue = 0;

		public uint[][] CreateInputCollection(uint puzzleSize)
		{
			uint gridLength = (uint) Math.Ceiling(Math.Sqrt(puzzleSize));

			uint[][] inputCollection = new uint[][gridLength];

			for (uint x = 0; x < inputCollection.Length; x++)
			{
				inputCollection[x] = new uint[gridLength];

				uint[] indicesColumn = inputCollection[x];

				for (int j = 0; j < indicesColumn.Length; j++)
				{
					indicesColumn[j] = EmptyTileValue;
				}
			}

			return inputCollection;
		}
	}
}