using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.LinkedListPalindrome
{
    class LinkedListPalindromeSol1
    {
        // O(n) time | O(n) space - where n is the number of nodes in the Linked List
        public bool LinkedListPalindrome(LinkedList head)
        {
            LinkedListInfo isPalindromeResults = isPalindrome(head, head);
            return isPalindromeResults.outerNodesAreEqual;
        }
        public LinkedListInfo isPalindrome(LinkedList leftNode, LinkedList rightNode)
        {
            if (rightNode == null) return new LinkedListInfo(true, leftNode);
            LinkedListInfo recursiveCallResults = isPalindrome(leftNode, rightNode.next);
            LinkedList leftNodeToCompare = recursiveCallResults.leftNodeToCompare;
            bool outerNodesAreEqual = recursiveCallResults.outerNodesAreEqual;
            bool recursiveIsEqual = outerNodesAreEqual &&
            (leftNodeToCompare.value == rightNode.value);
            LinkedList nextLeftNodeToCompare = leftNodeToCompare.next;
            return new LinkedListInfo(recursiveIsEqual, nextLeftNodeToCompare);
        }
        public class LinkedListInfo
        {
            public bool outerNodesAreEqual;
            public LinkedList leftNodeToCompare;
            public LinkedListInfo(bool outerNodesAreEqual, LinkedList leftNodeToCompare)
            {
                this.outerNodesAreEqual = outerNodesAreEqual;
                this.leftNodeToCompare = leftNodeToCompare;
            }
        }
        public class LinkedList
        {
            public int value;
            public LinkedList next = null;
            public LinkedList(int value)
            {
                this.value = value;
            }
        }
    }
}
