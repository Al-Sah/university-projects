using System.Collections.Generic;
using LabWork1.HistoryManaging;
using LabWork1.TasksManaging;

namespace LabWork1
{
    public class TaskScheduler
    {
        public IHistoryManager HistoryManager { private get; set; }
        public ITaskManager TaskManager { private get; set; }
        public int Workers;

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


        // return task id
        public string AddTask(UserTask task)
        {
            var scheduled = new Task(CalcExecutionTime(task), task);
            return TaskManager.AddTask(scheduled);
        }

        /*void RemoveTask(int taskId);
        int GetTasksNumber();*/


        private int CalcExecutionTime(UserTask task)
        {
            return 0;
        }

        public int GetTaskExecutionTime(int taskId)
        {
            return 0;
        }

        public int GetTasksExecutionTime()
        {
            return 0;
        }
    }
}