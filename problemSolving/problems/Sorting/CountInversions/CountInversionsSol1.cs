using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.CountInversions
{
    class CountInversionsSol1
    {
        // O(nlogn) time | O(n) space - where n is the length of the array
        public int CountInversions(int[] array)
        {
            return countSubArrayInversions(array, 0, array.Length);
        }
        public int countSubArrayInversions(int[] array, int start, int end)
        {
            if (end - start <= 1)
            {
                return 0;
            }
            int middle = start + (end - start) / 2;
            int leftInversions = countSubArrayInversions(array, start, middle);
            int rightInversions = countSubArrayInversions(array, middle, end);
            int mergedArrayInversions = mergeSortAndCountInversions(array, start, middle, end);
            return leftInversions + rightInversions + mergedArrayInversions;
        }
        public int mergeSortAndCountInversions(int[] array, int start, int middle, int end)
        {
            List<int> sortedArray = new List<int>();
            int left = start;
            int right = middle;
            int inversions = 0;
            while (left < middle && right < end)
            {
                if (array[left] <= array[right])
                {
                    sortedArray.Add(array[left]);
                    left += 1;
                }
                else
                {
                    inversions += middle - left;
                    sortedArray.Add(array[right]);
                    right += 1;
                }
            }
            for (int idx = left; idx < middle; idx++)
            {
                sortedArray.Add(array[idx]);
            }
            for (int idx = right; idx < end; idx++)
            {
                sortedArray.Add(array[idx]);
            }
            for (int idx = 0; idx < sortedArray.Count; idx++)
            {
                int num = sortedArray[idx];
                array[start + idx] = num;
            }
            return inversions;
        }
    }
}
