using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.FirstDuplicateValue
{
    class FirstDuplicateValueSol1
    {
        // O(n^2) time | O(1) space - where n is the length of the input array
        public int FirstDuplicateValue(int[] array)
        {
            int minimumSecondIndex = array.Length;
            for (int i = 0; i < array.Length; i++)
            {
                int value = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    int valueToCompare = array[j];
                    if (value == valueToCompare)
                    {
                        minimumSecondIndex = Math.Min(minimumSecondIndex, j);
                    }
                }
            }
            if (minimumSecondIndex == array.Length)
            {
                return -1;
            }
            return array[minimumSecondIndex];
        }


    }
}
