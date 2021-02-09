namespace EightPuzzle.Program.Tiles
{
	public readonly struct TilePosition
	{
		public TilePosition(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; }

		public int Y { get; }

		public override string ToString() => $"[{X}, {Y}]";
	}
}