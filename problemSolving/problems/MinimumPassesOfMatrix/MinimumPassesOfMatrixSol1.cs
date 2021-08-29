using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.MinimumPassesOfMatrix
{
    class MinimumPassesOfMatrixSol1
    {
        // O(w * h) time | O(w * h) space - where w is the
        // width of the matrix and h is the height
        public int MinimumPassesOfMatrix(int[][] matrix)
        {
            int passes = convertNegatives(matrix);
            return (!containsNegative(matrix)) ? passes - 1 : -1;
        }
        public int convertNegatives(int[][] matrix)
        {
            List<int[]> nextPassQueue = getAllPositivePositions(matrix);
            int passes = 0;
            while (nextPassQueue.Count > 0)
            {
                List<int[]> currentPassQueue = nextPassQueue;
                nextPassQueue = new List<int[]>();
                while (currentPassQueue.Count > 0)
                {
                    // In C#, removing elements from the start of a list is an O(n)-time operation.
                    // To make this an O(1)-time operation, we could use a more legitimate queue structure
                    // For our time complexity analysis, we'll assume this runs in O(1) time.
                    // Also, for this particular solution (Solution #1), we could actually
                    // just turn this queue into a stack and replace `.RemoveAt(0)` with the
                    // constant-time `Pop()` operation.
                    int[] vals = currentPassQueue[0];
                    currentPassQueue.RemoveAt(0);
                    int currentRow = vals[0];
                    int currentCol = vals[1];
                    List<int[]> adjacentPositions = getAdjacentPositions(currentRow,
                    currentCol,
                    matrix);
                    foreach (var position in adjacentPositions)
                    {
                        int row = position[0];
                        int col = position[1];
                        int value = matrix[row][col];
                        if (value < 0)
                        {
                            matrix[row][col] *= -1;
                            nextPassQueue.Add(new int[] { row, col });
                        }
                    }
                }
                passes += 1;
            }
            return passes;
        }
        public List<int[]> getAllPositivePositions(int[][] matrix)
        {
            List<int[]> positivePositions = new List<int[]>();
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    int value = matrix[row][col];
                    if (value > 0)
                    {
                        positivePositions.Add(new int[] { row, col });
                    }
                }
            }
            return positivePositions;
        }
        public List<int[]> getAdjacentPositions(int row, int col, int[][] matrix)
        {
            List<int[]> adjacentPositions = new List<int[]>();
            if (row > 0)
            {
                adjacentPositions.Add(new int[] { row - 1, col });
            }
            if (row < matrix.Length - 1)
            {
                adjacentPositions.Add(new int[] { row + 1, col });
            }
            if (col > 0)
            {
                adjacentPositions.Add(new int[] { row, col - 1 });
            }
            if (col < (matrix[0].Length - 1))
            {
                adjacentPositions.Add(new int[] { row, col + 1 });
            }
            return adjacentPositions;
        }
        public bool containsNegative(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var value in row)
                {
                    if (value < 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
