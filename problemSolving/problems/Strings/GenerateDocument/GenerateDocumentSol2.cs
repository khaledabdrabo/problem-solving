using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.GenerateDocument
{
    class GenerateDocumentSol2
    {
        // O(c * (n + m)) time | O(c) space - where n is the number of characters, m is
        // the length of the document, and c is the number of unique characters in the
        // document
        public bool GenerateDocument(string characters, string document)
        {
            HashSet<char> alreadyCounted = new HashSet<char>();
            for (int idx = 0; idx < document.Length; idx++)
            {
                char character = document[idx];
                if (alreadyCounted.Contains(character))
                {
                    continue;
                }
                int documentFrequency = countcharFrequency(character, document);
                int charactersFrequency = countcharFrequency(character, characters);
                if (documentFrequency > charactersFrequency)
                {
                    return false;
                }
                alreadyCounted.Add(character);
            }
            return true;
        }
        public int countcharFrequency(char character, string target)
        {
            int frequency = 0;
            for (int idx = 0; idx < target.Length; idx++)
            {
                char c = target[idx];
                if (c == character)
                {
                    frequency += 1;
                }
            }
            return frequency;
        }
    }
}
