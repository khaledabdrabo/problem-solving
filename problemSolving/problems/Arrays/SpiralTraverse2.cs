using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems
{
    public static class SpiralTraverse2
    {
        public static List<int> SpiralTraverse(int[,] array)
        {

            if (array.GetLength(0) == 0) return new List<int>();
            var list = new List<int>();
            int startRow = 0; int startCol = 0;
            int EndTRow = array.GetLength(0) - 1;
            int EndCol = array.GetLength(1) - 1;
            while (startRow <= EndTRow && startCol <= EndCol)
            {
                for (int col = startCol; col <= EndCol; col++)
                {
                    list.Add(array[startRow, col]);
                    Console.WriteLine(array[startRow, col]);
                }
                for (int row = startRow + 1; row <= EndTRow; row++)
                {
                    list.Add(array[row, EndCol]);

                    Console.WriteLine(array[row, EndCol]);
                }
                for (int col = EndCol - 1; col >= startCol; col--)
                {

                    if (startRow == EndTRow)
                    {
                        break;
                    }
                    Console.WriteLine(array[EndTRow, col]);
                    list.Add(array[EndTRow, col]);



                }
                for (int row = EndTRow - 1; row > startRow; row--)
                {
                    if (startCol == EndCol)
                    {
                        break;
                    }
                    Console.WriteLine(array[row, startCol]);
                    list.Add(array[row, startCol]);
                }
                startCol++;
                EndTRow--;
                startRow++;
                EndCol--;
            }
            // Write your code here.
            return list;
        }
    }
}
