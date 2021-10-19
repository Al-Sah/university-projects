using System;

namespace LabWork1
{
    class TaskSchedulerTester
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var taskScheduler = new TaskScheduler.TaskScheduler();
            Console.WriteLine(taskScheduler.GetTasksExecutionTime());
            taskScheduler.ShowHistory();
            taskScheduler.ClearHistory();
            taskScheduler.ShowHistory();

            var task = new UserTask(10);
            taskScheduler.AddTask(task);
            Console.WriteLine(taskScheduler.GetTasksExecutionTime());
        }
    }
}