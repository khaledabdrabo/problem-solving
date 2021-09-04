using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.LargestRectangleUnderSkyline
{
    class LargestRectangleUnderSkylineSol2
    {
        // O(n) time | O(n) space - where n is the number of buildings
        public int LargestRectangleUnderSkyline(List<int> buildings)
        {
            Stack<int> pillarIndices = new Stack<int>();
            int maxArea = 0;
            List<int> extendedBuildings = new List<int>(buildings);
            extendedBuildings.Add(0);
            for (int idx = 0; idx < extendedBuildings.Count; idx++)
            {
                int height = extendedBuildings[idx];
                while (pillarIndices.Count != 0 &&
                extendedBuildings[pillarIndices.Peek()] >= height)
                {
                    int pillarHeight = extendedBuildings[pillarIndices.Pop()];
                    int width =
                    (pillarIndices.Count == 0) ? idx : idx - pillarIndices.Peek() - 1;
                    maxArea = Math.Max(width * pillarHeight, maxArea);
                }
                pillarIndices.Push(idx);
            }
            return maxArea;
        }
    }
}
