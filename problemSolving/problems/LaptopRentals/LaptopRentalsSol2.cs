using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.LaptopRentals
{
    class LaptopRentalsSol2
    {
        // O(nlog(n)) time | O(n) space - where n is the number of times
        public int LaptopRentals(List<List<int>> times)
        {
            if (times.Count == 0)
            {
                return 0;
            }
            int usedLaptops = 0;
            List<int> startTimes = new List<int>();
            List<int> endTimes = new List<int>();
            foreach (var interval in times)
            {
                startTimes.Add(interval[0]);
                endTimes.Add((interval[1]));
            }
            startTimes.Sort();
            endTimes.Sort();
            int startIterator = 0;
            int endIterator = 0;
            while (startIterator < times.Count)
            {
                if (startTimes[startIterator] >= endTimes[endIterator])
                {
                    usedLaptops -= 1;
                    endIterator += 1;
                }
                usedLaptops += 1;
                startIterator += 1;
            }
            return usedLaptops;
        }

    }
}
