using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.MaxSubsetSumNoAdjacent
{
    class MaxSubsetSumNoAdjacentSol2
    {
        // O(n) time | O(1) space
        public static int MaxSubsetSumNoAdjacent(int[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }
            else if (array.Length == 1)
            {
                return array[0];
            }
            int second = array[0];
            int first = Math.Max(array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
            {
                int current = Math.Max(first, second + array[i]);
                second = first;
                first = current;
            }
            return first;
        }

    }
}
