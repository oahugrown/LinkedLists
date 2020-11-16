using System;
using LinkedList;

// Version: 1.0
// Date: 11/15/2020
// Author: Yvonne Yeung
// Limitations: RunTests() uses the generic Random seed that System has to offer.
//				Due Random not being able to produce a negative values, this current
//				version of the automation only accepts positive numbers hence the
//				choice of unsigned ints.


namespace AutomationLinkedLists
{
	public class AutomationLinkedLists
	{
		LinkedList.LinkedList myList;

		private void FailedTestCase(string type)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			System.Console.Write("------------FAILED TESTCASE HERE------------ " + type );
			Console.ForegroundColor = ConsoleColor.White;
		}

		// Produces a randon number between minRange (inclusive) and maxRange (exclusive) and
		// generates a single linked list that is size of length. 
		public void RunTests(uint minRange, uint maxRange, uint length)
		{
			Random random = new Random();

			// Vetting insert works.
			for (int i = 0; i < length; ++i)
			{
				// if this is our head node
				if (i == 0)
				{
					myList = new LinkedList.LinkedList(random.Next((int)minRange, (int)maxRange));
					continue;
				}

				myList.InsertSorted(random.Next((int)minRange, (int)maxRange));
			}

			// Vet size of list is the same as length
			if (length != myList.GetSize())
				FailedTestCase("LENGTH");
			else
				System.Console.WriteLine("PASSED: sizeof linked list expected: " + length + " actual: " + myList.GetSize());

			// Vetting its all sorted
			LinkedListNode.Node currentNode = myList.GetHeadNode();
			int count = 1; //start count at 1 to count the Head;
			while(currentNode.GetNextNode() != null)
            {
				// check if current node is less than or equal to the next node
				if (currentNode.GetValue() <= currentNode.GetNextNode().GetValue())
				{
					// so far its sorted, move to the next node
					currentNode = currentNode.GetNextNode();
				}
				
				// we have a currentNode value that is > the nextNodes value, failed
				else
				{
					FailedTestCase("SORTING - currentNode: " + currentNode.GetValue() + " nextNodes value: " + currentNode.GetNextNode().GetValue());
					break;
				}
				count++;
            }

			// Manual count to make sure all is accounted for
			System.Console.WriteLine("PASSED: Manual count " + count.ToString());
			
			// Sorting test passed
			System.Console.WriteLine("PASSED: Sorting");
			myList.PrintList();
		}
	}
}