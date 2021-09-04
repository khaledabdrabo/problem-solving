using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.TaskAssignment
{
    class TaskAssignmentSol1
    {   //O(nlog(n)) time | O(n) space - where n is the number of tasks
        public List<List<int>> TaskAssignment(int k, List<int> tasks)
        {
            List<List<int>> pairedTasks = new List<List<int>>();
            Dictionary<int,
            List<int>> taskDurationsToIndices = getTaskDurationsToIndices(tasks);
            List<int> sortedTasks = tasks;
            sortedTasks.Sort();
            for (int idx = 0; idx < k; idx++)
            {
                int task1Duration = sortedTasks[idx];
                List<int> indicesWithTask1Duration = taskDurationsToIndices[task1Duration];
                int task1Index =
                indicesWithTask1Duration[indicesWithTask1Duration.Count - 1];
                indicesWithTask1Duration.RemoveAt(indicesWithTask1Duration.Count - 1);
                int task2SortedIndex = tasks.Count - 1 - idx;
                int task2Duration = sortedTasks[task2SortedIndex];
                List<int> indicesWithTask2Duration = taskDurationsToIndices[task2Duration];
                int task2Index =
                indicesWithTask2Duration[indicesWithTask2Duration.Count - 1];
                indicesWithTask2Duration.RemoveAt(indicesWithTask2Duration.Count - 1);
                List<int> pairedTask = new List<int>();
                pairedTask.Add(task1Index);
                pairedTask.Add(task2Index);
                pairedTasks.Add(pairedTask);
            }
            return pairedTasks;
        }
        public Dictionary<int, List<int>> getTaskDurationsToIndices(List<int> tasks)
        {
            Dictionary<int,
            List<int>> taskDurationsToIndices = new Dictionary<int, List<int>>();
            for (int idx = 0; idx < tasks.Count; idx++)
            {
                int taskDuration = tasks[idx];
                if (taskDurationsToIndices.ContainsKey(taskDuration))
                {
                    taskDurationsToIndices[taskDuration].Add(idx);
                }
                else
                {
                    List<int> temp = new List<int>();
                    temp.Add(idx);
                    taskDurationsToIndices[taskDuration] = temp;
                }
            }
            return taskDurationsToIndices;
        }
    }
}
