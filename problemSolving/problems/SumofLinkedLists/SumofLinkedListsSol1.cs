using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.SumofLinkedLists
{
    class SumofLinkedListsSol1
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
        // O(max(n, m)) time | O(max(n, m)) space - where n is the length of the
        // first Linked List and m is the length of the second Linked List
        public LinkedList SumOfLinkedLists(LinkedList linkedListOne, LinkedList linkedListTwo)
        {
            // This variable will store a dummy node whose .next
            // attribute will point to the head of our new LL.
            LinkedList newLinkedListHeadPointer = new LinkedList(0);
            LinkedList currentNode = newLinkedListHeadPointer;
            int carry = 0;
            LinkedList nodeOne = linkedListOne;
            LinkedList nodeTwo = linkedListTwo;
            while (nodeOne != null || nodeTwo != null || carry != 0)
            {
                int valueOne = (nodeOne != null) ? nodeOne.value : 0;
                int valueTwo = (nodeTwo != null) ? nodeTwo.value : 0;
                int sumOfValues = valueOne + valueTwo + carry;
                int newValue = sumOfValues % 10;
                LinkedList newNode = new LinkedList(newValue);
                currentNode.next = newNode;
                currentNode = newNode;
                carry = sumOfValues / 10;
                nodeOne = (nodeOne != null) ? nodeOne.next : null;
                nodeTwo = (nodeTwo != null) ? nodeTwo.next : null;
            }
            return newLinkedListHeadPointer.next;
        }

    }
}
