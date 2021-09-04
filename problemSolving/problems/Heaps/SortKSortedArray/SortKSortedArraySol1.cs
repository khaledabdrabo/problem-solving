using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.SortKSortedArray
{
    class SortKSortedArraySol1
    {
        // O(nlog(k)) time | O(k) space - where n is the number
        // of elements in the array and k is how far away elements
        // are from their sorted position
        public int[] SortKSortedArray(int[] array, int k)
        {
            List<int> heapValues = new List<int>();
            for (int i = 0; i < Math.Min(k + 1, array.Length); i++) heapValues.Add(array[i]);
            MinHeap minHeapWithKElements = new MinHeap(heapValues);
            int nextIndexToInsertElement = 0;
            for (int idx = k + 1; idx < array.Length; idx++)
            {
                int minElement = minHeapWithKElements.remove();
                array[nextIndexToInsertElement] = minElement;
                nextIndexToInsertElement += 1;
                int currentElement = array[idx];
                minHeapWithKElements.insert(currentElement);
            }
            while (!minHeapWithKElements.isEmpty())
            {
                int minElement = minHeapWithKElements.remove();
                array[nextIndexToInsertElement] = minElement;
                nextIndexToInsertElement += 1;
            }
            return array;
        }
        public class MinHeap
        {
            List<int> heap = new List<int>();
            public MinHeap(List<int> array)
            {
                heap = buildHeap(array);
            }
            // O(n) time | O(1) space
            public List<int> buildHeap(List<int> array)
            {
                int firstParentIdx = (array.Count - 2) / 2;
                for (int currentIdx = firstParentIdx; currentIdx >= 0; currentIdx--)
                {
                    siftDown(currentIdx, array.Count - 1, array);
                }
                return array;
            }
            // O(log(n)) time | O(1) space
            public void siftDown(int currentIdx, int endIdx, List<int> heap)
            {
                int childOneIdx = currentIdx * 2 + 1;
                while (childOneIdx <= endIdx)
                {
                    int childTwoIdx = currentIdx * 2 + 2 <=
                    endIdx ? currentIdx * 2 + 2 : -1;
                    int idxToSwap;
                    if (childTwoIdx != -1 && heap[childTwoIdx] < heap[childOneIdx])
                    {
                        idxToSwap = childTwoIdx;
                    }
                    else
                    {
                        idxToSwap = childOneIdx;
                    }
                    if (heap[idxToSwap] < heap[currentIdx])
                    {
                        swap(currentIdx, idxToSwap, heap);
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
            public void siftUp(int currentIdx, List<int> heap)
            {
                int parentIdx = (currentIdx - 1) / 2;
                while (currentIdx > 0 && heap[currentIdx] < heap[parentIdx])
                {
                    swap(currentIdx, parentIdx, heap);
                    currentIdx = parentIdx;
                    parentIdx = (currentIdx - 1) / 2;
                }
            }
            public int peek()
            {
                return heap[0];
            }
            public int remove()
            {
                swap(0, heap.Count - 1, heap);
                int valueToRemove = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                siftDown(0, heap.Count - 1, heap);
                return valueToRemove;
            }
            public void insert(int value)
            {
                heap.Add(value);
                siftUp(heap.Count - 1, heap);
            }
            public void swap(int i, int j, List<int> heap)
            {
                int temp = heap[j];
                heap[j] = heap[i];
                heap[i] = temp;
            }
            public bool isEmpty()
            {
                return heap.Count == 0;
            }
        }

    }
}
