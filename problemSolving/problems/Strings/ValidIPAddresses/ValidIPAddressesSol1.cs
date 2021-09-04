using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.ValidIPAddresses
{
    class ValidIPAddressesSol1
    {
        // O(1) time | O(1) space
        public List<string> ValidIPAddresses(string str)
        {
            List<string> ipAddressesFound = new List<string>();
            for (int i = 1; i < Math.Min((int)str.Length, 4); i++)
            {
                string[] currentIPAddressParts = new string[] { "", "", "", "" };
                currentIPAddressParts[0] = str.Substring(0, i - 0);
                if (!isValidPart(currentIPAddressParts[0]))
                {
                    continue;
                }
                for (int j = i + 1; j < i + Math.Min((int)str.Length - i, 4); j++)
                {
                    currentIPAddressParts[1] = str.Substring(i, j - i);
                    if (!isValidPart(currentIPAddressParts[1]))
                    {
                        continue;
                    }
                    for (int k = j + 1; k < j + Math.Min((int)str.Length - j, 4); k++)
                    {
                        currentIPAddressParts[2] = str.Substring(j, k - j);
                        currentIPAddressParts[3] = str.Substring(k);
                        if (isValidPart(currentIPAddressParts[2]) &&
                        isValidPart(currentIPAddressParts[3]))
                        {
                            ipAddressesFound.Add(join(currentIPAddressParts));
                        }
                    }
                }
            }
            return ipAddressesFound;
        }
        public bool isValidPart(string str)
        {
            int stringAsInt = Int32.Parse(str);
            if (stringAsInt > 255)
            {
                return false;
            }
            return str.Length == stringAsInt.ToString().Length; // check for leading 0
        }
        public string join(string[] strings)
        {
            StringBuilder sb = new StringBuilder();
            for (int l = 0; l < strings.Length; l++)
            {
                sb.Append(strings[l]);
                if (l < strings.Length - 1)
                {
                    sb.Append(".");
                }
            }
            return sb.ToString();
        }
    }
}
