using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.NodeSwap
{
    class NodeSwapSol1
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
        // O(n) time | O(n) space - where n is the number of nodes in the Linked List
        public LinkedList NodeSwap(LinkedList head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            LinkedList nextNode = head.next;
            head.next = NodeSwap(head.next.next);
            nextNode.next = head;
            return nextNode;
        }
    }
}
