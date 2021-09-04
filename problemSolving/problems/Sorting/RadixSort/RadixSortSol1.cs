using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problemSolving.problems.RadixSort
{
    class RadixSortSol1
    {
        // O(d * (n + b)) time | O(n + b) space - where n is the length of the input array,
        // d is the max number of digits, and b is the base of the numbering system used
        public List<int> RadixSort(List<int> array)
        {
            if (array.Count == 0)
            {
                return array;
            }
            int maxNumber = array.Max();
            int digit = 0;
            while ((maxNumber / Math.Pow(10, digit)) > 0)
            {
                countingSort(array, digit);
                digit += 1;
            }
            return array;
        }
        public void countingSort(List<int> array, int digit)
        {
            int[] sortedArray = new int[array.Count];
            int[] countArray = new int[10];
            int digitColumn = (int)Math.Pow(10, digit);
            foreach (var num in array)
            {
                int countIndex = (num / digitColumn) % 10;
                countArray[countIndex] += 1;
            }
            for (int idx = 1; idx < 10; idx++)
            {
                countArray[idx] += countArray[idx - 1];
            }
            for (int idx = array.Count - 1; idx > -1; idx--)
            {
                int countIndex = (array[idx] / digitColumn) % 10;
                countArray[countIndex] -= 1;
                int sortedIndex = countArray[countIndex];
                sortedArray[sortedIndex] = array[idx];
            }
            for (int idx = 0; idx < array.Count; idx++)
            {
                array[idx] = sortedArray[idx];
            }
        }
    }
}
