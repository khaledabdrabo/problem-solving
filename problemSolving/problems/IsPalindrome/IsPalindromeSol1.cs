using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.IsPalindrome
{
    class IsPalindromeSol1
    {
        // O(n^2) time | O(n) space
        public static bool IsPalindrome(string str)
        {
            string reversedstring = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reversedstring += str[i];
            }
            return str.Equals(reversedstring);
        }

    }
}
