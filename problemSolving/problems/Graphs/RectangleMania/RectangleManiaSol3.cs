using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.RectangleMania
{
    class RectangleManiaSol3
    {
        // O(n^2) time | O(n) space - where n is the number of coordinates
        public static int RectangleMania(List<int[]> coords)
        {
            HashSet<string> coordsTable = getCoordsTable(coords);
            return getRectangleCount(coords, coordsTable);
        }
        public static HashSet<string> getCoordsTable(List<int[]> coords)
        {
            HashSet<string> coordsTable = new HashSet<string>();
            foreach (var coord in coords)
            {
                string coordstring = coordTostring(coord);
                coordsTable.Add(coordstring);
            }
            return coordsTable;
        }
        public static int getRectangleCount(List<int[]> coords, HashSet<string> coordsTable)
        {
            int rectangleCount = 0;
            foreach (var coord1 in coords)
            {
                foreach (var coord2 in coords)
                {
                    if (!isInUpperRight(coord1, coord2)) continue;
                    string upperCoordstring = coordTostring(new int[] { coord1[0], coord2[1] });
                    string rightCoordstring = coordTostring(new int[] { coord2[0], coord1[1] });
                    if (coordsTable.Contains(upperCoordstring) && coordsTable.Contains(rightCoordstring))
                        rectangleCount++;
                }
            }
            return rectangleCount;
        }
        public static bool isInUpperRight(int[] coord1, int[] coord2)
        {
            return coord2[0] > coord1[0] && coord2[1] > coord1[1];
        }
        public static string coordTostring(int[] coord)
        {
            return coord[0].ToString() + "-" + coord[1].ToString();
        }
    }
}
