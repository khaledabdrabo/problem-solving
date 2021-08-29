using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.ValidateThreeNodes
{
    public class ValidateThreeNodesSol3
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
        // O(d) time | O(1) space - where d is the distance between nodeOne and nodeThree
        public bool ValidateThreeNodes(BST nodeOne, BST nodeTwo, BST nodeThree)
        {
            BST searchOne = nodeOne;
            BST searchTwo = nodeThree;
            while (true)
            {
                bool foundThreeFromOne = searchOne == nodeThree;
                bool foundOneFromThree = searchTwo == nodeOne;
                bool foundNodeTwo = (searchOne == nodeTwo) || (searchTwo == nodeTwo);
                bool finishedSearching = (searchOne == null) && (searchTwo == null);
                if (foundThreeFromOne || foundOneFromThree || foundNodeTwo ||
                finishedSearching)
                {
                    break;
                }
                if (searchOne != null)
                {
                    searchOne =
                    (searchOne.value >
                    nodeTwo.value) ? searchOne.left : searchOne.right;
                }
                if (searchTwo != null)
                {
                    searchTwo =
                    (searchTwo.value >
                    nodeTwo.value) ? searchTwo.left : searchTwo.right;
                }
            }
            bool foundNodeFromOther = (searchOne == nodeThree) || (searchTwo == nodeOne);
            bool foundNodeTwoFinal = (searchOne == nodeTwo) || (searchTwo == nodeTwo);
            if (!foundNodeTwoFinal || foundNodeFromOther)
            {
                return false;
            }
            return searchForTarget(nodeTwo, (searchOne == nodeTwo) ? nodeThree : nodeOne);
        }
        public bool searchForTarget(BST node, BST target)
        {
            while (node != null && node != target)
            {
                node = (target.value < node.value) ? node.left : node.right;
            }
            return node == target;
        }
    }
}
