using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.NextGreaterElement
{
    class NextGreaterElementSol1
    {
        // O(n) time | O(n) space - where n is the length of the array
        public int[] NextGreaterElement(int[] array)
        {
            int[] result = new int[array.Length];
            Array.Fill(result, -1);
            Stack<int> stack = new Stack<int>();
            for (int idx = 0; idx < 2 * array.Length; idx++)
            {
                int circularIdx = idx % array.Length;
                while (stack.Count > 0 && array[stack.Peek()] < array[circularIdx])
                {
                    int top = stack.Pop();
                    result[top] = array[circularIdx];
                }
                stack.Push(circularIdx);
            }
            return result;
        }

    }
}
