using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.ArrayOfProducts
{
    class ArrayOfProductsSol1
    {
        // O(n^2) time | O(n) space - where n is the length of the input array
        public int[] ArrayOfProducts(int[] array)
        {
            int[] products = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int runningProduct = 1;
                for (int j = 0; j < array.Length; j++)
                {
                    if (i != j)
                    {
                        runningProduct *= array[j];
                    }
                    products[i] = runningProduct;
                }
            }
            return products;
        }

    }
}
