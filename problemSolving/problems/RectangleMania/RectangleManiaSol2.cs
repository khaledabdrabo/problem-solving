using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.RectangleMania
{
    class RectangleManiaSo12
    {
        static string UP = "up";
        static string RIGHT = "right";
        static string DOWN = "down";
        // O(n^2) time | O(n) space - where n is the number of coordinates
        public static int RectangleMania(List<int[]> coords)
        {
            Dictionary<string, Dictionary<int, List<int[]>>> coordsTable = getCoordsTable(
            coords);
            return getRectangleCount(coords, coordsTable);
        }
        public static Dictionary<string, Dictionary<int, List<int[]>>> getCoordsTable(
        List<int[]> coords)
        {
            Dictionary<string, Dictionary<int,
            List<int[]>>> coordsTable = new Dictionary<string,
            Dictionary<int,
            List<int[]>>>();
            coordsTable.Add("x", new Dictionary<int, List<int[]>>());
            coordsTable.Add("y", new Dictionary<int, List<int[]>>());
            foreach (int[] coord in coords)
            {
                if (!coordsTable["x"].ContainsKey(coord[0]))
                {
                    coordsTable["x"].Add(coord[0], new List<int[]>());
                }
                if (!coordsTable["y"].ContainsKey(coord[1]))
                {
                    coordsTable["y"].Add(coord[1], new List<int[]>());
                }
                coordsTable["x"][coord[0]].Add(coord);
                coordsTable["y"][coord[1]].Add(coord);
            }
            return coordsTable;
        }
        public static int getRectangleCount(List<int[]> coords, Dictionary<string, Dictionary<int,
        List<int[]>>> coordsTable)
        {
            int rectangleCount = 0;
            foreach (int[] coord in coords)
            {
                int lowerLeftY = coord[1];
                rectangleCount += clockwiseCountRectangles(coord, coordsTable, UP,
                lowerLeftY);
            }
            return rectangleCount;
        }
        public static int clockwiseCountRectangles(
        int[] coord1,
        Dictionary<string, Dictionary<int, List<int[]>>> coordsTable,
        string direction,
        int lowerLeftY
        )
        {
            if (direction == DOWN)
            {
                List<int[]> relevantCoords = coordsTable["x"][coord1[0]];
                foreach (int[] coord2 in relevantCoords)
                {
                    int lowerRightY = coord2[1];
                    if (lowerRightY == lowerLeftY) return 1;
                }
                return 0;
            }
            else
            {
                int rectangleCount = 0;
                if (direction == UP)
                {
                    List<int[]> relevantCoords = coordsTable["x"][coord1[0]];
                    foreach (int[] coord2 in relevantCoords)
                    {
                        bool isAbove = coord2[1] > coord1[1];
                        if (isAbove) rectangleCount += clockwiseCountRectangles(
                        coord2, coordsTable, RIGHT, lowerLeftY);
                    }
                }
                else if (direction == RIGHT)
                {
                    List<int[]> relevantCoords = coordsTable["y"][coord1[1]];
                    foreach (int[] coord2 in relevantCoords)
                    {
                        bool isRight = coord2[0] > coord1[0];
                        if (isRight) rectangleCount += clockwiseCountRectangles(
                        coord2, coordsTable, DOWN, lowerLeftY);
                    }
                }
                return rectangleCount;
            }
        }
    }
}
