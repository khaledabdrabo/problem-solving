using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.NonAttackingQueens
{
    class NonAttackingQueensSol2
    {
        // Lower Bound: O(n!) time | O(n) space - where n is the input number
        public int NonAttackingQueens(int n)
        {
            // Each index of `columnPlacements` represents a row of the chessboard,
            // and the value at each index is the column (on the relevant row) where
            // a queen is currently placed.
            int[] columnPlacements = new int[n];
            return getNumberOfNonAttackingQueenPlacements(0, columnPlacements, n);
        }
        public int getNumberOfNonAttackingQueenPlacements(int row, int[] columnPlacements,
        int boardSize)
        {
            if (row == boardSize) return 1;
            int validPlacements = 0;
            for (int col = 0; col < boardSize; col++)
            {
                if (isNonAttackingPlacement(row, col, columnPlacements))
                {
                    columnPlacements[row] = col;
                    validPlacements += getNumberOfNonAttackingQueenPlacements(row + 1,
                    columnPlacements,
                    boardSize);
                }
            }
            return validPlacements;
        }
        // As `row` tends to `n`, this becomes an O(n)-time operation.
        public bool isNonAttackingPlacement(int row, int col, int[] columnPlacements)
        {
            for (int previousRow = 0; previousRow < row; previousRow++)
            {
                int columnToCheck = columnPlacements[previousRow];
                bool sameColumn = (columnToCheck == col);
                bool onDiagonal = Math.Abs(columnToCheck - col) == (row - previousRow);
                if (sameColumn || onDiagonal)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
