namespace EightPuzzle.Program.Nodes
{
	public interface INodeTileController
	{
		public bool MoveLeft();

		public bool MoveRight();

		public bool MoveUp();

		public bool MoveDown();
	}
}