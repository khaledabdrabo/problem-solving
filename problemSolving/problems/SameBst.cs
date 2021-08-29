using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems
{
    public static class SameBst
    {
        public static bool SameBst1(List<int>l1,List<int>l2)
        {
            if (l1.Count==0 && l2.Count==0) return true;
            if (l1[0] != l2[0]) return false;

            List<int> left1 = GetSmaller(l1);
            List<int> left2 = GetSmaller(l2);
            List<int> right1 = GetEqualOrLager(l1);
            List<int> right2 = GetEqualOrLager(l2);
            return SameBst1(left1, left2) && SameBst1(right1, right2);

        }

        private static List<int> GetEqualOrLager(List<int> l1)
        {
            var list = new List<int>();
            for (int i = 1; i < l1.Count; i++)
            {
                if (l1[i] >= l1[0])
                    list.Add(l1[i]);
            }
            return list;
        }

        private static List<int> GetSmaller(List<int> l)
        {
            var list = new List<int>();
            for (int i = 1; i < l.Count; i++)
            {
                if (l[i] < l[0])
                    list.Add(l[i]);
            }
            return list;
        }

        public static bool CheckIfSame(List<int> arr1, List<int> arr2)
        {


            if (arr2.Count != arr1.Count)
                return false;

            arr1.Sort();
            arr2.Sort();

            for (int i = 0; i < arr2.Count; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }

            bool result = CheckIfValueEqualToRootAndLessThanIt(arr1);
            return result;
        }

        private static bool CheckIfValueEqualToRootAndLessThanIt(List<int> arr)
        {
            bool result = CheckIfExistedLessThanRootRoot(arr, 0, arr.Count - 1);
            return result;
        }

        private static bool CheckIfExistedLessThanRootRoot(List<int> arr, int start, int end)
        {

            var rootIndx = (start + end) / 2;
            Console.WriteLine(rootIndx);
            if (rootIndx > 0 && arr[rootIndx - 1] <= arr[rootIndx])
            {
                var left = CheckIfExistedLessThanRootRoot(arr, start, rootIndx - 1);
                var right = CheckIfExistedLessThanRootRoot(arr, rootIndx, end);
                return true;
            }
            return false;


        }
    }
}
