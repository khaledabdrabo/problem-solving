using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.BinaryTreeDiameter
{
    class BinaryTreeDiameterSol1
    {
        // Average case: when the tree is balanced
        // O(n) time | O(h) space - where n is the number of nodes in
        // the Binary Tree and h is the height of the Binary Tree
        public int BinaryTreeDiameter(BinaryTree tree)
        {
            return getTreeInfo(tree).diameter;
        }
        public TreeInfo getTreeInfo(BinaryTree tree)
        {
            if (tree == null)
            {
                return new TreeInfo(0, 0);
            }
            TreeInfo leftTreeInfo = getTreeInfo(tree.left);
            TreeInfo rightTreeInfo = getTreeInfo(tree.right);
            int longestPathThroughRoot = leftTreeInfo.height + rightTreeInfo.height;
            int maxDiameterSoFar = Math.Max(leftTreeInfo.diameter, rightTreeInfo.diameter);
            int currentDiameter = Math.Max(longestPathThroughRoot, maxDiameterSoFar);
            int currentHeight = 1 + Math.Max(leftTreeInfo.height, rightTreeInfo.height);
            return new TreeInfo(currentDiameter, currentHeight);
        }
        public class TreeInfo
        {
            public int diameter;
            public int height;
            public TreeInfo(int diameter, int height)
            {
                this.diameter = diameter;
                this.height = height;
            }
        }
        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;
            public BinaryTree(int value)
            {
                this.value = value;
            }
        }
    }
}
