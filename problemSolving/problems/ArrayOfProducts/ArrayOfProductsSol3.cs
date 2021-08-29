using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.ArrayOfProducts
{
    class ArrayOfProductsSol3
    {
        // O(n) time | O(n) space - where n is the length of the input array
        public int[] ArrayOfProducts(int[] array)
        {
            int[] products = new int[array.Length];
            int leftRunningProduct = 1;
            for (int i = 0; i < array.Length; i++)
            {
                products[i] = leftRunningProduct;
                leftRunningProduct *= array[i];
            }
            int rightRunningProduct = 1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                products[i] *= rightRunningProduct;
                rightRunningProduct *= array[i];
            }
            return products;
        }
    }
}
