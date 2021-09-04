using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.AmbiguousMeasurements
{
    class AmbiguousMeasurementsSol1
    {
        // O(low * high * n) time | O(low * high) space - where n is the number of measuring cups
        public bool AmbiguousMeasurements(int[][] measuringCups, int low, int high)
        {
            Dictionary<string, bool> memoization = new Dictionary<string, bool>();
            return canMeasureInRange(measuringCups, low, high, memoization);
        }
        public bool canMeasureInRange(int[][] measuringCups, int low, int high, Dictionary<string,
        bool> memoization)
        {
            string memoizeKey = createHashableKey(low, high);
            if (memoization.ContainsKey(memoizeKey))
            {
                return memoization[memoizeKey];
            }
            if (low <= 0 && high <= 0)
            {
                return false;
            }
            bool canMeasure = false;
            foreach (var cup in measuringCups)
            {
                int cupLow = cup[0];
                int cupHigh = cup[1];
                if (low <= cupLow && cupHigh <= high)
                {
                    canMeasure = true;
                    break;
                }
                int newLow = Math.Max(0, low - cupLow);
                int newHigh = Math.Max(0, high - cupHigh);
                canMeasure = canMeasureInRange(measuringCups, newLow, newHigh,
                memoization);
                if (canMeasure) break;
            }
            memoization[memoizeKey] = canMeasure;
            return canMeasure;
        }
        public string createHashableKey(int low, int high)
        {
            return low.ToString() + ":" + high.ToString();
        }
    }
}
