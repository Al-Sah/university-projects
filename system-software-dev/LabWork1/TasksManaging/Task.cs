using System;

namespace LabWork1.TasksManaging
{
    public class Task
    {
        public int ExecutionTime { get; set; }
        public string Id { get; set; }

        public UserTask Clone;

        public Task(int time, ICloneable userTask)
        {
            Id = Guid.NewGuid().ToString();
            ExecutionTime = time;
            Clone = (UserTask) userTask.Clone();
        }
    }
}