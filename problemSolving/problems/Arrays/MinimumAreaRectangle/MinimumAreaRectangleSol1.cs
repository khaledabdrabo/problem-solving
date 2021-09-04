using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.MinimumAreaRectangle
{
    public class MinimumAreaRectangleSol1
    {
        // O(n^2) time | O(n) space - where n is the number of points
        public int MinimumAreaRectangle(int[][] points)
        {
            Dictionary<int, int[]> columns = initializeColumns(points);
            int minimumAreaFound = Int32.MaxValue;
            Dictionary<string, int> edgesParallelToYAxis = new Dictionary<string, int>();
            List<int> sortedColumns = new List<int>(columns.Keys);
            sortedColumns.Sort();
            foreach (var x in sortedColumns)
            {
                int[] yValuesInCurrentColumn = columns[x];
                Array.Sort(yValuesInCurrentColumn);
                for (int currentIdx = 0; currentIdx < yValuesInCurrentColumn.Length;
                currentIdx++)
                {
                    int y2 = yValuesInCurrentColumn[currentIdx];
                    for (int previousIdx = 0; previousIdx < currentIdx; previousIdx++)
                    {
                        int y1 = yValuesInCurrentColumn[previousIdx];
                        string pointstring = y1.ToString() + ":" + y2.ToString();
                        if (edgesParallelToYAxis.ContainsKey(pointstring))
                        {
                            int currentArea =
                            (x - edgesParallelToYAxis[pointstring]) *
                            (y2 - y1);
                            minimumAreaFound = Math.Min(minimumAreaFound,
                            currentArea);
                        }
                        edgesParallelToYAxis[pointstring] = x;
                    }
                }
            }
            return (minimumAreaFound != Int32.MaxValue) ? minimumAreaFound : 0;
        }
        public Dictionary<int, int[]> initializeColumns(int[][] points)
        {
            Dictionary<int, int[]> columns = new Dictionary<int, int[]>();
            foreach (var point in points)
            {
                int x = point[0];
                int y = point[1];
                if (!columns.ContainsKey(x))
                {
                    columns[x] = new int[] { };
                }
                int[] column = columns[x];
                int[] newColumn = new int[column.Length + 1];
                for (int i = 0; i < column.Length; i++)
                {
                    newColumn[i] = column[i];
                }
                newColumn[column.Length] = y;
                columns[x] = newColumn;
            }
            return columns;
        }
    }
}
