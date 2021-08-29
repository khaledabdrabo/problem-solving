using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.FirstDuplicateValue
{
    class FirstDuplicateValueSol2
    {
        // O(n) time | O(n) space - where n is the length of the input array
        public int FirstDuplicateValue(int[] array)
        {
            HashSet<int> seen = new HashSet<int>();
            foreach (var value in array)
            {
                if (seen.Contains(value)) return value;
                seen.Add(value);
            }
            return -1;
        }
    }
}
