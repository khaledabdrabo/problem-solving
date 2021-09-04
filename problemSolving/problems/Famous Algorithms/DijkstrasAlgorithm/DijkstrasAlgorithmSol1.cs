using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.DijkstrasAlgorithm
{
    class DijkstrasAlgorithmSol1
    {
        // O(v^2 + e) time | O(v) space - where v is the number of
        // vertices and e is the number of edges in the input graph
        public int[] DijkstrasAlgorithm(int start, int[][][] edges)
        {
            int numberOfVertices = edges.Length;
            int[] minDistances = new int[edges.Length];
            Array.Fill(minDistances, Int32.MaxValue);
            minDistances[start] = 0;
            HashSet<int> visited = new HashSet<int>();
            while (visited.Count != numberOfVertices)
            {
                int[] getVertexData = getVertexWithMinDistances(minDistances, visited);
                int vertex = getVertexData[0];
                int currentMinDistance = getVertexData[1];
                if (currentMinDistance == Int32.MaxValue)
                {
                    break;
                }
                visited.Add(vertex);
                foreach (var edge in edges[vertex])
                {
                    int destination = edge[0];
                    int distanceToDestination = edge[1];
                    if (visited.Contains(destination))
                    {
                        continue;
                    }
                    int newPathDistance = currentMinDistance + distanceToDestination;
                    int currentDestinationDistance = minDistances[destination];
                    if (newPathDistance < currentDestinationDistance)
                    {
                        minDistances[destination] = newPathDistance;
                    }
                }
            }
            int[] finalDistances = new int[minDistances.Length];
            for (int i = 0; i < minDistances.Length; i++)
            {
                int distance = minDistances[i];
                if (distance == Int32.MaxValue)
                {
                    finalDistances[i] = -1;
                }
                else
                {
                    finalDistances[i] = distance;
                }
            }
            return finalDistances;
        }
        public int[] getVertexWithMinDistances(int[] distances, HashSet<int> visited)
        {
            int currentMinDistance = Int32.MaxValue;
            int vertex = -1;
            for (int vertexIdx = 0; vertexIdx < distances.Length; vertexIdx++)
            {
                int distance = distances[vertexIdx];
                if (visited.Contains(vertexIdx))
                {
                    continue;
                }
                if (distance <= currentMinDistance)
                {
                    vertex = vertexIdx;
                    currentMinDistance = distance;
                }
            }
            return new int[] { vertex, currentMinDistance };
        }
    }
}
