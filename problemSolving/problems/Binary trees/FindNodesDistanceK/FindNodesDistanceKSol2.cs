using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.FindNodesDistanceK
{
    class FindNodesDistanceKSol2
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
        // O(n) time | O(n) space - where n is the number of nodes in the tree
        public List<int> FindNodesDistanceK(BinaryTree tree, int target, int k)
        {
            List<int> nodesDistanceK = new List<int>();
            findDistanceFromNodeToTarget(tree, target, k, nodesDistanceK);
            return nodesDistanceK;
        }
        public int findDistanceFromNodeToTarget(BinaryTree node, int target, int k,
        List<int> nodesDistanceK)
        {
            if (node == null) return -1;
            if (node.value == target)
            {
                addSubtreeNodeAtDistanceK(node, 0, k, nodesDistanceK);
                return 1;
            }
            int leftDistance =
            findDistanceFromNodeToTarget(node.left, target, k, nodesDistanceK);
            int rightDistance = findDistanceFromNodeToTarget(node.right, target, k,
            nodesDistanceK);
            if (leftDistance == k || rightDistance == k) nodesDistanceK.Add(node.value);
            if (leftDistance != -1)
            {
                addSubtreeNodeAtDistanceK(node.right, leftDistance + 1, k, nodesDistanceK);
                return leftDistance + 1;
            }
            if (rightDistance != -1)
            {
                addSubtreeNodeAtDistanceK(node.left, rightDistance + 1, k, nodesDistanceK);
                return rightDistance + 1;
            }
            return -1;
        }
        void addSubtreeNodeAtDistanceK(BinaryTree node, int distance, int k,
        List<int> nodesDistanceK)
        {
            if (node == null) return;
            if (distance == k)
            {
                nodesDistanceK.Add(node.value);
            }
            else
            {
                addSubtreeNodeAtDistanceK(node.left, distance + 1, k, nodesDistanceK);
                addSubtreeNodeAtDistanceK(node.right, distance + 1, k, nodesDistanceK);
            }
        }
    }
}
