using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.RunLengthEncoding
{
    class RunLengthEncodingSol1
    {
        // O(n) time | O(n) space - where n is the length of the input string
        public string RunLengthEncoding(string str)
        {
            // The input string is guaranteed to be non-empty,
            // so our first run will be of at least length 1.
            StringBuilder encodedStringChars = new StringBuilder();
            int currentRunLength = 1;
            for (int i = 1; i < str.Length; i++)
            {
                char currentChar = str[i];
                char previousChar = str[i - 1];
                if ((currentChar != previousChar) || (currentRunLength == 9))
                {
                    encodedStringChars.Append(currentRunLength.ToString());
                    encodedStringChars.Append(previousChar);
                    currentRunLength = 0;
                }
                currentRunLength += 1;
            }
            // Handle the last run.
            encodedStringChars.Append(currentRunLength.ToString());
            encodedStringChars.Append(str[str.Length - 1]);
            return encodedStringChars.ToString();
        }
    }
}
