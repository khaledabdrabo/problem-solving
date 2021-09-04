using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.CycleInGraph
{
    class CycleInGraphSol1
    {
        // O(v + e) time | O(v) space - where v is the number of
        // vertices and e is the number of edges in the graph
        public bool CycleInGraph(int[][] edges)
        {
            int numberOfNodes = edges.Length;
            bool[] visited = new bool[numberOfNodes];
            bool[] currentlyInStack = new bool[numberOfNodes];
            Array.Fill(visited, false);
            Array.Fill(currentlyInStack, false);
            for (int node = 0; node < numberOfNodes; node++)
            {
                if (visited[node])
                {
                    continue;
                }
                bool containsCycle = isNodeInCycle(node, edges, visited, currentlyInStack);
                if (containsCycle)
                {
                    return true;
                }
            }
            return false;
        }
        public bool isNodeInCycle(int node, int[][] edges, bool[] visited,
        bool[] currentlyInStack)
        {
            visited[node] = true;
            currentlyInStack[node] = true;
            bool containsCycle = false;
            int[] neighbors = edges[node];
            foreach (var neighbor in neighbors)
            {
                if (!visited[neighbor])
                {
                    containsCycle = isNodeInCycle(neighbor, edges, visited,
                    currentlyInStack);
                }
                if (containsCycle)
                {
                    return true;
                }
                else if (currentlyInStack[neighbor])
                {
                    return true;
                }
            }
            currentlyInStack[node] = false;
            return false;
        }
    }
}
