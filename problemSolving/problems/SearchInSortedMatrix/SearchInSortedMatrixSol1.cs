﻿using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.SearchInSortedMatrix
{
    class SearchInSortedMatrixSol1
    {
        // O(n + m) time | O(1) space
        public static int[] SearchInSortedMatrix(int[,] matrix, int target)
        {
            int row = 0;
            int col = matrix.GetLength(1) - 1;
            while (row < matrix.GetLength(0) && col >= 0)
            {
                if (matrix[row, col] > target)
                {
                    col--;
                }
                else if (matrix[row, col] < target)
                {
                    row++;
                }
                else
                {
                    return new int[] { row, col };
                }
            }
            return new int[] { -1, -1 };
        }

    }
}
