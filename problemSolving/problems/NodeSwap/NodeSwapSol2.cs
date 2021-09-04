using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.NodeSwap
{
    class NodeSwapSol2
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
        public LinkedList NodeSwap(LinkedList head)
        {
            LinkedList tempNode = new LinkedList(0);
            tempNode.next = head;
            LinkedList prevNode = tempNode;
            while (prevNode.next != null && prevNode.next.next != null)
            {
                LinkedList firstNode = prevNode.next;
                LinkedList secondNode = prevNode.next.next;
                // prevNode => firstNode => secondNode => x
                firstNode.next = secondNode.next;
                secondNode.next = firstNode;
                prevNode.next = secondNode;
                // prevNode => secondNode => firstNode => x
                prevNode = firstNode;
            }
            return tempNode.next;
        }

    }
}
