using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.NumberOfWaysToTraverseGraph
{
    class NumberOfWaysToTraverseGraphSol2
    {
        // O(n * m) time | O(n * m) space - where n
        // is the width of the graph and m is the height
        public int NumberOfWaysToTraverseGraph(int width, int height)
        {
            int[,] numberOfWays = new int[height + 1, width + 1];
            for (int widthIdx = 1; widthIdx < width + 1; widthIdx++)
            {
                for (int heightIdx = 1; heightIdx < height + 1; heightIdx++)
                {
                    if (widthIdx == 1 || heightIdx == 1)
                    {
                        numberOfWays[heightIdx, widthIdx] = 1;
                    }
                    else
                    {
                        int waysLeft = numberOfWays[heightIdx, widthIdx - 1];
                        int waysUp = numberOfWays[heightIdx - 1, widthIdx];
                        numberOfWays[heightIdx, widthIdx] = waysLeft + waysUp;
                    }
                }
            }
            return numberOfWays[height, width];
        }

    }
}
