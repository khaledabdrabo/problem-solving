﻿using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.WaterArea
{
    class WaterAreaSol2
    {
        // O(n) time | O(1) space - where n is the length of the input array
        public static int WaterArea(int[] heights)
        {
            if (heights.Length == 0) return 0;
            var leftIdx = 0;
            var rightIdx = heights.Length - 1;
            var leftMax = heights[leftIdx];
            var rightMax = heights[rightIdx];
            var surfaceArea = 0;
            while (leftIdx < rightIdx)
            {
                if (heights[leftIdx] < heights[rightIdx])
                {
                    leftIdx++;
                    leftMax = Math.Max(leftMax, heights[leftIdx]);
                    surfaceArea += leftMax - heights[leftIdx];
                }
                else
                {
                    rightIdx--;
                    rightMax = Math.Max(rightMax, heights[rightIdx]);
                    surfaceArea += rightMax - heights[rightIdx];
                }
            }
            return surfaceArea;
        }

    }
}
