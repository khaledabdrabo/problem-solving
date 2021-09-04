using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.DetectArbitrage
{
    class DetectArbitrageSol1
    {
        // O(n^3) time | O(n^2) space - where n is the number of currencies
        public bool DetectArbitrage(List<List<Double>> exchangeRates)
        {
            // To use exchange rates as edge weights, we must be able to add them.
            // Since log(a*b) = log(a) + log(b), we can convert all rates to
            // -log10(rate) to use them as edge weights.
            List<List<Double>> logExchangeRates = convertToLogMatrix(exchangeRates);
            // A negative weight cycle indicates an arbitrage.
            return foundNegativeWeightCycle(logExchangeRates, 0);
        }
        // Runs the Bellman–Ford Algorithm to detect any negative-weight cycles.
        public bool foundNegativeWeightCycle(List<List<Double>> graph, int start)
        {
            double[] distancesFromStart = new double[graph.Count];
            Array.Fill(distancesFromStart, Double.MaxValue);
            distancesFromStart[start] = 0;
            for (int unused = 0; unused < graph.Count; unused++)
            {
                // If no update occurs, that means there's no negative cycle.
                if (!relaxEdgesAndUpdateDistances(graph, distancesFromStart))
                {
                    return false;
                }
            }
            return relaxEdgesAndUpdateDistances(graph, distancesFromStart);
        }
        // Returns `true` if any distance was updated
        public bool relaxEdgesAndUpdateDistances(List<List<Double>> graph, double[] distances)
        {
            bool updated = false;
            for (int sourceIdx = 0; sourceIdx < graph.Count; sourceIdx++)
            {
                List<Double> edges = graph[sourceIdx];
                for (int destinationIdx = 0; destinationIdx < edges.Count;
                destinationIdx++)
                {
                    double edgeWeight = edges[destinationIdx];
                    double newDistanceToDestination = distances[sourceIdx] + edgeWeight;
                    if (newDistanceToDestination < distances[destinationIdx])
                    {
                        updated = true;
                        distances[destinationIdx] = newDistanceToDestination;
                    }
                }
            }
            return updated;
        }
        public List<List<Double>> convertToLogMatrix(List<List<Double>> matrix)
        {
            List<List<Double>> newMatrix = new List<List<Double>>();
            for (int row = 0; row < matrix.Count; row++)
            {
                List<Double> rates = matrix[row];
                newMatrix.Add(new List<Double>());
                foreach (var rate in rates)
                {
                    newMatrix[row].Add(-Math.Log10(rate));
                }
            }
            return newMatrix;
        }

    }
}
