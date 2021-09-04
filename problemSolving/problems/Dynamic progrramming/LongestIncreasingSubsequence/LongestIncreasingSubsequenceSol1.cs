﻿using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.LongestIncreasingSubsequence
{
    class LongestIncreasingSubsequenceSol1
    {
        // O(n^2) time | O(n) space
        public static List<int> LongestIncreasingSubsequence(int[] array)
        {
            int[] sequences = new int[array.Length];
            Array.Fill(sequences, Int32.MinValue);
            int[] lengths = new int[array.Length];
            Array.Fill(lengths, 1);
            int maxLengthIdx = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int currentNum = array[i];
                for (int j = 0; j < i; j++)
                {
                    int otherNum = array[j];
                    if (otherNum < currentNum && lengths[j] + 1 >= lengths[i])
                    {
                        lengths[i] = lengths[j] + 1;
                        sequences[i] = j;
                    }
                }
                if (lengths[i] >= lengths[maxLengthIdx])
                {
                    maxLengthIdx = i;
                }
            }
            return buildSequence(array, sequences, maxLengthIdx);
        }
        public static List<int> buildSequence(int[] array, int[] sequences, int currentIdx)
        {
            List<int> sequence = new List<int>();
            while (currentIdx != Int32.MinValue)
            {
                sequence.Insert(0, array[currentIdx]);
                currentIdx = sequences[currentIdx];
            }
            return sequence;
        }
    }
}
