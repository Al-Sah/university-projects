using System;

namespace LabWork1.TasksManaging
{
    public class Task
    {
        public int ExecutionTime { get; set; }
        public string Id { get; set; }

        private readonly UserTask _clone;

        public Task(int time, ICloneable userTask)
        {
            Id = Guid.NewGuid().ToString();
            ExecutionTime = time;
            _clone = (UserTask) userTask.Clone();
        }

        public override string ToString()
        {
            return
                $"Task {Id}\n  Time: {ExecutionTime}; Complexity: {_clone.Complexity}, Workers: {_clone.TaskWorkers}";
        }
    }
}