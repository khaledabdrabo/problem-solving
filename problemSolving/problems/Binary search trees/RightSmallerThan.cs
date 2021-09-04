using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problemSolving.problems
{
    public static class RightSmallerThan
    {
        public static List<int> getCountRightSmallerThan(List<int> nums)
        {
            var countList = new List<int>();
            for (int i = 0; i < nums.Count; i++)
            {
                countList.Add(nums.GetRange(i, nums.Count - i).Where(x => x < nums[i]).Count());
            }
            return countList; 
        }
    }
}
