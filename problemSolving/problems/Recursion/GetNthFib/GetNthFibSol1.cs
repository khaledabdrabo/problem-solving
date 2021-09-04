using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.GetNthFib
{
    class GetNthFibSol1
    {
        // O(2^n) time | O(n) space
        public static int GetNthFib(int n)
        {
            if (n == 2)
            {
                return 1;
            }
            else if (n == 1)
            {
                return 0;
            }
            else
            {
                return GetNthFib(n - 1) + GetNthFib(n - 2);
            }
        }

    }
}
