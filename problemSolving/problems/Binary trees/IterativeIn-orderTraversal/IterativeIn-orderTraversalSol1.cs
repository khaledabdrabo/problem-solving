using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.IterativeIn_orderTraversal
{
    class IterativeIn_orderTraversalSol1
    {
        // O(n) time | O(1) space
        public static void IterativeInOrderTraversal(BinaryTree tree, Action<BinaryTree> callback)
        {
            BinaryTree previousNode = null;
            BinaryTree currentNode = tree;
            while (currentNode != null)
            {
                BinaryTree nextNode;
                if (previousNode == null || previousNode == currentNode.parent)
                {
                    if (currentNode.left != null)
                    {
                        nextNode = currentNode.left;
                    }
                    else
                    {
                        callback(currentNode);
                        nextNode = currentNode.right !=
                        null ? currentNode.right : currentNode.parent;
                    }
                }
                else if (previousNode == currentNode.left)
                {
                    callback(currentNode);
                    nextNode = currentNode.right !=
                    null ? currentNode.right : currentNode.parent;
                }
                else
                {
                    nextNode = currentNode.parent;
                }
                previousNode = currentNode;
                currentNode = nextNode;
            }
        }
        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;
            public BinaryTree parent;
            public BinaryTree(int value)
            {
                this.value = value;
            }
            public BinaryTree(int value, BinaryTree parent)
            {
                this.value = value;
                this.parent = parent;
            }
        }

    }
}
