﻿using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.BranchSums
{

    public class BranchSumsSol1
    {
        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;
            public BinaryTree(int value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
            }
        }
        // O(n) time | O(n) space - where n is the number of nodes in the Binary Tree
        public static List<int> BranchSums(BinaryTree root)
        {
            List<int> sums = new List<int>();
            calculateBranchSums(root, 0, sums);
            return sums;
        }
        public static void calculateBranchSums(BinaryTree node, int runningSum, List<int> sums)
        {
            if (node == null) return;
            int newRunningSum = runningSum + node.value;
            if (node.left == null && node.right == null)
            {
                sums.Add(newRunningSum);
                return;
            }
            calculateBranchSums(node.left, newRunningSum, sums);
            calculateBranchSums(node.right, newRunningSum, sums);
        }
    }

}
