using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.CompareLeafTraversal
{
    class CompareLeafTraversalSol2
    {
        // This is an input class. Do not edit.
        public class BinaryTree
        {
            public int value;
            public BinaryTree left = null;
            public BinaryTree right = null;
            public BinaryTree(int value)
            {
                this.value = value;
            }
        }
        // O(n + m) time | O(max(h1, h2)) space - where n is the number of nodes in the first
        // Binary Tree, m is the number in the second, h1 is the height of the first Binary
        // Tree, and h2 is the height of the second
        public bool CompareLeafTraversal(BinaryTree tree1, BinaryTree tree2)
        {
            BinaryTree tree1LeafNodesLinkedList = connectLeafNodes(tree1, null, null)[0];
            BinaryTree tree2LeafNodesLinkedList = connectLeafNodes(tree2, null, null)[0];
            BinaryTree list1CurrentNode = tree1LeafNodesLinkedList;
            BinaryTree list2CurrentNode = tree2LeafNodesLinkedList;
            while (list1CurrentNode != null && list2CurrentNode != null)
            {
                if (list1CurrentNode.value != list2CurrentNode.value) return false;
                list1CurrentNode = list1CurrentNode.right;
                list2CurrentNode = list2CurrentNode.right;
            }
            return list1CurrentNode == null && list2CurrentNode == null;
        }
        BinaryTree[] connectLeafNodes(BinaryTree currentNode, BinaryTree head,
        BinaryTree previousNode)
        {
            if (currentNode == null) return new BinaryTree[] { head, previousNode };
            if (isLeafNode(currentNode))
            {
                if (previousNode == null)
                {
                    head = currentNode;
                }
                else
                {
                    previousNode.right = currentNode;
                }
                previousNode = currentNode;
            }
            BinaryTree[] nodes = connectLeafNodes(
            currentNode.left,
            head,
            previousNode
            );
            BinaryTree leftHead = nodes[0];
            BinaryTree leftPreviousNode = nodes[1];
            return connectLeafNodes(currentNode.right, leftHead, leftPreviousNode);
        }
        public bool isLeafNode(BinaryTree node)
        {
            return (node.left == null) && (node.right == null);
        }

    }
}
