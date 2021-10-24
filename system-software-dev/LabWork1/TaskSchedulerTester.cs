using System;
using LabWork1.HistoryManaging;

namespace LabWork1
{
    static class TaskSchedulerTester
    {
        public static void Main()
        {
            var taskScheduler = new TaskScheduler();

            var tasks = new[]
            {
                new UserTask(),
                new UserTask(TaskComplexity.Hard, 10),
                new UserTask(),
                new UserTask(TaskComplexity.Elementary, 5),
                new UserTask(TaskComplexity.Complicated, 2)
            };

            taskScheduler.Execute(tasks);
            taskScheduler.ClearTasks();


            taskScheduler.HistoryManager = new AdvancedHistoryManager();
            Console.WriteLine(
                $"Task time: {taskScheduler.GetTaskExecutionTime(taskScheduler.AddTask(tasks[1])).ToString()}");
            var id = taskScheduler.AddTask(tasks[2]);

            taskScheduler.AddTask(new UserTask(TaskComplexity.Hard, 30));
            Console.WriteLine($"Tasks time: {taskScheduler.GetTasksExecutionTime().ToString()}");
            taskScheduler.PrintTasks();
            taskScheduler.RemoveTask(id);
            taskScheduler.RemoveTask("zzz");

            taskScheduler.PrintHistory();
            taskScheduler.ClearHistory();
        }
    }
}