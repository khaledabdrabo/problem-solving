using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems
{
    public static class SmallestDifference
    {
        public static int[] GetSmallestDifferenceItems(int[] arrayOne, int[] arrayTwo)
        {
            int difference = Math.Abs(arrayOne[0]- arrayTwo[0]), item1 = 0,item2 = 0;
            foreach (var x in arrayOne)
            {
                foreach (var y in arrayTwo)
                {
                    int res=Math.Abs(x - y);
                    if (res < difference)
                    {
                        difference = res;
                        item1 = x;
                        item2 = y;
                    }

                }
            }
            return new int[] { item1, item2 };
        }
    }
}
