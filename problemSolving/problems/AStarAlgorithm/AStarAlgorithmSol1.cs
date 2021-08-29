using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.AStarAlgorithm
{
    class AStarAlgorithmSol1
    {
        // O(w * h * log(w * h)) time | O(w * h) space - where
        // w is the width of the graph and h is the height
        public int[][] AStarAlgorithm(int startRow, int startCol, int endRow, int endCol,
        int[][] graph)
        {
            List<List<Node>> nodes = initializeNodes(graph);
            Node startNode = nodes[startRow][startCol];
            Node endNode = nodes[endRow][endCol];
            startNode.distanceFromStart = 0;
            startNode.estimatedDistanceToEnd = calculateManhattanDistance(startNode, endNode);
            List<Node> nodesToVisitList = new List<Node>();
            nodesToVisitList.Add(startNode);
            MinHeap nodesToVisit = new MinHeap(nodesToVisitList);
            while (!nodesToVisit.isEmpty())
            {
                Node currentMinDistanceNode = nodesToVisit.Remove();
                if (currentMinDistanceNode == endNode)
                {
                    break;
                }
                List<Node> neighbors = getNeightboringNodes(currentMinDistanceNode, nodes);
                foreach (var neighbor in neighbors)
                {
                    if (neighbor.value == 1)
                    {
                        continue;
                    }
                    int tentativeDistanceToNeighbor =
                    currentMinDistanceNode.distanceFromStart + 1;
                    if (tentativeDistanceToNeighbor >= neighbor.distanceFromStart)
                    {
                        continue;
                    }
                    neighbor.cameFrom = currentMinDistanceNode;
                    neighbor.distanceFromStart = tentativeDistanceToNeighbor;
                    neighbor.estimatedDistanceToEnd = tentativeDistanceToNeighbor +
                    calculateManhattanDistance(neighbor, endNode);
                    if (!nodesToVisit.ContainsNode(neighbor))
                    {
                        nodesToVisit.Insert(neighbor);
                    }
                    else
                    {
                        nodesToVisit.Update(neighbor);
                    }
                }
            }
            return reconstructPath(endNode);
        }
        List<List<Node>> initializeNodes(int[][] graph)
        {
            List<List<Node>> nodes = new List<List<Node>>();
            for (int i = 0; i < graph.Length; i++)
            {
                List<Node> nodeList = new List<Node>();
                nodes.Add(nodeList);
                for (int j = 0; j < graph[i].Length; j++)
                {
                    nodes[i].Add(new Node(i, j, graph[i][j]));
                }
            }
            return nodes;

        }
        int calculateManhattanDistance(Node currentNode, Node endNode)
        {
            int currentRow = currentNode.row;
            int currentCol = currentNode.col;
            int endRow = endNode.row;
            int endCol = endNode.col;
            return Math.Abs(currentRow - endRow) + Math.Abs(currentCol - endCol);
        }
        List<Node> getNeightboringNodes(Node node, List<List<Node>> nodes)
        {
            List<Node> neighbors = new List<Node>();
            int numRows = nodes.Count;
            int numCols = nodes[0].Count;
            int row = node.row;
            int col = node.col;
            if (row < numRows - 1)
            { // DOWN
                neighbors.Add(nodes[row + 1][col]);
            }
            if (row > 0)
            { // UP
                neighbors.Add(nodes[row - 1][col]);
            }
            if (col < numCols - 1)
            { // RIGHT
                neighbors.Add(nodes[row][col + 1]);
            }
            if (col > 0)
            { // LEFT
                neighbors.Add(nodes[row][col - 1]);
            }
            return neighbors;
        }
        int[][] reconstructPath(Node endNode)
        {
            if (endNode.cameFrom == null)
            {
                return new int[][] { };
            }
            Node currentNode = endNode;
            List<List<int>> path = new List<List<int>>();
            while (currentNode != null)
            {
                List<int> nodeData = new List<int>();
                nodeData.Add(currentNode.row);
                nodeData.Add(currentNode.col);
                path.Add(nodeData);
                currentNode = currentNode.cameFrom;
            }
            // convert path to return type int[][] and reverse
            int[][] res = new int[path.Count][];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = path[res.Length - 1 - i].ToArray();
            }
            return res;
        }
        public class Node
        {
            public string id;
            public int row;
            public int col;
            public int value;
            public int distanceFromStart;
            public int estimatedDistanceToEnd;
            public Node cameFrom;
            public Node(int row, int col, int value)
            {
                this.id = row.ToString() + '-' + col.ToString();
                this.row = row;
                this.col = col;
                this.value = value;
                this.distanceFromStart = Int32.MaxValue;
                this.estimatedDistanceToEnd = Int32.MaxValue;
                this.cameFrom = null;
            }
        };
        public class MinHeap
        {
            List<Node> heap = new List<Node>();
            Dictionary<string, int> nodePositionsInHeap = new Dictionary<string, int>();
            public MinHeap(List<Node> array)
            {
                for (int i = 0; i < array.Count; i++)
                {
                    Node node = array[i];
                    nodePositionsInHeap[node.id] = i;
                }
                heap = buildHeap(array);
            }
            // O(n) time | O(1) space
            List<Node> buildHeap(List<Node> array)
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
            // O(log(n)) time | O(1) space
            void siftDown(int currentIdx, int endIdx, List<Node> array)
            {
                int childOneIdx = currentIdx * 2 + 1;
                while (childOneIdx <= endIdx)
                {
                    int childTwoIdx = currentIdx * 2 + 2 <=
                    endIdx ? currentIdx * 2 + 2 : -1;
                    int idxToSwap;
                    if (childTwoIdx != -1 &&
                    array[childTwoIdx].estimatedDistanceToEnd <
                    heap[childOneIdx].estimatedDistanceToEnd)
                    {
                        idxToSwap = childTwoIdx;
                    }
                    else
                    {
                        idxToSwap = childOneIdx;
                    }
                    if (array[idxToSwap].estimatedDistanceToEnd <
                    array[currentIdx].estimatedDistanceToEnd)
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
            // O(log(n)) time | O(1) space
            void siftUp(int currentIdx)
            {
                int parentIdx = (currentIdx - 1) / 2;
                while (currentIdx > 0 &&
                heap[currentIdx].estimatedDistanceToEnd <
                heap[parentIdx].estimatedDistanceToEnd)
                {
                    swap(currentIdx, parentIdx);
                    currentIdx = parentIdx;
                    parentIdx = (currentIdx - 1) / 2;
                }
            }
            public Node Remove()
            {
                if (isEmpty())
                {
                    return null;
                }
                swap(0, heap.Count - 1);
                Node node = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                nodePositionsInHeap.Remove(node.id);
                siftDown(0, heap.Count - 1, heap);
                return node;
            }
            public void Insert(Node node)
            {
                heap.Add(node);
                nodePositionsInHeap[node.id] = heap.Count - 1;
                siftUp(heap.Count - 1);
            }
            public void Update(Node node)
            {
                siftUp(nodePositionsInHeap[node.id]);
            }
            public bool ContainsNode(Node node)
            {
                return nodePositionsInHeap.ContainsKey(node.id);
            }
            void swap(int i, int j)
            {
                nodePositionsInHeap[heap[i].id] = j;
                nodePositionsInHeap[heap[j].id] = i;
                Node temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
            }
        };
    }



}
