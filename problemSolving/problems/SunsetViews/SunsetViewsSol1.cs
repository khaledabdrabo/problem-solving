using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.SunsetViews
{
    class SunsetViewsSol1
    {
        // O(n) time | O(n) space - where n is the length of the input array
        public List<int> SunsetViews(int[] buildings, string direction)
        {
            List<int> buildingsWithSunsetViews = new List<int>();
            int startIdx = buildings.Length - 1;
            int step = -1;
            if (direction.Equals("WEST"))
            {
                startIdx = 0;
                step = 1;
            }
            int idx = startIdx;
            int runningMaxHeight = 0;
            while (idx >= 0 && idx < buildings.Length)
            {
                int buildingHeight = buildings[idx];
                if (buildingHeight > runningMaxHeight)
                {
                    buildingsWithSunsetViews.Add(idx);
                }
                runningMaxHeight = Math.Max(runningMaxHeight, buildingHeight);
                idx += step;
            }
            if (direction.Equals("EAST"))
            {
                buildingsWithSunsetViews.Reverse();
            }
            return buildingsWithSunsetViews;
        }

    }
}
