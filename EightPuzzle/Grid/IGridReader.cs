#region

using System.Collections.Generic;

#endregion

namespace EightPuzzle.Grid
{
	public interface IGridReader
	{
		IReadOnlyList<IReadOnlyList<Tile>> Tiles { get; }
	}
}