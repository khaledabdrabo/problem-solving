using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.ReverseWordsInString
{
    class ReverseWordsInStringSol2
    {
        // O(n) time | O(n) space - where n is the length of the string
        public string ReverseWordsInString(string str)
        {
            char[] characters = str.ToCharArray();
            reverseListRange(characters, 0, characters.Length - 1);
            int startOfWord = 0;
            while (startOfWord < characters.Length)
            {
                int endOfWord = startOfWord;
                while (endOfWord < characters.Length && characters[endOfWord] != ' ')
                {
                    endOfWord += 1;
                }
                reverseListRange(characters, startOfWord, endOfWord - 1);
                startOfWord = endOfWord + 1;
            }
            return new string(characters);
        }
        public char[] reverseListRange(char[] list, int start, int end)
        {
            while (start < end)
            {
                char temp = list[start];
                list[start] = list[end];
                list[end] = temp;
                start += 1;
                end -= 1;
            }
            return list;
        }
    }
}
