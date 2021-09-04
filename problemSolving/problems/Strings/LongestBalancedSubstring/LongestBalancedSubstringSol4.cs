using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.LongestBalancedSubstring
{
    class LongestBalancedSubstringSol4
    {
        // O(n) time | O(1) space - where n is the length of the input string
        public int LongestBalancedSubstring(string str)
        {
            return Math.Max(
            GetLongestBalancedInDirection(str, true),
            GetLongestBalancedInDirection(str, false)
            );
        }
        public int GetLongestBalancedInDirection(string str, bool leftToRight)
        {
            char openingParens = leftToRight ? '(' : ')';
            int startIdx = leftToRight ? 0 : str.Length - 1;
            int step = leftToRight ? 1 : -1;
            int maxLength = 0;
            int openingCount = 0;
            int closingCount = 0;
            int idx = startIdx;
            while (idx >= 0 && idx < str.Length)
            {
                char c = str[idx];
                if (c == openingParens)
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
                idx += step;
            }
            return maxLength;
        }

    }
}
