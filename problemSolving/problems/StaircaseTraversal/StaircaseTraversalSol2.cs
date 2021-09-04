using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.StaircaseTraversal
{
    class StaircaseTraversalSol2
    {
        // O(k^n) time | O(n) space - where n is the height of the staircase and k is the number of
        public int StaircaseTraversal(int height, int maxSteps)
        {
            return numberOfWaysToTop(height, maxSteps);
        }
        public int numberOfWaysToTop(int height, int maxSteps)
        {
            if (height <= 1)
            {
                return 1;
            }
            int numberOfWays = 0;
            for (int step = 1; step < Math.Min(maxSteps, height) + 1; step++)
            {
                numberOfWays += numberOfWaysToTop(height - step, maxSteps);
            }
            return numberOfWays;
        }
    }
}
