namespace LabWork1.TasksManaging
{
    public interface ITaskManager
    {
        void Clear();
        void Print();

        int GetTasksNumber();
        string AddTask(Task task); // return task id

        Task GetTask(string taskId);
        void RemoveTask(string taskId);
    }
}