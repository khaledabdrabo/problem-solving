using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.FirstNonRepeatingCharacter
{
    class FirstNonRepeatingCharacterSol2
    {
        // O(n^2) time | O(1) space - where n is the length of the input string
        public int FirstNonRepeatingCharacter(string str)
        {
            for (int idx = 0; idx < str.Length; idx++)
            {
                bool foundDuplicate = false;
                for (int idx2 = 0; idx2 < str.Length; idx2++)
                {
                    if (str[idx] == str[idx2] && idx != idx2)
                    {
                        foundDuplicate = true;
                    }
                }
                if (!foundDuplicate)
                    return idx;
            }
            return -1;
        }

    }
}
