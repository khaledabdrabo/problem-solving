using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.MinimumCharactersForWords
{
    class MinimumCharactersForWordsSol1
    {
        // O(n * l) time | O(c) space - where n is the number of words,
        // l is the length of the longest word, and c is the number of
        // unique characters across all words
        // See notes under video explanation for details about the space complexity.
        public char[] MinimumCharactersForWords(string[] words)
        {
            Dictionary<char, int> maximumCharFrequencies = new Dictionary<char, int>();
            foreach (var word in words)
            {
                Dictionary<char, int> characterFrequencies = countCharFrequencies(word);
                updateMaximumFrequencies(characterFrequencies, maximumCharFrequencies);
            }
            return makeArrayFromCharFrequencies(maximumCharFrequencies);
        }
        public Dictionary<char, int> countCharFrequencies(string str)
        {
            Dictionary<char, int> characterFrequencies = new Dictionary<char, int>();
            foreach (var character in str.ToCharArray())
            {
                characterFrequencies[character] = characterFrequencies.GetValueOrDefault(
                character, 0) + 1;
            }
            return characterFrequencies;
        }
        public void updateMaximumFrequencies(Dictionary<char, int> frequencies,
        Dictionary<char, int> maximumFrequencies)
        {
            foreach (var frequency in frequencies)
            {
                char character = frequency.Key;
                int characterFrequency = frequency.Value;
                if (maximumFrequencies.ContainsKey(character))
                {
                    maximumFrequencies[character] = Math.Max(characterFrequency,
                    maximumFrequencies[
                    character]);
                }
                else
                {
                    maximumFrequencies[character] = characterFrequency;
                }
            }
        }
        public char[] makeArrayFromCharFrequencies(Dictionary<char, int> characterFrequencies)
        {
            List<char> characters = new List<char>();
            foreach (var frequency in characterFrequencies)
            {
                char character = frequency.Key;
                int characterFrequency = frequency.Value;
                for (int idx = 0; idx < characterFrequency; idx++)
                {
                    characters.Add(character);
                }
            }
            char[] charactersArray = new char[characters.Count];
            for (int idx = 0; idx < characters.Count; idx++)
            {
                charactersArray[idx] = characters[idx];
            }
            return charactersArray;
        }

    }
}
