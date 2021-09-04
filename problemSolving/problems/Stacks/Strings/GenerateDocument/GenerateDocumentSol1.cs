using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.GenerateDocument
{
    class GenerateDocumentSol1
    {
        // O(n + m) time | O(c) space - where n is the number of characters, m is
        // the length of the document, and c is the number of unique characters in the
        // characters string
        public bool GenerateDocument(string characters, string document)
        {
            Dictionary<char, int> characterCounts = new Dictionary<char, int>();
            for (int idx = 0; idx < characters.Length; idx++)
            {
                char character = characters[idx];
                characterCounts[character] =
                characterCounts.GetValueOrDefault(character, 0) + 1;
            }
            for (int idx = 0; idx < document.Length; idx++)
            {
                char character = document[idx];
                if (!characterCounts.ContainsKey(character) ||
                characterCounts[character] == 0)
                {
                    return false;
                }
                characterCounts[character] = characterCounts[character] - 1;
            }
            return true;
        }
    }
}
