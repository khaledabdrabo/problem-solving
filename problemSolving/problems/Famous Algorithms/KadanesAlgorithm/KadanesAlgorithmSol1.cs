using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.KadanesAlgorithm
{

    public class KadanesAlgorithmSol1
    {
        // O(n) time | O(1) space
        public static int KadanesAlgorithm(int[] array)
        {
            int maxEndingHere = array[0];
            int maxSoFar = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                int num = array[i];
                maxEndingHere = Math.Max(num, maxEndingHere + num);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }
            return maxSoFar;
        }
    }
}
