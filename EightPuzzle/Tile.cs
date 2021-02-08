namespace EightPuzzle
{
	/**
	 * We strongly wrap the raw numeric value of the tile for clarity and modularity purposes.
	 */
	public readonly struct Tile
	{
		public Tile(uint value)
		{
			Value = value;
		}

		public uint Value { get; }

		public static bool operator ==(Tile leftTile, Tile rightTile) =>
			leftTile.Value == rightTile.Value;

		public static bool operator !=(Tile leftTile, Tile rightTile) =>
			leftTile.Value != rightTile.Value;
	}
}