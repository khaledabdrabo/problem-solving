using problemSolving.problems;
using System;
using System.Collections.Generic;

namespace problemSolving
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Validate subsequence
            //var res1 = ValidateSequence.IsValidSubsequence1(new int[] { 5, 1, 22, 25, 6, -1, 8, 10 }, new int[] { 1, 6, -1, 10 });
            //Console.WriteLine(res1);
            //var res2 = ValidateSequence.IsValidSubsequence2(new int[] { 5, 1, 22, 25, 6, -1, 8, 10 }, new int[] { 1, 6, -1, 10 });
            //Console.WriteLine(res2);
            #endregion
            //var res=SmallestDifference.GetSmallestDifferenceItems(new int[] {-1,5,10,20,28,3 },new int[] {26,134,135,15,17 });
            //Console.WriteLine(res[0]+" "+res[1]);
            #region shiftElementToBottomArray
            //var list = ShiftItemTolistBottom.ShiftItem(new System.Collections.Generic.List<int>() { 1, 2, 3, 3, 2, 2, 6, 7, 8, 2 }, 3);
            //var list1 = ShiftItemTolistBottom.ShiftItem(new System.Collections.Generic.List<int>() { 2, 1, 4, 2, 4, 2, 4, 7, 8, 2 }, 4);
            //var list2 = ShiftItemTolistBottom.ShiftItem(new System.Collections.Generic.List<int>() { 8, 4, 8, 4, 2, 8, 6, 2, 8, 2 }, 8);
            //var list3 = ShiftItemTolistBottom.ShiftItem(new System.Collections.Generic.List<int>() { }, 8);
            #endregion
            #region monotonic array
            //var r=MonotonicArray.IsMonotonic(new int[] {1,2,3,4,5,6,7 });
            //var r2=MonotonicArray.IsMonotonic(new int[] {-1,-2,-3,-4,-5,-6,-7 });
            //var r3=MonotonicArray.IsMonotonic(new int[] { 1, 2, 3, 4, 3, 2, 1 });
            //var r4=MonotonicArray.IsMonotonic(new int[] { 1, 1, 2, 3, 4, 5, 5, 5, 6, 7, 8, 8, 9, 10, 11 });
            #endregion
            #region spiralTraverse
            //var arr = new int[3,4] {
            // {1,2,3,4 },
            // {10,11,12,5 },
            // {9,8,7,6 }
            //};
            //var arr = new int[4, 4] {
            // {1,2,3,4 },
            // {12,13,14,5 },
            // {11,16,15,6 },
            // {10,9,8,7}
            //};
            //SpiralTraverse2.SpiralTraverse(arr);
            #endregion
            #region LongestPeak
            //var result=LongestPeakProblem.LongestPeak(new int[] {1,2,3,3,4,0,10,6,5,-1,-3,2,3 });
            //var result1=LongestPeakProblem.LongestPeak(new int[] { 5, 4, 3, 2, 1, 2, 10, 12, -3, 5, 6, 7, 10 });
            //var result1=LongestPeakProblem.LongestPeak(new int[] { 1, 2, 3, 3, 2, 1 });
            #endregion
            #region ValidateBST
            //var tree = new Node()
            //{
            //    Left = new Node()
            //    {
            //        Left = new Node()
            //        {
            //            Left = new Node()
            //            {
            //                Left = null,
            //                Right = null,
            //                Value = 1
            //            },
            //            Right = null,
            //            Value = 2
            //        },
            //        Right = new Node()
            //        {
            //            Left = null,
            //            Right = null,
            //            Value=5

            //        },
            //        Value = 5
            //    },
            //    Right = new Node()
            //    {
            //        Value = 15,
            //        Left = new Node()
            //        {
            //            Value = 13,
            //            Left = null,
            //            Right = new Node()
            //            {
            //                Value=14,
            //                Left=null,
            //                Right=null
            //            }
            //        },
            //        Right = new Node() { Value = 22, Left = null,Right=null }
            //    },
            //    Value = 10

            //};
            //var result=ValidateBST.CheckBST(tree);
            #endregion
            #region PreOrderBST
            //var result =ReconstructPreOrderBST.ReconstructBst(new System.Collections.Generic.List<int>() { 10,4,2,1,5,17,19,18});
            #endregion
            #region getSmallerThan
            //var result=RightSmallerThan.getCountRightSmallerThan(new List<int>() {8,5,11,-1,3,4,2 });
            #endregion
            #region SameBST
            //var result=SameBst.SameBst1(new List<int>(){10,15,8,12,94,81,5,2,11},new List<int>() {10,8,5,15,2,12,11,94,81});
            #endregion
            #region ConstructBst
            var x=ConstructBst.CreateBst();
            #endregion


        }
    }
}
