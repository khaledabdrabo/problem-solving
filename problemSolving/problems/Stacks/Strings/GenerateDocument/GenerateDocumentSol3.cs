using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.GenerateDocument
{
    class GenerateDocumentSol3
    {
        // O(m * (n + m)) time | O(1) space - where n is the number
        // of characters and m is the length of the document
        public bool GenerateDocument(string characters, string document)
        {
            for (int idx = 0; idx < document.Length; idx++)
            {
                char character = document[idx];
                int documentFrequency = countcharFrequency(character, document);
                int charactersFrequency = countcharFrequency(character, characters);
                if (documentFrequency > charactersFrequency)
                {
                    return false;
                }
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
