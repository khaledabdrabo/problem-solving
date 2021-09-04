using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.MinimumAreaRectangle
{
    public class MinimumAreaRectangleSol2
    {
        // O(n^2) time | O(n) space - where n is the number of points
        public int MinimumAreaRectangle(int[][] points)
        {
            HashSet<string> pointSet = createPointSet(points);
            int minimumAreaFound = Int32.MaxValue;
            for (int currentIdx = 0; currentIdx < points.Length; currentIdx++)
            {
                int p2x = points[currentIdx][0];
                int p2y = points[currentIdx][1];
                for (int previousIdx = 0; previousIdx < currentIdx; previousIdx++)
                {
                    int p1x = points[previousIdx][0];
                    int p1y = points[previousIdx][1];
                    bool pointsShareValue = p1x == p2x || p1y == p2y;
                    if (pointsShareValue) continue;
                    // If (p1x, p2y) and (p2x, p1y), exist we've found a rectangle.
                    bool point1OnOppositeDiagonalExists = pointSet.Contains(convertPointTostring(
                    p1x,
                    p2y));
                    bool point2OnOppositeDiagonalExists = pointSet.Contains(convertPointTostring(
                    p2x,
                    p1y));
                    bool oppositeDiagonalExists = point1OnOppositeDiagonalExists &&
                    point2OnOppositeDiagonalExists;
                    if (oppositeDiagonalExists)
                    {
                        int currentArea = Math.Abs(p2x - p1x) * Math.Abs(p2y - p1y);
                        minimumAreaFound = Math.Min(minimumAreaFound, currentArea);
                    }
                }
            }
            return (minimumAreaFound != Int32.MaxValue) ? minimumAreaFound : 0;
        }
        public string convertPointTostring(int x, int y)
        {
            return x.ToString() + ":" + y.ToString();
        }
        public HashSet<string> createPointSet(int[][] points)
        {
            HashSet<string> pointSet = new HashSet<string>();
            foreach (var point in points)
            {
                int x = point[0];
                int y = point[1];
                string pointstring = convertPointTostring(x, y);
                pointSet.Add(pointstring);
            }
            return pointSet;
        }
    }
}
