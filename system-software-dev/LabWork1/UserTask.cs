using System;

namespace LabWork1
{
    public class UserTask : ICloneable
    {
        public TaskComplexity Complexity { get; set; }
        public int TaskWorkers { get; set; }

        public string Description { get; set; }

        public object Clone()
        {
            return new UserTask(Complexity, TaskWorkers, Description);
        }

        public UserTask()
        {
            Complexity = TaskComplexity.Normal;
            TaskWorkers = 1;
            Description = "N/A";
        }

        public UserTask(TaskComplexity complexity, int taskWorkers, string description = "N/A")
        {
            Complexity = complexity;
            TaskWorkers = taskWorkers;
            Description = description;
        }

        public override string ToString()
        {
            return $"Description: {Description}, Complexity: {Complexity}, Workers: {TaskWorkers.ToString()}";
        }
    }
}