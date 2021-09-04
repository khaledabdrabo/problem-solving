using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems
{
    public static class ValidateSequence
    {
        public static bool IsValidSubsequence1(int[] array, int[] sequence)
        {
            int arrIndex = 0;
            int seqIndex = 0;
            while (arrIndex < array.Length && seqIndex < sequence.Length)
            {
                if (array[arrIndex] == sequence[seqIndex])
                {
                    seqIndex++;
                }
                arrIndex++;

            }
            return seqIndex == sequence.Length;
        }

        public static bool IsValidSubsequence2(int[] array, int[] sequence)
        {
            int seqIndex = 0;
            foreach (var item in array)
            {
                if (seqIndex == sequence.Length)
                {
                    break;
                }
                if (sequence[seqIndex] == item)
                {
                    seqIndex++;
                }
            }
            
            return seqIndex == sequence.Length;
        }
    }
}
