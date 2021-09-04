using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.StaircaseTraversal
{
    class StaircaseTraversalSol4
    {
        // O(n) time | O(n) space - where n is the height of the staircase
        public int StaircaseTraversal(int height, int maxSteps)
        {
            int currentNumberOfWays = 0;
            List<int> waysToTop = new List<int>();
            waysToTop.Add(1);
            for (int currentHeight = 1; currentHeight < height + 1; currentHeight++)
            {
                int startOfWindow = currentHeight - maxSteps - 1;
                int endOfWindow = currentHeight - 1;
                if (startOfWindow >= 0)
                {
                    currentNumberOfWays -= waysToTop[startOfWindow];
                }
                currentNumberOfWays += waysToTop[endOfWindow];
                waysToTop.Add(currentNumberOfWays);
            }
            return waysToTop[height];
        }

    }
}
