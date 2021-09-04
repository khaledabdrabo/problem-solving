using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.SolveSudoku
{
    class SolveSudokuSol1
    {
        // O(1) time | O(1) space - assuming a 9x9 input board
        public List<List<int>> SolveSudoku(List<List<int>> board)
        {
            solvePartialSudoku(0, 0, board);
            return board;
        }
        public bool solvePartialSudoku(int row, int col, List<List<int>> board)
        {
            int currentRow = row;
            int currentCol = col;
            if (currentCol == board[currentRow].Count)
            {
                currentRow += 1;
                currentCol = 0;
                if (currentRow == board.Count)
                {
                    return true; // board is completed
                }
            }
            if (board[currentRow][currentCol] == 0)
            {
                return tryDigitsAtPosition(currentRow, currentCol, board);
            }
            return solvePartialSudoku(currentRow, currentCol + 1, board);
        }
        public bool tryDigitsAtPosition(int row, int col, List<List<int>> board)
        {
            for (int digit = 1; digit < 10; digit++)
            {
                if (isValidAtPosition(digit, row, col, board))
                {
                    board[row][col] = digit;
                    if (solvePartialSudoku(row, col + 1, board))
                    {
                        return true;
                    }
                }
            }
            board[row][col] = 0;
            return false;
        }
        public bool isValidAtPosition(
        int value, int row, int col, List<List<int>> board)
        {
            bool rowIsValid = !board[row].Contains(value);
            bool columnIsValid = true;
            for (int r = 0; r < board.Count; r++)
            {
                if (board[r][col] == value) columnIsValid = false;
            }
            if (!rowIsValid || !columnIsValid)
            {
                return false;
            }
            // Check subgrid constraints
            int subgridRowStart = (row / 3) * 3;
            int subgridColStart = (col / 3) * 3;
            for (int rowIdx = 0; rowIdx < 3; rowIdx++)
            {
                for (int colIdx = 0; colIdx < 3; colIdx++)
                {
                    int rowToCheck = subgridRowStart + rowIdx;
                    int colToCheck = subgridColStart + colIdx;
                    int existingValue = board[rowToCheck][colToCheck];
                    if (existingValue == value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
