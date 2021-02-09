namespace EightPuzzle.Program.Tiles
{
	/**
	 * We strongly wrap the raw numeric value of the tile for clarity and comparison purposes.
	 */
	public readonly struct Tile
	{
		private bool Equals(Tile other) => Value == other.Value;

		public override bool Equals(object obj) => obj is Tile other && Equals(other);

		public override int GetHashCode() => (int) Value;

		public Tile(uint value)
		{
			Value = value;
		}

		public uint Value { get; }

		public static bool operator ==(Tile leftTile, Tile rightTile) =>
			leftTile.Value == rightTile.Value;

		public override string ToString() => Value.ToString();

		public static bool operator !=(Tile leftTile, Tile rightTile) =>
			leftTile.Value != rightTile.Value;
	}
}