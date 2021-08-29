using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.FindNodesDistanceK
{
    class FindNodesDistanceKSol1
    {   // This is an input class. Do not edit.
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
            Dictionary<int, BinaryTree> nodesToParents = new Dictionary<int, BinaryTree>();
            populateNodesToParents(tree, nodesToParents, null);
            BinaryTree targetNode = getNodeFromValue(target, tree, nodesToParents);
            return breadthFirstSearchForNodesDistanceK(targetNode, nodesToParents, k);
        }
        public List<int> breadthFirstSearchForNodesDistanceK(BinaryTree targetNode, Dictionary<int,
        BinaryTree> nodesToParents, int k)
        {
            Queue<Tuple<BinaryTree, int>> queue = new Queue<Tuple<BinaryTree, int>>();
            queue.Enqueue(new Tuple<BinaryTree, int>(targetNode, 0));
            HashSet<int> seen = new HashSet<int>(targetNode.value);
            seen.Add(targetNode.value);
            while (queue.Count > 0)
            {
                Tuple<BinaryTree, int> vals = queue.Dequeue();
                BinaryTree currentNode = vals.Item1;
                int distanceFromTarget = vals.Item2;
                if (distanceFromTarget == k)
                {
                    List<int> nodeDistanceK = new List<int>();
                    foreach (var pair in queue)
                    {
                        nodeDistanceK.Add(pair.Item1.value);
                    }
                    nodeDistanceK.Add(currentNode.value);
                    return nodeDistanceK;
                }
                List<BinaryTree> connectedNodes = new List<BinaryTree>();
                connectedNodes.Add(currentNode.left);
                connectedNodes.Add(currentNode.right);
                connectedNodes.Add(nodesToParents[currentNode.value]);
                foreach (var node in connectedNodes)
                {
                    if (node == null) continue;
                    if (seen.Contains(node.value)) continue;
                    seen.Add(node.value);
                    queue.Enqueue(new Tuple<BinaryTree, int>(node,
                    distanceFromTarget + 1));
                }
            }
            return new List<int>();
        }
        public BinaryTree getNodeFromValue(int value, BinaryTree tree, Dictionary<int,
        BinaryTree> nodesToParents)
        {
            if (tree.value == value) return tree;
            BinaryTree nodeParent = nodesToParents[value];
            if (nodeParent.left != null &&
            nodeParent.left.value == value) return nodeParent.left;
            return nodeParent.right;
        }
        public void populateNodesToParents(BinaryTree node, Dictionary<int,
        BinaryTree> nodesToParents, BinaryTree parent)
        {
            if (node != null)
            {
                nodesToParents[node.value] = parent;
                populateNodesToParents(node.left, nodesToParents, node);
                populateNodesToParents(node.right, nodesToParents, node);
            }
        }
    }

}
