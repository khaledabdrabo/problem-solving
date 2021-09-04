using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.NonAttackingQueens
{
    class NonAttackingQueensSol1
    {
        // Upper Bound: O(n!) time | O(n) space - where n is the input number
        public int NonAttackingQueens(int n)
        {
            HashSet<int> blockedColumns = new HashSet<int>();
            HashSet<int> blockedUpDiagonals = new HashSet<int>();
            HashSet<int> blockedDownDiagonals = new HashSet<int>();
            return getNumberOfNonAttackingQueenPlacements(0, blockedColumns, blockedUpDiagonals,
            blockedDownDiagonals, n);
        }
        public int getNumberOfNonAttackingQueenPlacements(int row, HashSet<int> blockedColumns,
        HashSet<int> blockedUpDiagonals,
        HashSet<int> blockedDownDiagonals,
        int boardSize)
        {
            if (row == boardSize) return 1;
            int validPlacements = 0;
            for (int col = 0; col < boardSize; col++)
            {
                if (isNonAttackingPlacement(row, col, blockedColumns, blockedUpDiagonals,
                blockedDownDiagonals))
                {
                    placeQueen(row, col, blockedColumns, blockedUpDiagonals,
                    blockedDownDiagonals);
                    validPlacements += getNumberOfNonAttackingQueenPlacements(row + 1,
                    blockedColumns, blockedUpDiagonals, blockedDownDiagonals,
                    boardSize);
                    removeQueen(row, col, blockedColumns, blockedUpDiagonals,
                    blockedDownDiagonals);
                }
            }
            return validPlacements;
        }
        // This is always an O(1)-time operation.
        public bool isNonAttackingPlacement(int row, int col, HashSet<int> blockedColumns,
        HashSet<int> blockedUpDiagonals,
        HashSet<int> blockedDownDiagonals)
        {
            if (blockedColumns.Contains(col))
            {
                return false;
            }
            else if (blockedUpDiagonals.Contains(row + col))
            {
                return false;
            }
            else if (blockedDownDiagonals.Contains(row - col))
            {
                return false;
            }
            return true;
        }
        public void placeQueen(int row, int col, HashSet<int> blockedColumns,
        HashSet<int> blockedUpDiagonals, HashSet<int> blockedDownDiagonals)
        {
            blockedColumns.Add(col);
            blockedUpDiagonals.Add(row + col);
            blockedDownDiagonals.Add(row - col);
        }
        public void removeQueen(int row, int col, HashSet<int> blockedColumns,
        HashSet<int> blockedUpDiagonals,
        HashSet<int> blockedDownDiagonals)
        {
            blockedColumns.Remove(col);
            blockedUpDiagonals.Remove(row + col);
            blockedDownDiagonals.Remove(row - col);
        }

    }
}
