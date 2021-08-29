using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.AllKindsOfNodeDepths
{
    class AllKindsOfNodeDepthsSol5
    {
        // Average case: when the tree is balanced
        // O(n) time | O(h) space - where n is the number of nodes in
        // the Binary Tree and h is the height of the Binary Tree
        public static int AllKindsOfNodeDepths(BinaryTree root)
        {
            return allKindsOfNodeDepthsHelper(root, 0, 0);
        }
        public static int allKindsOfNodeDepthsHelper(BinaryTree root, int depthSum, int depth)
        {
            if (root == null) return 0;
            depthSum += depth;
            return depthSum +
            allKindsOfNodeDepthsHelper(root.left, depthSum,
            depth + 1) + allKindsOfNodeDepthsHelper(root.right, depthSum, depth + 1);
        }
        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;
            public BinaryTree(int value)
            {
                this.value = value;
                left = null;
                right = null;
            }
        }
    }
}
