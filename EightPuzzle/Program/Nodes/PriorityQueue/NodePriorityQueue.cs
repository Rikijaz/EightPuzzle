#region

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace EightPuzzle.Program.Nodes.PriorityQueue
{
	public class NodePriorityQueue
	{
		public NodePriorityQueue()
		{
			QueuesByCost = new SortedDictionary<uint, Queue<Node>>(new NodeCostComparer());
			Count = 0;
			HighestCount = 0;
		}

		public uint NodeIdCounter { get; private set; }

		public uint Count { get; private set; }

		public uint HighestCount { get; private set; }

		public uint Depth { get; private set; }

		private SortedDictionary<uint, Queue<Node>> QueuesByCost { get; }

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Node priority queue:");

			foreach (KeyValuePair<uint, Queue<Node>> pair in QueuesByCost)
			{
				uint cost = pair.Key;
				Queue<Node> nodes = pair.Value;

				foreach (Node node in nodes)
				{
					stringBuilder.AppendLine($"Cost {cost} Node {node.Id}:\n{node.TileGridState}");
				}
			}

			return stringBuilder.ToString();
		}

		public void Enqueue(Node node)
		{
			NodeIdCounter++;

			node.Id = NodeIdCounter;

			if (node.Depth > Depth)
			{
				Depth = node.Depth;
			}

			if (!QueuesByCost.ContainsKey(node.Cost))
			{
				QueuesByCost.Add(node.Cost, new Queue<Node>());
			}

			QueuesByCost[node.Cost].Enqueue(node);
			Count++;

			if (Count > HighestCount)
			{
				HighestCount = Count;
			}
		}

		public Node Dequeue()
		{
			if (Count == 0)
			{
				throw new ArgumentException("Priority queue cannot dequeue when it is empty.");
			}

			foreach (KeyValuePair<uint, Queue<Node>> pair in QueuesByCost)
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
	}
}