using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.GetNthFib
{
    class GetNthFibSol2
    {
        // O(n) time | O(n) space
        public static int GetNthFib(int n)
        {
            Dictionary<int, int> memoize = new Dictionary<int, int>();
            memoize.Add(1, 0);
            memoize.Add(2, 1);
            return GetNthFib(n, memoize);
        }
        public static int GetNthFib(int n, Dictionary<int, int> memoize)
        {
            if (memoize.ContainsKey(n))
            {
                return memoize[n];
            }
            else
            {
                memoize.Add(n, GetNthFib(n - 1, memoize) + GetNthFib(n - 2, memoize));
                return memoize[n];
            }
        }

    }
}
