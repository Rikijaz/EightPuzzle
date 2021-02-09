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

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 17;
				hash = (hash * 23) + X.GetHashCode();
				hash = (hash * 23) + Y.GetHashCode();

				return hash;
			}
		}

		public override string ToString() => $"[{X}, {Y}]";
	}
}