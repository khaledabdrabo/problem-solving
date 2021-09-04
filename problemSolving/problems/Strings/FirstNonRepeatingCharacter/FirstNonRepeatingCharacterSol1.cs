using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.FirstNonRepeatingCharacter
{
    class FirstNonRepeatingCharacterSol1
    {
        // O(n) time | O(1) space - where n is the length of the input string
        // The constant space is because the input string only has lowercase
        // English-alphabet letters; thus, our hash table will never have more
        // than 26 character frequencies.
        public int FirstNonRepeatingCharacter(string str)
        {
            Dictionary<char, int> characterFrequencies = new Dictionary<char, int>();
            for (int idx = 0; idx < str.Length; idx++)
            {
                char character = str[idx];
                characterFrequencies[character] = characterFrequencies.GetValueOrDefault(
                character, 0) + 1;
            }
            for (int idx = 0; idx < str.Length; idx++)
            {
                char character = str[idx];
                if (characterFrequencies[character] == 1)
                {
                    return idx;
                }
            }
            return -1;
        }
    }
}
