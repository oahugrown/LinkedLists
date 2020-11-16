// Version: 1.0
// Date: 11/15/2020
// Author: Yvonne Yeung
// Limitations: For use of single LinkedList

namespace LinkedListNode
{
	public class Node
	{
		int value;
		Node next;

		public Node(int val = 0)
		{
			value = val;
			next = null;
		}
		public int GetValue() { return value; }

		public Node GetNextNode() { return next; }

		public void SetNextNode(Node nextNode) { next = nextNode; }
	}
}