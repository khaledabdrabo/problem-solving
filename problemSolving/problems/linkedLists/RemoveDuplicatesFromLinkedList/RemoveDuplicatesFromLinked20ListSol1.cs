using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.RemoveDuplicatesFromLinkedList
{
    class RemoveDuplicatesFromLinked20ListSol1
    {
        // This is an input class. Do not edit.
        public class LinkedList
        {
            public int value;
            public LinkedList next;
            public LinkedList(int value)
            {
                this.value = value;
                this.next = null;
            }
        }
        // O(n) time | O(1) space - where n is the number of nodes in the Linked List
        public LinkedList RemoveDuplicatesFromLinkedList(LinkedList linkedList)
        {
            LinkedList currentNode = linkedList;
            while (currentNode != null)
            {
                LinkedList nextDistinctNode = currentNode.next;
                while (nextDistinctNode != null &&
                nextDistinctNode.value == currentNode.value)
                {
                    nextDistinctNode = nextDistinctNode.next;
                }
                currentNode.next = nextDistinctNode;
                currentNode = nextDistinctNode;
            }
            return linkedList;
        }
    }
}
