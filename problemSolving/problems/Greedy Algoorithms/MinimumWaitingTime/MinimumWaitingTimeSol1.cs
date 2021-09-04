using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.MinimumWaitingTime
{
    class MinimumWaitingTimeSol1
    {
        // O(nlogn) time | O(1) space - where n is the number of queries
        public int MinimumWaitingTime(int[] queries)
        {
            Array.Sort(queries);
            int totalWaitingTime = 0;
            for (int idx = 0; idx < queries.Length; idx++)
            {
                int duration = queries[idx];
                int queriesLeft = queries.Length - (idx + 1);
                totalWaitingTime += duration * queriesLeft;
            }
            return totalWaitingTime;
        }
    }
}
