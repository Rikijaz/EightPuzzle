namespace EightPuzzle.Program.Tiles
{
	public interface ITileGridState
	{
		Tile this[TilePosition tilePosition] { get; }

		uint GridDimension { get; }
	}
}