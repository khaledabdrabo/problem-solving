using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.ValidateThreeNodes
{
    class ValidateThreeNodesSol1
    {
        // This is an input class. Do not edit.
        public class BST
        {
            public int value;
            public BST left=null;
            public BST right = null;
            public BST(int value)
            {
                this.value=value;
            }
        }
        public bool ValidateThreeNodes(BST nodeOne,BST nodeTwo,BST nodeThree)
        {
            if(isDescendant ( nodeTwo, nodeOne ))
            {
                return isDescendant(nodeThree, nodeTwo);
            }
            if(isDescendant(nodeTwo,nodeThree))
            {
                return isDescendant(nodeOne ,nodeTwo );
            }
            return false;
        }

        // Whether the `target` is a descendant of the `node`.
        public bool isDescendant(BST node ,BST target)
        {
            if(node == null)
            {
                return false;
            }
            if (node==target)
            {
                return true;
            }
            return target.value<node.value?isDescendant(node.left,target) :isDescendant(node.right,target);
        }
    }
}
