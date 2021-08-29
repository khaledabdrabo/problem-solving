﻿using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.SunsetViews
{
    class SunsetViewsSol2
    {
        // O(n) time | O(n) space - where n is the length of the input array
        public List<int> SunsetViews(int[] buildings, string direction)
        {
            List<int> candidateBuildings = new List<int>();
            int startIdx = buildings.Length - 1;
            int step = -1;
            if (direction.Equals("EAST"))
            {
                startIdx = 0;
                step = 1;
            }
            int idx = startIdx;
            while (idx >= 0 && idx < buildings.Length)
            {
                int buildingHeight = buildings[idx];
                while (candidateBuildings.Count > 0 &&
                buildings[candidateBuildings[candidateBuildings.Count - 1]] <=
                buildingHeight)
                {
                    candidateBuildings.RemoveAt(candidateBuildings.Count - 1);
                }
                candidateBuildings.Add(idx);
                idx += step;
            }
            if (direction.Equals("WEST"))
            {
                candidateBuildings.Reverse();
            }
            return candidateBuildings;
        }

    }
}
