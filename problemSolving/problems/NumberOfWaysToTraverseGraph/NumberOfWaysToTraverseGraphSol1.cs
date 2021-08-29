using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.NumberOfWaysToTraverseGraph
{
    class NumberOfWaysToTraverseGraphSol1
    {
        // O(2^(n + m)) time | O(n + m) space - where n
        // is the width of the graph and m is the height
        public int NumberOfWaysToTraverseGraph(int width, int height)
        {
            if (width == 1 || height == 1)
            {
                return 1;
            }
            return NumberOfWaysToTraverseGraph(width - 1, height) + NumberOfWaysToTraverseGraph(
            width, height - 1);
        }
    }
}
