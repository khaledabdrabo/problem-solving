﻿using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.NextGreaterElement
{
    class NextGreaterElementSol2
    {
        // O(n) time | O(n) space - where n is the length of the array
        public int[] NextGreaterElement(int[] array)
        {
            int[] result = new int[array.Length];
            Array.Fill(result, -1);
            Stack<int> stack = new Stack<int>();
            for (int idx = 2 * array.Length - 1; idx >= 0; idx--)
            {
                int circularIdx = idx % array.Length;
                while (stack.Count > 0)
                {
                    if (stack.Peek() <= array[circularIdx])
                    {
                        stack.Pop();
                    }
                    else
                    {
                        result[circularIdx] = stack.Peek();
                        break;
                    }
                }
                stack.Push(array[circularIdx]);
            }
            return result;
        }
    }
}
