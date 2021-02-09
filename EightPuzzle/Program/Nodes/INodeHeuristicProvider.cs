#region

using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program.Nodes
{
	public interface INodeHeuristicProvider
	{
		ITileGridState TileGridState { get; }

		uint Cost { get; set; }
	}
}