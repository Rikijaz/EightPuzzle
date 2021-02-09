#region

using System;
using System.Collections.Generic;

#endregion

namespace EightPuzzle.Program.Nodes.PriorityQueue
{
	public class NodePriorityQueue
	{
		public NodePriorityQueue()
		{
			QueuesByPriority = new SortedDictionary<uint, Queue<Node>>(new NodeCostComparer());
			Count = 0;
		}

		public int Count { get; private set; }

		private SortedDictionary<uint, Queue<Node>> QueuesByPriority { get; }

		public bool IsEmpty() => Count == 0;

		public void Enqueue(Node node)
		{
			uint totalCost = node.StartCost + node.CurrentCost;

			if (!QueuesByPriority.ContainsKey(totalCost))
			{
				QueuesByPriority.Add(totalCost, new Queue<Node>());
			}

			QueuesByPriority[totalCost].Enqueue(node);
			Count++;
		}

		public Node Dequeue()
		{
			if (IsEmpty())
			{
				throw new ArgumentException("Priority queue cannot dequeue when it is empty.");
			}

			foreach (KeyValuePair<uint, Queue<Node>> pair in QueuesByPriority)
			{
				Queue<Node> nodes = pair.Value;

				if (nodes.Count == 0)
				{
					continue;
				}

				Count--;

				return nodes.Dequeue();
			}

			throw new IndexOutOfRangeException("");
		}

		public Node Peek()
		{
			if (IsEmpty())
			{
				throw new ArgumentException("Priority queue cannot dequeue when it is empty.");
			}

			foreach (KeyValuePair<uint, Queue<Node>> pair in QueuesByPriority)
			{
				Queue<Node> nodes = pair.Value;

				if (nodes.Count > 0)
				{
					return nodes.Peek();
				}
			}

			throw new IndexOutOfRangeException("");
		}
	}
}