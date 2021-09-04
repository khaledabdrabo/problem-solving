using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.RectangleMania
{
    static class RectangleManiaSol1
    {
        static string UP = "up";
        static string RIGHT = "right";
        static string DOWN = "down";
        static string LEFT = "left";
        // O(n^2) time | O(n^2) space - where n is the number of coordinates
        public static int RectangleMania(List<int[]> coords)
        {
            Dictionary<string, Dictionary<string, List<int[]>>> coordsTable = getCoordsTable(coords);
            return getRectangleCount(coords, coordsTable);
        }

        public static Dictionary<string, Dictionary<string, List<int[]>>> getCoordsTable(List<int[]> coords)
        {
            Dictionary<string, Dictionary<string, List<int[]>>> coordsTable = new Dictionary<string, Dictionary<string, List<int[]>>>();
            foreach (var coord1 in coords)
            {
                Dictionary<string, List<int[]>> coord1Directions = new Dictionary<string, List<int[]>>();
                coord1Directions[UP] = new List<int[]>();
                coord1Directions[RIGHT] = new List<int[]>();
                coord1Directions[DOWN] = new List<int[]>();
                coord1Directions[LEFT] = new List<int[]>();
                foreach (var coord2 in coords)
                {
                    string coord2Direction = getCoordDirection(coord1, coord2);
                    if (coord1Directions.ContainsKey(coord2Direction))
                        coord1Directions[coord2Direction].Add(coord2);
                }
                string coord1string = coordTostring(coord1);
                coordsTable[coord1string] = coord1Directions;
            }
            return coordsTable;
        }

        public static string getCoordDirection(int[] coord1, int[] coord2)
        {
            if (coord2[1] == coord1[1])
            {
                if (coord2[0] > coord1[0])
                {
                    return RIGHT;
                }
                else if (coord2[0] < coord1[0])
                {
                    return LEFT;
                }
            }
            else if (coord2[0] == coord1[0])
            {
                if (coord2[1] > coord1[1])
                {
                    return UP;
                }
                else if (coord2[1] < coord1[1])
                {
                    return DOWN;
                }
            }
            return "";
        }
        public static int getRectangleCount(List<int[]> coords, Dictionary<string, Dictionary<string, List<int[]>>> coordsTable)
        {
            int rectangleCount = 0;
            foreach (var coord in coords)
            {
                rectangleCount += clockwiseCountRectangles(coord, coordsTable, UP, coord);
            }
            return rectangleCount;
        }
        public static int clockwiseCountRectangles(int[] coord, Dictionary<string, Dictionary<string, List<int[]>>> coordsTable, string direction, int[] origin)
        {
            string coordstring = coordTostring(coord);
            if (direction == LEFT)
            {
                bool rectangleFound = coordsTable[coordstring][LEFT].Contains(origin);
                return rectangleFound ? 1 : 0;
            }
            else
            {
                int rectangleCount = 0;
                string nextDirection = getNextClockwiseDirection(direction);
                foreach (var nextCoord in coordsTable[coordstring][direction])
                {
                    rectangleCount += clockwiseCountRectangles(nextCoord, coordsTable, nextDirection, origin);
                }
                return rectangleCount;
            }
        }
        public static string getNextClockwiseDirection(string direction)
        {
            if (direction == UP) return RIGHT;
            if (direction == RIGHT) return DOWN;
            if (direction == DOWN) return LEFT;
            return "";
        }
        public static string coordTostring(int[] coord)
        {
            return coord[0].ToString() + "-" + coord[1].ToString();
        }

    }
}
