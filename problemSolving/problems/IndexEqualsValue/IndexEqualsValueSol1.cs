using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.IndexEqualsValue
{
    class IndexEqualsValueSol1
    {
        // O(log(n)) time | O(log(n)) space - where n is the length of the input array
        public int IndexEqualsValue(int[] array)
        {
            return indexEqualsValueHelper(array, 0, array.Length - 1);
        }
        public int indexEqualsValueHelper(int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex)
            {
                return -1;
            }
            int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;
            int middleValue = array[middleIndex];
            if (middleValue < middleIndex)
            {
                return indexEqualsValueHelper(array, middleIndex + 1, rightIndex);
            }
            else if ((middleValue == middleIndex) && (middleIndex == 0))
            {
                return middleIndex;
            }
            else if ((middleValue == middleIndex) &&
          (array[middleIndex - 1] < (middleIndex - 1)))
            {
                return middleIndex;
            }
            else
            {
                return indexEqualsValueHelper(array, leftIndex, middleIndex - 1);
            }
        }

    }
}
