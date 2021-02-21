#region

using System.Text;

#endregion

namespace EightPuzzle.Program.Tiles
{
	public abstract class TileGridState
	{
		protected TileGridState(uint gridDimension)
		{
			GridDimension = gridDimension;
		}

		public abstract Tile this[TilePosition tilePosition] { get; protected set; }

		public uint GridDimension { get; }

		private bool Equals(TileGridState tileGridState) => this == tileGridState;

		public override bool Equals(object obj) => obj is TileGridState other && Equals(other);

		public override int GetHashCode() => (int) GridDimension;

		public string GetMetaData()
		{
			StringBuilder stringBuilder = new StringBuilder();

			for (int y = 0; y < GridDimension; ++y)
			{
				for (int x = 0; x < GridDimension; ++x)
				{
					stringBuilder.Append(this[new TilePosition(x, y)].Value.ToString());
				}
			}

			return stringBuilder.ToString();
		}

		public static bool operator ==(
			TileGridState leftTileGridState,
			TileGridState rightTileGridState)
		{
			for (int y = 0; y < leftTileGridState.GridDimension; ++y)
			{
				for (int x = 0; x < leftTileGridState.GridDimension; ++x)
				{
					TilePosition tilePosition = new TilePosition(x, y);

					if (leftTileGridState[tilePosition] != rightTileGridState[tilePosition])
					{
						return false;
					}
				}
			}

			return true;
		}

		public static bool operator !=(
			TileGridState leftTileGridState,
			TileGridState rightTileGridState) =>
			!(leftTileGridState == rightTileGridState);
	}
}