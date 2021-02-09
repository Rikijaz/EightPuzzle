namespace EightPuzzle.Program.Nodes
{
	public interface INodeController
	{
		public bool MoveLeft();

		public bool MoveRight();

		public bool MoveUp();

		public bool MoveDown();
	}
}