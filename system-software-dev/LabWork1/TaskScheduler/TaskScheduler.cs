using System;
using System.Collections.Generic;

namespace LabWork1.TaskScheduler
{
    public class TaskScheduler : ITaskScheduler
    {
        private List<string> _history;

        public TaskScheduler()
        {
            Console.WriteLine("TaskScheduler created");
            _history = new List<string> {"task1", "task2", "task3"};
        }

        public void ClearHistory()
        {
            Console.WriteLine("Clear History");
            _history.Clear();
        }

        public void ShowHistory()
        {
            foreach (var str in _history)
            {
                Console.WriteLine(str);
            }
        }

        public void ClearTasks()
        {
            Console.WriteLine("Clear Tasks");
        }

        public void AddTask(UserTask task)
        {
            Console.WriteLine("Add Task");
        }

        public int GetTasksExecutionTime()
        {
            Console.WriteLine("Time ...");
            return new Random().Next();
        }
    }
}