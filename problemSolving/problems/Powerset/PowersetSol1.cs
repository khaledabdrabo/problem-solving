using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.Powerset
{
    class PowersetSol1
    {
        // O(n*2^n) time | O(n*2^n) space
        public static List<List<int>> Powerset(List<int> array)
        {
            return Powerset(array, array.Count - 1);
        }
        public static List<List<int>> Powerset(List<int> array, int idx)
        {
            if (idx < 0)
            {
                List<List<int>> emptySet = new List<List<int>>();
                emptySet.Add(new List<int>());
                return emptySet;
            }
            int ele = array[idx];
            List<List<int>> subsets = Powerset(array, idx - 1);
            int length = subsets.Count;
            for (int i = 0; i < length; i++)
            {
                List<int> currentSubset = new List<int>(subsets[i]);
                currentSubset.Add(ele);
                subsets.Add(currentSubset);
            }
            return subsets;
        }

    }
}
