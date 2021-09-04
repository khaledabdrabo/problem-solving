using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.DijkstrasAlgorithm
{
    class DijkstrasAlgorithmSol2
    {
        // O((v + e) * log(v)) time | O(v) space - where v is the number
        // of vertices and e is the number of edges in the input graph
        public int[] DijkstrasAlgorithm(int start, int[][][] edges)
        {
            int numberOfVertices = edges.Length;
            int[] minDistances = new int[numberOfVertices];
            Array.Fill(minDistances, Int32.MaxValue);
            minDistances[start] = 0;
            List<Item> minDistancesPairs = new List<Item>();
            for (int i = 0; i < numberOfVertices; i++)
            {
                Item item = new Item(i, Int32.MaxValue);
                minDistancesPairs.Add(item);
            }
            MinHeap minDistancesHeap = new MinHeap(minDistancesPairs);
            minDistancesHeap.Update(start, 0);
            while (!minDistancesHeap.isEmpty())
            {
                Item heapItem = minDistancesHeap.Remove();
                int vertex = heapItem.vertex;
                int currentMinDistance = heapItem.distance;
                if (currentMinDistance == Int32.MaxValue)
                {
                    break;
                }
                foreach (var edge in edges[vertex])
                {
                    int destination = edge[0];
                    int distanceToDestination = edge[1];
                    int newPathDistance = currentMinDistance + distanceToDestination;
                    int currentDestinationDistance = minDistances[destination];
                    if (newPathDistance < currentDestinationDistance)
                    {
                        minDistances[destination] = newPathDistance;
                        minDistancesHeap.Update(destination, newPathDistance);
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
        public class Item
        {
            public int vertex;
            public int distance;
            public Item(int vertex, int distance)
            {
                this.vertex = vertex;
                this.distance = distance;
            }
        };
        public class MinHeap
        {
            Dictionary<int, int> vertexDictionary = new Dictionary<int, int>();
            List<Item> heap = new List<Item>();
            public MinHeap(List<Item> array)
            {
                for (int i = 0; i < array.Count; i++)
                {
                    Item item = array[i];
                    vertexDictionary[item.vertex] = item.vertex;
                }
                heap = buildHeap(array);
            }
            List<Item> buildHeap(List<Item> array)
            {
                int firstParentIdx = (array.Count - 2) / 2;
                for (int currentIdx = firstParentIdx + 1; currentIdx >= 0; currentIdx--)
                {
                    siftDown(currentIdx, array.Count - 1, array);
                }
                return array;
            }
            public bool isEmpty()
            {
                return heap.Count == 0;
            }
            void siftDown(int currentIdx, int endIdx, List<Item> heap)
            {
                int childOneIdx = currentIdx * 2 + 1;
                while (childOneIdx <= endIdx)
                {
                    int childTwoIdx = currentIdx * 2 + 2 <=
                    endIdx ? currentIdx * 2 + 2 : -1;
                    int idxToSwap;
                    if (childTwoIdx != -1 &&
                    heap[childTwoIdx].distance < heap[childOneIdx].distance)
                    {
                        idxToSwap = childTwoIdx;
                    }
                    else
                    {
                        idxToSwap = childOneIdx;
                    }
                    if (heap[idxToSwap].distance < heap[currentIdx].distance)
                    {
                        swap(currentIdx, idxToSwap);
                        currentIdx = idxToSwap;
                        childOneIdx = currentIdx * 2 + 1;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            void siftUp(int currentIdx)
            {
                int parentIdx = (currentIdx - 1) / 2;
                while (currentIdx > 0 &&
                heap[currentIdx].distance < heap[parentIdx].distance)
                {
                    swap(currentIdx, parentIdx);
                    currentIdx = parentIdx;
                    parentIdx = (currentIdx - 1) / 2;
                }
            }
            public Item Remove()
            {
                swap(0, heap.Count - 1);
                Item lastItem = heap[heap.Count - 1];
                int vertex = lastItem.vertex;
                int distance = lastItem.distance;
                heap.RemoveAt(heap.Count - 1);
                vertexDictionary.Remove(vertex);
                siftDown(0, heap.Count - 1, heap);
                return new Item(vertex, distance);
            }
            public void Update(int vertex, int value)
            {
                heap[vertexDictionary[vertex]] = new Item(vertex, value);
                siftUp(vertexDictionary[vertex]);
            }
            void swap(int i, int j)
            {
                vertexDictionary[heap[i].vertex] = j;
                vertexDictionary[heap[j].vertex] = i;
                Item temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
            }

        }
    }
}
