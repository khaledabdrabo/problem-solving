using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.FindSuccessor
{
    class FindSuccessorSol1
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
        // O(n) time | O(n) space - where n is the number of nodes in the tree
        public BinaryTree FindSuccessor(BinaryTree tree, BinaryTree node)
        {
            List<BinaryTree> inOrderTraversalOrder = new List<BinaryTree>();
            getInOrderTraversalOrder(tree, inOrderTraversalOrder);
            for (int i = 0; i < inOrderTraversalOrder.Count; i++)
            {
                BinaryTree currentNode = inOrderTraversalOrder[i];
                if (currentNode != node)
                {
                    continue;
                }
                if (i == inOrderTraversalOrder.Count - 1)
                {
                    return null;
                }
                return inOrderTraversalOrder[i + 1];
            }
            return null;
        }
        void getInOrderTraversalOrder(BinaryTree node, List<BinaryTree> order)
        {
            if (node == null)
            {
                return;
            }
            getInOrderTraversalOrder(node.left, order);
            order.Add(node);
            getInOrderTraversalOrder(node.right, order);
        }

    }
}
