using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.TwoEdgeConnectedGraph
{
    class TwoEdgeConnectedGraphSol1
    {
        // O(v + e) time | O(v) space - where v is the number of
        // vertices and e is the number of edges in the graph
        public bool TwoEdgeConnectedGraph(int[][] edges)
        {
            if (edges.Length == 0) return true;
            int[] arrivalTimes = new int[edges.Length];
            Array.Fill(arrivalTimes, -1);
            int startVertex = 0;
            if (getMinimumArrivalTimeOfAncestors(startVertex, -1, 0, arrivalTimes,
            edges) == -1)
            {
                return false;
            }
            return areAllVerticesVisited(arrivalTimes);
        }
        public bool areAllVerticesVisited(int[] arrivalTimes)
        {
            foreach (var time in arrivalTimes)
            {
                if (time == -1)
                {
                    return false;
                }
            }
            return true;
        }
        public int getMinimumArrivalTimeOfAncestors(int currentVertex, int parent, int currentTime,
        int[] arrivalTimes, int[][] edges)
        {
            arrivalTimes[currentVertex] = currentTime;
            int minimumArrivalTime = currentTime;
            foreach (var destination in edges[currentVertex])
            {
                if (arrivalTimes[destination] == -1)
                {
                    minimumArrivalTime = Math.Min(minimumArrivalTime, getMinimumArrivalTimeOfAncestors(
                    destination, currentVertex, currentTime + 1,
                    arrivalTimes,
                    edges));
                }
                else if (destination != parent)
                {
                    minimumArrivalTime =
                    Math.Min(minimumArrivalTime, arrivalTimes[destination]);
                }
            }
            // A bridge was detected, which means the graph isn't two-edge-connected.
            if (minimumArrivalTime == currentTime && parent != -1)
            {
                return -1;
            }
            return minimumArrivalTime;
        }
    }
}
