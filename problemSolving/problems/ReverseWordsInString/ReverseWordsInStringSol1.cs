using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.ReverseWordsInString
{
    class ReverseWordsInStringSol1
    {
        // O(n) time | O(n) space - where n is the length of the string
        public string ReverseWordsInString(string str)
        {
            List<string> words = new List<string>();
            int startOfWord = 0;
            for (int idx = 0; idx < str.Length; idx++)
            {
                char character = str[idx];
                if (character == ' ')
                {
                    words.Add(str.Substring(startOfWord, idx - startOfWord));
                    startOfWord = idx;
                }
                else if (str[startOfWord] == ' ')
                {
                    words.Add(" ");
                    startOfWord = idx;
                }
            }
            words.Add(str.Substring(startOfWord));
            words.Reverse();
            return String.Join("", words);
        }
    }
}
