using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.LongestBalancedSubstring
{
    class LongestBalancedSubstringSol2
    {
        // O(n) time | O(n) space - where n is the length of the input string
        public int LongestBalancedSubstring(string str)
        {
            int maxLength = 0;
            Stack<int> idxStack = new Stack<int>();
            idxStack.Push(-1);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    idxStack.Push(i);
                }
                else
                {
                    idxStack.Pop();
                    if (idxStack.Count == 0)
                    {
                        idxStack.Push(i);
                    }
                    else
                    {
                        int balancedSubstringStartIdx = idxStack.Peek();
                        int currentLength = i - balancedSubstringStartIdx;
                        maxLength = Math.Max(maxLength, currentLength);
                    }
                }
            }
            return maxLength;
        }
    }
}
