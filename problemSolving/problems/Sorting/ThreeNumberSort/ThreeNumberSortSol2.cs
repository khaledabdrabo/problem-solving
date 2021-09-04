using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.ThreeNumberSort
{
    class ThreeNumberSortSol2
    {
        // O(n) time | O(1) space - where n is the length of the array
        public int[] ThreeNumberSort(int[] array, int[] order)
        {
            int firstValue = order[0];
            int thirdValue = order[2];
            int firstIdx = 0;
            for (int idx = 0; idx < array.Length; idx++)
            {
                if (array[idx] == firstValue)
                {
                    swap(firstIdx, idx, array);
                    firstIdx += 1;
                }
            }
            int thirdIdx = array.Length - 1;
            for (int idx = array.Length - 1; idx >= 0; idx--)
            {
                if (array[idx] == thirdValue)
                {
                    swap(thirdIdx, idx, array);
                    thirdIdx -= 1;
                }
            }
            return array;
        }
        public void swap(int i, int j, int[] array)
        {
            int temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }

    }
}
