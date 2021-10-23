using System;

namespace LabWork1
{
    public class UserTask : ICloneable
    {
        public TaskComplexity Complexity { get; set; }
        public int TaskWorkers { get; set; }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public UserTask()
        {
            Complexity = TaskComplexity.Normal;
            TaskWorkers = 1;
        }

        public UserTask(TaskComplexity complexity, int taskWorkers)
        {
            Complexity = complexity;
            TaskWorkers = taskWorkers;
        }
    }
}