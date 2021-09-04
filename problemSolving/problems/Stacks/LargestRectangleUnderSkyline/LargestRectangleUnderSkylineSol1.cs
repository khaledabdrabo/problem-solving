using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.LargestRectangleUnderSkyline
{
    class LargestRectangleUnderSkylineSol1
    {
        // O(n^2) time | O(1) space - where n is the number of buildings
        public int LargestRectangleUnderSkyline(List<int> buildings)
        {
            int maxArea = 0;
            for (int pillarIdx = 0; pillarIdx < buildings.Count; pillarIdx++)
            {
                int currentHeight = buildings[pillarIdx];
                int furthestLeft = pillarIdx;
                while (furthestLeft > 0 && buildings[furthestLeft - 1] >= currentHeight)
                {
                    furthestLeft -= 1;
                }
                int furthestRight = pillarIdx;
                while (furthestRight < buildings.Count - 1 &&
                buildings[furthestRight + 1] >= currentHeight)
                {
                    furthestRight += 1;
                }
                int areaWithCurrentBuilding = (furthestRight - furthestLeft + 1) *
                currentHeight;
                maxArea = Math.Max(areaWithCurrentBuilding, maxArea);
            }
            return maxArea;
        }

    }
}
