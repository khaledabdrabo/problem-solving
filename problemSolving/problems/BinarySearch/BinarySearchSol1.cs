using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.BinarySearch
{
    class BinarySearchSol1
    {
        // O(log(n)) time | O(1) space
        public static int BinarySearch(int[] array, int target)
        {
            return BinarySearch(array, target, 0, array.Length - 1);
        }
        public static int BinarySearch(int[] array, int target, int left, int right)
        {
            while (left <= right)
            {
                int middle = (left + right) / 2;
                int potentialMatch = array[middle];
                if (target == potentialMatch)
                {
                    return middle;
                }
                else if (target < potentialMatch)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
            return -1;
        }
    }
}
