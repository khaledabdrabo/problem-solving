using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems
{
    public static class ShiftItemTolistBottom
    {
        public static List<int> ShiftItem(List<int> l,int element)
        {
            
            int start = 0;
            int end = l.Count - 1;
            while (l.Count!=0 &&start != end )
            {
                if (l[start] == element)
                {
                    var temp = l[start];
                    l[start] = l[end];
                    l[end] = temp;
                    end--;
                }
                else
                {
                    start++;
                }
            }
            return l;
        }
        
    }
}
