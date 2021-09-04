using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.StaircaseTraversal
{
    class StaircaseTraversalSol3
    {
        // O(n * k) time | O(n) space - where n is the height of the staircase and k is the number o
        public int StaircaseTraversal(int height, int maxSteps)
        {
            int[] waysToTop = new int[height + 1];
            waysToTop[0] = 1;
            waysToTop[1] = 1;
            for (int currentHeight = 2; currentHeight < height + 1; currentHeight++)
            {
                int step = 1;
                while (step <= maxSteps && step <= currentHeight)
                {
                    waysToTop[currentHeight] = waysToTop[currentHeight] +
                    waysToTop[currentHeight - step];
                    step += 1;
                }
            }
            return waysToTop[height];
        }
    }
}
