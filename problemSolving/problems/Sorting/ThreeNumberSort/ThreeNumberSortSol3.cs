using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.ThreeNumberSort
{
    class ThreeNumberSortSol3
    {
        // O(n) time | O(1) space - where n is the length of the array
        public int[] ThreeNumberSort(int[] array, int[] order)
        {
            int firstValue = order[0];
            int secondValue = order[1];
            // Keep track of the indices where the values are stored
            int firstIdx = 0;
            int secondIdx = 0;
            int thirdIdx = array.Length - 1;
            while (secondIdx <= thirdIdx)
            {
                int value = array[secondIdx];
                if (value == firstValue)
                {
                    swap(firstIdx, secondIdx, array);
                    firstIdx += 1;
                    secondIdx += 1;
                }
                else if (value == secondValue)
                {
                    secondIdx += 1;
                }
                else
                {
                    swap(secondIdx, thirdIdx, array);
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
