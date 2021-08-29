using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.FindSuccessor
{
    class FindSuccessorSol2
    {
        // This is an input class. Do not edit.
        public class BinaryTree
        {
            public int value;
            public BinaryTree left = null;
            public BinaryTree right = null;
            public BinaryTree parent = null;
            public BinaryTree(int value)
            {
                this.value = value;
            }
        }
        // O(h) time | O(1) space - where h is the height of the tree
        public BinaryTree FindSuccessor(BinaryTree tree, BinaryTree node)
        {
            if (node.right != null) return getLeftmostChild(node.right);
            return getRightmostParent(node);
        }
        public BinaryTree getLeftmostChild(BinaryTree node)
        {
            BinaryTree currentNode = node;
            while (currentNode.left != null)
            {
                currentNode = currentNode.left;
            }
            return currentNode;
        }
        public BinaryTree getRightmostParent(BinaryTree node)
        {
            BinaryTree currentNode = node;
            while (currentNode.parent != null && currentNode.parent.right == currentNode)
            {
                currentNode = currentNode.parent;
            }
            return currentNode.parent;
        }
    }
}
