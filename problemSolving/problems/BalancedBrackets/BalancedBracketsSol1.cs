﻿using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.BalancedBrackets
{
    class BalancedBracketsSol1
    {
        // O(n) time | O(n) space
        public static bool BalancedBrackets(string str)
        {
            string openingBrackets = "([{";
            string closingBrackets = ")]}";
            Dictionary<char, char> matchingBrackets = new Dictionary<char, char>();
            matchingBrackets.Add(')', '(');
            matchingBrackets.Add(']', '[');
            matchingBrackets.Add('}', '{');
            List<char> stack = new List<char>();
            for (int i = 0; i < str.Length; i++)
            {
                char letter = str[i];
                if (openingBrackets.IndexOf(letter) != -1)
                {
                    stack.Add(letter);
                }
                else if (closingBrackets.IndexOf(letter) != -1)
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    if (stack[stack.Count - 1] == matchingBrackets[letter])
                    {
                        stack.RemoveAt(stack.Count - 1);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
    }
}
