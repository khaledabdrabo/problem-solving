using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.ReverseLinkedList
{
    class ReverseLinkedListSol1
    {
        // O(n) time | O(1) space - where n is the number of nodes in the Linked List
        public static LinkedList ReverseLinkedList(LinkedList head)
        {
            LinkedList previousNode = null;
            LinkedList currentNode = head;
            while (currentNode != null)
            {
                LinkedList nextNode = currentNode.Next;
                currentNode.Next = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
            }
            return previousNode;
        }
        public class LinkedList
        {
            public int Value;
            public LinkedList Next = null;
            public LinkedList(int value)
            {
                this.Value = value;
            }
        }
    }
}
