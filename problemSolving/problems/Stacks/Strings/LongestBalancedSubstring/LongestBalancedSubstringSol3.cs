using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.LongestBalancedSubstring
{
    class LongestBalancedSubstringSol3
    {
        // O(n) time | O(1) space - where n is the length of the input string
        public int LongestBalancedSubstring(string str)
        {
            int maxLength = 0;
            int openingCount = 0;
            int closingCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c == '(')
                {
                    openingCount += 1;
                }
                else
                {
                    closingCount += 1;
                }
                if (openingCount == closingCount)
                {
                    maxLength = Math.Max(maxLength, closingCount * 2);
                }
                else if (closingCount > openingCount)
                {
                    openingCount = 0;
                    closingCount = 0;
                }
            }
            openingCount = 0;
            closingCount = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                char c = str[i];
                if (c == '(')
                {
                    openingCount += 1;
                }
                else
                {
                    closingCount += 1;
                }
                if (openingCount == closingCount)
                {
                    maxLength = Math.Max(maxLength, openingCount * 2);
                }
                else if (openingCount > closingCount)
                {
                    openingCount = 0;
                    closingCount = 0;
                }
            }
            return maxLength;
        }

    }
}
