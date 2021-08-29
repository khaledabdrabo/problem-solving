using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.HeightBalancedBinaryTree
{
    class HeightBalancedBinaryTreeSol1
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
        public class TreeInfo
        {
            public bool isBalanced;
            public int height;
            public TreeInfo(bool isBalanced, int height)
            {
                this.isBalanced = isBalanced;
                this.height = height;
            }
        }
        // O(n) time | O(h) space - where n is the number of nodes in the binary tree
        public bool HeightBalancedBinaryTree(BinaryTree tree)
        {
            TreeInfo treeInfo = getTreeInfo(tree);
            return treeInfo.isBalanced;
        }
        public TreeInfo getTreeInfo(BinaryTree node)
        {
            if (node == null)
            {
                return new TreeInfo(true, -1);
            }
            TreeInfo leftSubtreeInfo = getTreeInfo(node.left);
            TreeInfo rightSubtreeInfo = getTreeInfo(node.right);
            bool isBalanced = leftSubtreeInfo.isBalanced && rightSubtreeInfo.isBalanced
            && Math.Abs(leftSubtreeInfo.height - rightSubtreeInfo.height) <= 1;
            int height = Math.Max(leftSubtreeInfo.height, rightSubtreeInfo.height) + 1;
            return new TreeInfo(isBalanced, height);
        }

    }
}
