using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.AllKindsOfNodeDepths
{
    class AllKindsOfNodeDepthsSol1
    {
        // Average case: when the tree is balanced
        // O(nlog(n)) time | O(h) space - where n is the number of nodes in
        // the Binary Tree and h is the height of the Binary Tree
        public static int AllKindsOfNodeDepths(BinaryTree root)
        {
            int sumOfAllDepths = 0;
            Stack<BinaryTree> stack = new Stack<BinaryTree>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                BinaryTree node = stack.Pop();
                if (node == null) continue;
                sumOfAllDepths += nodeDepths(node, 0);
                stack.Push(node.left);
                stack.Push(node.right);
            }
            return sumOfAllDepths;
        }
        public static int nodeDepths(BinaryTree node, int depth)
        {
            if (node == null) return 0;
            return depth + nodeDepths(node.left, depth + 1) + nodeDepths(node.right, depth + 1);
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
