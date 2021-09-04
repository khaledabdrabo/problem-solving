﻿using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.FindThreeLargestNumbers
{
    class FindThreeLargestNumbersSol1
    {
        // O(n) time | O(1) space
        public static int[] FindThreeLargestNumbers(int[] array)
        {
            int[] threeLargest = { Int32.MinValue, Int32.MinValue, Int32.MinValue };
            foreach (int num in array)
            {
                updateLargest(threeLargest, num);
            }
            return threeLargest;
        }
        public static void updateLargest(int[] threeLargest, int num)
        {
            if (num > threeLargest[2])
            {
                shiftAndUpdate(threeLargest, num, 2);
            }
            else if (num > threeLargest[1])
            {
                shiftAndUpdate(threeLargest, num, 1);
            }
            else if (num > threeLargest[0])
            {
                shiftAndUpdate(threeLargest, num, 0);
            }
        }
        public static void shiftAndUpdate(int[] array, int num, int idx)
        {
            for (int i = 0; i <= idx; i++)
            {
                if (i == idx)
                {
                    array[i] = num;
                }
                else
                {
                    array[i] = array[i + 1];
                }
            }
        }

    }
}
