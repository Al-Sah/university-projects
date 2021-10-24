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
        public int Workers; // TODO add check on AddTask 

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
            var scheduled = new Task(CalcExecutionTime(task), task);
            HistoryManager.AddLine(scheduled.Id);
            return TaskManager.AddTask(scheduled);
        }

        public void RemoveTask(string id)
        {
            TaskManager.RemoveTask(id);
        }

        private static int CalcExecutionTime(UserTask task)
        {
            int res;
            var time = task.Complexity switch
            {
                TaskComplexity.Elementary => 10,
                TaskComplexity.Normal => 20,
                TaskComplexity.Complicated => 40,
                TaskComplexity.Hard => 60,
                _ => throw new ArgumentOutOfRangeException()
            };

            res = time / task.TaskWorkers;
            if ((double) time / task.TaskWorkers - res != 0) res++;
            return res;
        }

        public int GetTaskExecutionTime(string taskId)
        {
            return TaskManager.GetTask(taskId).ExecutionTime;
        }

        public int GetTasksExecutionTime()
        {
            return TaskManager.GetTasks().Sum(task => task.ExecutionTime);
        }
    }
}