using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.ValidateThreeNodes
{
    public class ValidateThreeNodesSol2
    {
        public class BST
        {
            public int value;
            public BST left = null;
            public BST right = null;
            public BST(int value)
            {
                this.value = value;
            }
        }
        // O(h) time | O(1) space - where h is the height of the tree
        public bool ValidateThreeNodes(BST nodeOne, BST nodeTwo, BST nodeThree)
        {
            if (isDescendant(nodeTwo, nodeOne))
            {
                return isDescendant(nodeThree, nodeTwo);
            }
            if (isDescendant(nodeTwo, nodeThree))
            {
                return isDescendant(nodeOne, nodeTwo);
            }
            return false;
        }
        // Whether the `target` is a descendant of the `node`.
        public bool isDescendant(BST node, BST target)
        {
            while (node != null && node != target)
            {
                node = (target.value < node.value) ? node.left : node.right;
            }
            return node == target;
        }
    }
}
