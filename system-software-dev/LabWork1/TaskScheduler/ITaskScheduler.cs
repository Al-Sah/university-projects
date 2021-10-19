namespace LabWork1.TaskScheduler
{
    public interface ITaskScheduler
    {
        void ClearHistory();
        void ShowHistory();

        void ClearTasks();
        void AddTask(UserTask task);
        int GetTasksExecutionTime();
    }
}