using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems
{
    public static class LongestPeakProblem
    {
        public static int LongestPeak(int[] array)
        {
            if (array.Length == 0)
                return -1;
            var first = 0;
            var mid = 1;
            var last = 2;
            bool isBigger = true;
            //bool found = false;
            while (last<array.Length)
            {
                for (int i = last+1; i < array.Length; i++)
                {
                    if (array[last] < array[i])
                    {
                        isBigger = false;
                        break;
                    }
                }
                if (!isBigger || array[first] > array[mid] || array[mid] < array[last])
                {
                    first++;
                    mid++;
                    last++;
                    isBigger = true;
                }
                else if(array[first] < array[mid] && array[mid] > array[last] && isBigger)
                {
                    return array[last];
                }

            }
            // Write your code here.
            return -1;
        }
    }
}
