using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.ProductSum
{
    class ProductSumSol1
    {
        // O(n) time | O(d) space - where n is the total number of elements in the array,
        // including sub-elements, and d is the greatest depth of "special" arrays in the array
        public static int ProductSum(List<object> array)
        {
            return productSumHelper(array, 1);
        }
        public static int productSumHelper(List<object> array, int multiplier)
        {
            int sum = 0;
            foreach (object el in array)
            {
                if (el is IList<object>)
                {
                    sum += productSumHelper((List<object>)el, multiplier + 1);
                }
                else
                {
                    sum += (int)el;
                }
            }
            return sum * multiplier;
        }

    }
}
