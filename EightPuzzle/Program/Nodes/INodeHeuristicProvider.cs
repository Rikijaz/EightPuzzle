#region

using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program.Nodes
{
	public interface INodeHeuristicProvider
	{
		TileGridState TileGridState { get; }

		TilePosition EmptyTilePosition { get; }
	}
}