using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.CycleInGraph
{
    class CycleInGraphSol2
    {
        int WHITE = 0;
        int GREY = 1;
        int BLACK = 3;
        // O(v + e) time | O(v) space - where v is the number of
        // vertices and e is the number of edges in the graph
        public bool CycleInGraph(int[][] edges)
        {
            int numberOfNodes = edges.Length;
            int[] colors = new int[numberOfNodes];
            Array.Fill(colors, WHITE);
            for (int node = 0; node < numberOfNodes; node++)
            {
                if (colors[node] != WHITE) continue;
                bool containsCycle = traverseAndColorNodes(node, edges, colors);
                if (containsCycle) return true;
            }
            return false;
        }
        public bool traverseAndColorNodes(int node, int[][] edges, int[] colors)
        {
            colors[node] = GREY;
            int[] neighbors = edges[node];
            foreach (var neighbor in neighbors)
            {
                int neighborColor = colors[neighbor];
                if (neighborColor == GREY)
                {
                    return true;
                }
                if (neighborColor == BLACK)
                {
                    continue;
                }
                bool containsCycle = traverseAndColorNodes(neighbor, edges, colors);
                if (containsCycle)
                {
                    return true;
                }
            }
            colors[node] = BLACK;
            return false;
        }
    }
}
