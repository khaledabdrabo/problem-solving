using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.NumberOfWaysToTraverseGraph
{
    class NumberOfWaysToTraverseGraphSol3
    {
        // O(n + m) time | O(1) space - where n is
        // the width of the graph and m is the height
        public int NumberOfWaysToTraverseGraph(int width, int height)
        {
            int xDistanceToCorner = width - 1;
            int yDistanceToCorner = height - 1;
            // The number of permutations of right and down movements
            // is the number of ways to reach the bottom right corner.
            int numerator = factorial(xDistanceToCorner + yDistanceToCorner);
            int denominator = factorial(xDistanceToCorner) * factorial(yDistanceToCorner);
            return numerator / denominator;
        }
        public int factorial(int num)
        {
            int result = 1;
            for (int n = 2; n < num + 1; n++)
            {
                result *= n;
            }
            return result;
        }

    }
}
