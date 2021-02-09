namespace EightPuzzle.Program.Nodes.PriorityQueue
{
	public static class NodePriorityQueueBuilder
	{
		public static NodePriorityQueue CreateInstance(Node node)
		{
			NodePriorityQueue nodePriorityQueue = new NodePriorityQueue();
			nodePriorityQueue.Enqueue(node);

			return nodePriorityQueue;
		}
	}
}