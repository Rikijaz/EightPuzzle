#region

using System;
using System.Collections.Generic;
using EightPuzzle.Program.Nodes;

#endregion

namespace EightPuzzle.Program
{
	public class NodePriorityQueue
	{
		public NodePriorityQueue()
		{
			QueuesByPriority = new SortedDictionary<uint, Queue<Node>>();
			Count = 0;
		}

		private int Count { get; set; }

		private SortedDictionary<uint, Queue<Node>> QueuesByPriority { get; }

		public bool IsEmpty() => Count == 0;

		public void Enqueue(Node node)
		{
			if (!QueuesByPriority.ContainsKey(node.Cost))
			{
				QueuesByPriority.Add(node.Cost, new Queue<Node>());
			}

			QueuesByPriority[node.Cost].Enqueue(node);
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

		public object Peek()
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