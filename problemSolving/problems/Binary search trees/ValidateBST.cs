using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems
{
    public class Node
    {
        
        public Node? left { get; set; }
        public Node? right { get; set; }
        public int value { get; set; }
    }
    public static class  ValidateBST
    {
        //public static bool CheckBST(Node tree)
        //{

        //        if (tree.left != null && tree.left.value > tree.value)
        //        {
        //            return false;

        //        }
        //        if (tree.right != null && tree.right.value < tree.value)
        //        {
        //            return false;

        //        }
        //        if (tree.left != null  && !CheckBST(tree.left))
        //        {
        //            return false;

        //        }
        //        if (tree.right != null  && !CheckBST(tree.right))
        //        {

        //            return false;

        //        }


        //    return true;
        //}
        public static bool ValidateBst(BST tree)
        {
            return ValidateBst(tree, Int32.MinValue, Int32.MaxValue);
        }
        public static bool ValidateBst(BST tree, int minValue, int maxValue)
        {
            if (tree.value < minValue || tree.value >= maxValue)
            {
                return false;
            }
            if (tree.left != null && !ValidateBst(tree.left, minValue, tree.value))
            {
                return false;
            }
            if (tree.right != null && !ValidateBst(tree.right, tree.value, maxValue))
            {
                return false;
            }
            return true;
        }
    }
}
