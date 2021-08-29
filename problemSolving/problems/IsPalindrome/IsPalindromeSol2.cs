﻿using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.IsPalindrome
{
    class IsPalindromeSol2
    {
        // O(n) time | O(n) space
        public static bool IsPalindrome(string str)
        {
            StringBuilder reversedstring = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reversedstring.Append(str[i]);
            }
            return str.Equals(reversedstring.ToString());
        }
    }
}
