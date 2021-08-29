using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.RemoveKthNodeFromEnd
{
    class RemoveKthNodeFromEndSol1
    {
        // O(n) time | O(1) space
        public static void RemoveKthNodeFromEnd(LinkedList head, int k)
        {
            int counter = 1;
            LinkedList first = head;
            LinkedList second = head;
            while (counter <= k)
            {
                second = second.Next;
                counter++;
            }
            if (second == null)
            {
                head.Value = head.Next.Value;
                head.Next = head.Next.Next;
                return;
            }
            while (second.Next != null)
            {
                second = second.Next;
                first = first.Next;
            }
            first.Next = first.Next.Next;
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
