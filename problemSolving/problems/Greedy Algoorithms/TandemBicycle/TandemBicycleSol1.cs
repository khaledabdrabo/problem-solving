using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.TandemBicycle
{
    class TandemBicycleSol1
    {
        // O(nlog(n)) time | O(1) space - where n is the number of tandem bicycles
        public int TandemBicycle(int[] redShirtSpeeds, int[] blueShirtSpeeds, bool fastest)
        {
            Array.Sort(redShirtSpeeds);
            Array.Sort(blueShirtSpeeds);
            if (!fastest)
            {
                reverseArrayInPlace(redShirtSpeeds);
            }
            int totalSpeed = 0;
            for (int idx = 0; idx < redShirtSpeeds.Length; idx++)
            {
                int rider1 = redShirtSpeeds[idx];
                int rider2 = blueShirtSpeeds[blueShirtSpeeds.Length - idx - 1];
                totalSpeed += Math.Max(rider1, rider2);
            }
            return totalSpeed;
        }
        public void reverseArrayInPlace(int[] array)
        {
            int start = 0;
            int end = array.Length - 1;
            while (start < end)
            {
                int temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                start += 1;
                end -= 1;
            }
        }
    }
}
