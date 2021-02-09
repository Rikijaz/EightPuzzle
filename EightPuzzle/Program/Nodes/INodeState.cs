#region

using EightPuzzle.Program.Tiles;

#endregion

namespace EightPuzzle.Program.Nodes
{
	public interface INodeState
	{
		ITileGridState TileGridState { get; }
	}
}