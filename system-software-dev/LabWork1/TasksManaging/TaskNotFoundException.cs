#nullable enable
using System;
using System.Runtime.Serialization;

namespace LabWork1.TasksManaging
{
    public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException()
        {
        }

        protected TaskNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TaskNotFoundException(string? message) : base(message)
        {
        }

        public TaskNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}