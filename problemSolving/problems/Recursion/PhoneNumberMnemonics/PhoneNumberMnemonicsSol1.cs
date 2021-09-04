using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.PhoneNumberMnemonics
{
    class PhoneNumberMnemonicsSol1
    {
        public static Dictionary<char, string[]> DIGIT_LETTERS = new Dictionary<char, string[]> {
                                 {'0', new string[] {"0"}},
                                 {'1', new string[] {"1"}},
                                 {'2', new string[] {"a", "b", "c"}},
                                 {'3', new string[] {"d", "e", "f"}},
                                 {'4', new string[] {"g", "h", "i"}},
                                 {'5', new string[] {"j", "k", "l"}},
                                 {'6', new string[] {"m", "n", "o"}},
                                 {'7', new string[] {"p", "q", "r", "s"}},
                                 {'8', new string[] {"t", "u", "v"}},
                                 {'9', new string[] {"w", "x", "y", "z"}}
                                 };
        // O(4^n * n) time | O(4^n * n) space - where
        // n is the length of the phone number
        public List<string> PhoneNumberMnemonics(string phoneNumber)
        {
            string[] currentMnemonic = new string[phoneNumber.Length];
            Array.Fill(currentMnemonic, "0");
            List<string> mnemonicsFound = new List<string>();
            PhoneNumberMnemonicsHelper(0, phoneNumber, currentMnemonic, mnemonicsFound);
            return mnemonicsFound;
        }
        public void PhoneNumberMnemonicsHelper(int idx, string phoneNumber,
        string[] currentMnemonic,
        List<string> mnemonicsFound)
        {
            if (idx == phoneNumber.Length)
            {
                string mnemonic = String.Join("", currentMnemonic);
                mnemonicsFound.Add(mnemonic);
            }
            else
            {
                char digit = phoneNumber[idx];
                string[] letters = DIGIT_LETTERS[digit];
                foreach (var letter in letters)
                {
                    currentMnemonic[idx] = letter;
                    PhoneNumberMnemonicsHelper(idx + 1, phoneNumber, currentMnemonic,
                    mnemonicsFound);
                }
            }
        }

    }
}
