using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.CompareLeafTraversal
{
    class CompareLeafTraversalSol1
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
        // O(n + m) time | O(h1 + h2) space - where n is the number of nodes in the first
        // Binary Tree, m is the number in the second, h1 is the height of the first Binary
        // Tree, and h2 is the height of the second
        public bool CompareLeafTraversal(BinaryTree tree1, BinaryTree tree2)
        {
            Stack<BinaryTree> tree1TraversalStack = new Stack<BinaryTree>();
            tree1TraversalStack.Push(tree1);
            Stack<BinaryTree> tree2TraversalStack = new Stack<BinaryTree>();
            tree2TraversalStack.Push(tree2);
            while (tree1TraversalStack.Count > 0 && tree2TraversalStack.Count > 0)
            {
                BinaryTree tree1Leaf = getNextLeafNode(tree1TraversalStack);
                BinaryTree tree2Leaf = getNextLeafNode(tree2TraversalStack);
                if (tree1Leaf.value != tree2Leaf.value)
                {
                    return false;
                }
            }
            return (tree1TraversalStack.Count == 0) && (tree2TraversalStack.Count == 0);
        }
        public BinaryTree getNextLeafNode(Stack<BinaryTree> traversalStack)
        {
            BinaryTree currentNode = traversalStack.Pop();
            while (!isLeafNode(currentNode))
            {
                if (currentNode.right != null)
                {
                    traversalStack.Push(currentNode.right);
                }
                // We purposely add the left node to the stack after the
                // right node so that it gets popped off the stack first.
                if (currentNode.left != null)
                {
                    traversalStack.Push(currentNode.left);
                }
                currentNode = traversalStack.Pop();
            }
            return currentNode;
        }
        public bool isLeafNode(BinaryTree node)
        {
            return (node.left == null) && (node.right == null);
        }
    }
}
