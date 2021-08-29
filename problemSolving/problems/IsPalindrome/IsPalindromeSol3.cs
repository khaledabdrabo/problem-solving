﻿using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.IsPalindrome
{
    class IsPalindromeSol3
    {
        // O(n) time | O(n) space
        public static bool IsPalindrome(string str)
        {
            return IsPalindrome(str, 0);
        }
        public static bool IsPalindrome(string str, int i)
        {
            int j = str.Length - 1 - i;
            return i >= j ? true : str[i] == str[j] && IsPalindrome(str, i + 1);
        }
    }
}
