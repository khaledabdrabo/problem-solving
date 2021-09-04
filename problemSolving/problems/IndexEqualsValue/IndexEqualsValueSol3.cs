using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.IndexEqualsValue
{
    class IndexEqualsValueSol3
    {
        // O(n) time | O(1) space - where n is the length of the input array
        public int IndexEqualsValue(int[] array)
        {
            for (int index = 0; index < array.Length; index++)
            {
                int value = array[index];
                if (index == value)
                {
                    return index;
                }
            }
            return -1;
        }


    }
}
