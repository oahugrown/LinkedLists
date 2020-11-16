using System;
using LinkedListNode;

// Version: 1.0
// Date: 11/15/2020
// Author: Yvonne Yeung
// How it works: When creating a new LinkedList, you must already know the first
//				 value of the first node, or generate a null LinkedList to
//				 later.
// Limitations: LinkedList only stores headNode, so users must traverse starting
//				at the headNode. 
//				As a requirement that the LinkedList is expected to be sorted the 
//				only way to insert is through InsertSorted(). This method always 
//				looks for a place in the list to insert sorted everything sorted 
//				so this methods runtime worst case is O(n) where n is the is the 
//				size of the list.

namespace LinkedList
{
	public class LinkedList
	{
		Node headNode;
		uint sizeOfList;

		public LinkedList(int val)
        {
			headNode = new Node(val) ;
			sizeOfList = 1;
        }

		public uint GetSize() { return sizeOfList; }
		public Node GetHeadNode() { return headNode; }

		public void InsertSorted(int val)
		{
			Node nodeToAdd = new Node(val);
			// if headNode is a smaller value than val, it remains the head.
			if (headNode.GetValue() < val)
			{
				// Check where this new node will be inserted
				Node currentNode = headNode;

				if (headNode.GetNextNode() != null)
				{
					while (currentNode.GetNextNode() != null)
					{
						// Check if we insert after currentNode
						if (nodeToAdd.GetValue() > currentNode.GetValue())
						{
							// Check if nextNode is higher
							if (nodeToAdd.GetValue() > currentNode.GetNextNode().GetValue())
							{
								currentNode = currentNode.GetNextNode();
								continue;
							}

							// The new node is not higher so insert after our currentNode
							// Set the remaining portion of our list into the node to add
							nodeToAdd.SetNextNode(currentNode.GetNextNode());

							// Add the new node to the list
							currentNode.SetNextNode(nodeToAdd);
							sizeOfList++;
							return;
						}

						currentNode = currentNode.GetNextNode();
					}
					// We've made it to the end of our list! Add the node at the end
					currentNode.SetNextNode(nodeToAdd);
					sizeOfList++;
				}

				// there is no next node on the head, so we can just add it
				else
				{
					headNode.SetNextNode(nodeToAdd);
					sizeOfList++;
				}
			}
			// headNode is larger than value, it is no longer the head
			else
            {
				nodeToAdd.SetNextNode(headNode);
				headNode = nodeToAdd;
				sizeOfList++;
            }
		}

		public void PrintList()
        {
			Node currentNode = headNode;
			Console.WriteLine(currentNode.GetValue());

			while (currentNode.GetNextNode() != null)
			{
				currentNode = currentNode.GetNextNode();
				Console.WriteLine(currentNode.GetValue());
			}
		}
	}
}