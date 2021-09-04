using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.NumberOfBinaryTreeTopologies
{
    class NumberOfBinaryTreeTopologiesSol1
    {
        // Upper Bound: O((n*(2n)!)/(n!(n+1)!)) time | O(n) space
        public static int NumberOfBinaryTreeTopologies(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            int numberOfTrees = 0;
            for (int leftTreeSize = 0; leftTreeSize < n; leftTreeSize++)
            {
                int rightTreeSize = n - 1 - leftTreeSize;
                int numberOfLeftTrees = NumberOfBinaryTreeTopologies(leftTreeSize);
                int numberOfRightTrees = NumberOfBinaryTreeTopologies(rightTreeSize);
                numberOfTrees += numberOfLeftTrees * numberOfRightTrees;
            }
            return numberOfTrees;
        }
    }
}
