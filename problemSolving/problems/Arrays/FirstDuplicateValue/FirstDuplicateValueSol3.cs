using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.FirstDuplicateValue
{
    class FirstDuplicateValueSol3
    {
        // O(n) time | O(1) space - where n is the length of the input array
        public int FirstDuplicateValue(int[] array)
        {
            foreach (var value in array)
            {
                int absValue = Math.Abs(value);
                if (array[absValue - 1] < 0) return absValue;
                array[absValue - 1] *= -1;
            }
            return -1;
        }

    }
}
