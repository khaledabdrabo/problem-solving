using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.MaximizeExpression
{
    class MaximizeExpressionSol1
    {
        // O(n^4) time | O(1) space - where n is the length of the array
        public int MaximizeExpression(int[] array)
        {
            if (array.Length < 4)
            {
                return 0;
            }
            int maximumValueFound = Int32.MinValue;
            for (int a = 0; a < array.Length; a++)
            {
                int aValue = array[a];
                for (int b = a + 1; b < array.Length; b++)
                {
                    int bValue = array[b];
                    for (int c = b + 1; c < array.Length; c++)
                    {
                        int cValue = array[c];
                        for (int d = c + 1; d < array.Length; d++)
                        {
                            int dValue = array[d];
                            int expressionValue = evaluateExpression(aValue,
                            bValue,
                            cValue,
                            dValue);
                            maximumValueFound = Math.Max(expressionValue,
                            maximumValueFound);
                        }
                    }
                }
            }
            return maximumValueFound;
        }
        public int evaluateExpression(int a, int b, int c, int d)
        {
            return a - b + c - d;
        }

    }
}
