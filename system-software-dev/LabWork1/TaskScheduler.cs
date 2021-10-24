using System;
using System.Collections.Generic;
using System.Linq;
using LabWork1.HistoryManaging;
using LabWork1.TasksManaging;

namespace LabWork1
{
    public class TaskScheduler
    {
        public IHistoryManager HistoryManager { private get; set; }
        public ITaskManager TaskManager { private get; set; }
        public readonly int Workers;

        public TaskScheduler()
        {
            HistoryManager = new HistoryManager();
            TaskManager = new TaskManager();
            Workers = 100;
        }

        public TaskScheduler(int workers, IHistoryManager historyManager, ITaskManager taskManager)
        {
            Workers = workers;
            HistoryManager = historyManager;
            TaskManager = taskManager;
        }

        public void Execute(IEnumerable<UserTask> userTask)
        {
            ResetTasks(userTask);
            PrintTasks();
            Console.WriteLine(
                $"{TaskManager.GetTasksNumber().ToString()} tasks will be executed in: {GetTasksExecutionTime().ToString()} minutes\n");
            PrintHistory();
        }

        public void ResetTasks(IEnumerable<UserTask> userTask)
        {
            ClearTasks();
            foreach (var task in userTask)
            {
                AddTask(task);
            }
        }

        public void ClearTasks()
        {
            TaskManager.Clear();
        }

        public void PrintTasks()
        {
            TaskManager.Print();
        }

        public void PrintHistory()
        {
            HistoryManager.Print();
        }

        public void ClearHistory()
        {
            HistoryManager.Clear();
        }


        // return task id
        public string AddTask(UserTask task)
        {
            if (!Enumerable.Range(1, Workers).Contains(task.TaskWorkers))
            {
                Console.WriteLine($"AddTask error: task workers have to be in range: [1, {Workers.ToString()}]");
                return "";
            }

            var scheduled = new Task(CalcExecutionTime(task), task);
            try
            {
                TaskManager.AddTask(scheduled);
                HistoryManager.AddLine(scheduled.Id);
            }
            catch (TaskExistsException)
            {
                Console.WriteLine($"Task with id '{scheduled.Id}' exists");
            }

            return scheduled.Id;
        }

        public void RemoveTask(string id)
        {
            try
            {
                TaskManager.RemoveTask(id);
            }
            catch (TaskNotFoundException)
            {
                Console.WriteLine($"Task '{id}' not found");
            }
        }

        private static int CalcExecutionTime(UserTask task)
        {
            var time = task.Complexity switch
            {
                TaskComplexity.Elementary => 10,
                TaskComplexity.Normal => 20,
                TaskComplexity.Complicated => 40,
                TaskComplexity.Hard => 60,
                _ => throw new ArgumentOutOfRangeException()
            };
            var res = time / task.TaskWorkers;
            if ((double) time / task.TaskWorkers - res != 0) res++;
            return res;
        }

        public int GetTaskExecutionTime(string taskId)
        {
            try
            {
                return TaskManager.GetTask(taskId).ExecutionTime;
            }
            catch (TaskNotFoundException)
            {
                Console.WriteLine($"Task '{taskId}' not found");
            }

            return 0;
        }

        public int GetTasksExecutionTime()
        {
            return TaskManager.GetTasks().Sum(task => task.ExecutionTime);
        }
    }
}