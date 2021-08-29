using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problemSolving.problems.groupAnagrams
{
    class groupAnagramsSol2
    {
        // O(w * n * log(n)) time | O(wn) space - where w is the number of words and n is the length
        public static List<List<string>> groupAnagrams(List<string> words)
        {
            Dictionary<string,
            List<string>> anagrams = new Dictionary<string, List<string>>();
            foreach (string word in words)
            {
                char[] charArray = word.ToCharArray();
                Array.Sort(charArray);
                string sortedWord = new String(charArray);
                if (anagrams.ContainsKey(sortedWord))
                {
                    anagrams[sortedWord].Add(word);
                }
                else
                {
                    anagrams[sortedWord] = new List<string>(){
                    word
                     };
                }
            }
            return anagrams.Values.ToList();
        }


    }
}
