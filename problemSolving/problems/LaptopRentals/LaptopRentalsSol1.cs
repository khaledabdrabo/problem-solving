using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.LaptopRentals
{
    class LaptopRentalsSol1
    {
        // O(nlog(n)) time | O(n) space - where n is the number of times
        public int LaptopRentals(List<List<int>> times)
        {
            if (times.Count == 0)
            {
                return 0;
            }
            times.Sort((a, b) => a[0].CompareTo(b[0]));
            List<List<int>> timesWhenLaptopIsUsed = new List<List<int>>();
            timesWhenLaptopIsUsed.Add(times[0]);
            MinHeap heap = new MinHeap(timesWhenLaptopIsUsed);
            for (int idx = 1; idx < times.Count; idx++)
            {
                List<int> currentInterval = times[idx];
                if (heap.peek()[1] <= currentInterval[0])
                {
                    heap.remove();
                }
                heap.insert(currentInterval);
            }
            return timesWhenLaptopIsUsed.Count;
        }
        public class MinHeap
        {
            List<List<int>> heap = new List<List<int>>();
            public MinHeap(List<List<int>> array)
            {
                heap = buildHeap(array);
            }
            public List<List<int>> buildHeap(List<List<int>> array)
            {
                int firstParentIdx = (array.Count - 2) / 2;
                for (int currentIdx = firstParentIdx; currentIdx >= 0; currentIdx--)
                {
                    siftDown(currentIdx, array.Count - 1, array);
                }
                return array;
            }
            public void siftDown(int currentIdx, int endIdx, List<List<int>> heap)
            {
                int newCurrentIdx = currentIdx;
                int childOneIdx = currentIdx * 2 + 1;
                while (childOneIdx <= endIdx)
                {
                    int childTwoIdx =
                    (newCurrentIdx * 2 + 2 <= endIdx) ? newCurrentIdx * 2 + 2 : -1;
                    int idxToSwap;
                    if (childTwoIdx != -1 &&
                    heap[childTwoIdx][1] < heap[childOneIdx][1])
                    {
                        idxToSwap = childTwoIdx;
                    }
                    else
                    {
                        idxToSwap = childOneIdx;
                    }
                    if (heap[idxToSwap][1] < heap[currentIdx][1])
                    {
                        swap(newCurrentIdx, idxToSwap, heap);
                        newCurrentIdx = idxToSwap;
                        childOneIdx = newCurrentIdx * 2 + 1;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            public void siftUp(int currentIdx, List<List<int>> heap)
            {
                int newCurrentIdx = currentIdx;
                int parentIdx = (currentIdx - 1) / 2;
                while (newCurrentIdx > 0 && heap[newCurrentIdx][1] < heap[parentIdx][1])
                {
                    swap(newCurrentIdx, parentIdx, heap);
                    newCurrentIdx = parentIdx;
                    parentIdx = (newCurrentIdx - 1) / 2;
                }
            }
            public List<int> peek()
            {
                return heap[0];
            }
            public List<int> remove()
            {
                swap(0, heap.Count - 1, heap);
                List<int> valueToRemove = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                siftDown(0, heap.Count - 1, heap);
                return valueToRemove;
            }
            public void insert(List<int> value)
            {
                heap.Add(value);
                siftUp(heap.Count - 1, heap);
            }
            public void swap(int i, int j, List<List<int>> heap)
            {
                List<int> temp = heap[j];
                heap[j] = heap[i];
                heap[i] = temp;
            }
        }
    }
}
