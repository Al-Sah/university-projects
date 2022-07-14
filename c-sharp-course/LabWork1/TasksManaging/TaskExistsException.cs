#nullable enable
using System;
using System.Runtime.Serialization;

namespace LabWork1.TasksManaging
{
    public class TaskExistsException : Exception
    {
        public TaskExistsException()
        {
        }

        protected TaskExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TaskExistsException(string? message) : base(message)
        {
        }

        public TaskExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}