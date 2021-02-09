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

		private bool Equals(TilePosition other) => (X == other.X) && (Y == other.Y);

		public override bool Equals(object obj) => obj is TilePosition other && Equals(other);

		public static bool operator ==(TilePosition leftTile, TilePosition rightTile) =>
			(leftTile.X == rightTile.X) && (leftTile.Y == rightTile.Y);

		public static bool operator !=(TilePosition leftTile, TilePosition rightTile) =>
			(leftTile.X != rightTile.X) && (leftTile.Y != rightTile.Y);

		public override string ToString() => $"[{X}, {Y}]";
	}
}