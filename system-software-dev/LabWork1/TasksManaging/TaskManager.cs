using System;
using System.Collections.Generic;

namespace LabWork1.TasksManaging
{
    public class TaskManager : ITaskManager
    {
        private readonly List<Task> _tasks;

        public TaskManager()
        {
            _tasks = new List<Task>();
        }

        public void Clear()
        {
            _tasks.Clear();
        }

        public void Print()
        {
            foreach (var task in _tasks)
            {
                Console.WriteLine(task);
            }
        }

        public string AddTask(Task task)
        {
            _tasks.Add(task);
            return task.Id;
        }

        public Task GetTask(string taskId)
        {
            return null;
        }

        public void RemoveTask(string taskId)
        {
            foreach (var task in _tasks)
            {
                if (!task.Id.Equals(taskId)) continue;
                _tasks.Remove(task);
                break;
            }
        }

        public int GetTasksNumber()
        {
            return _tasks.Count;
        }
    }
}