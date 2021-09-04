using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.LongestBalancedSubstring
{
    class LongestBalancedSubstringSol1
    {
        // O(n^3) time | O(n) space - where n is the length of the input string
        public int LongestBalancedSubstring(string str)
        {
            int maxLength = 0;
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i + 2; j < str.Length + 1; j += 2)
                {
                    if (isBalanced(str.Substring(i, j - i)))
                    {
                        int currentLength = j - i;
                        maxLength = Math.Max(maxLength, currentLength);
                    }
                }
            }
            return maxLength;
        }
        public bool isBalanced(string str)
        {
            Stack<char> openParensStack = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c == '(')
                {
                    openParensStack.Push('(');
                }
                else if (openParensStack.Count > 0)
                {
                    openParensStack.Pop();
                }
                else
                {
                    return false;
                }
            }
            return openParensStack.Count == 0;
        }
    }
}
