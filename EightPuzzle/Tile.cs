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
	}
}