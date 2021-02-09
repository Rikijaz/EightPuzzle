#region

using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program.Nodes
{
	public interface INodeHeuristicProvider
	{
		ITileGridState TileGridState { get; }

		TilePosition EmptyTilePosition { get; }

		uint CurrentCost { get; set; }

		uint StartCost { get; set; }
	}
}