using System;
using System.Diagnostics;

namespace LabWork3.Core
{
    public class ProcessInfo
    {
        public string Priority { get; private set; }
        public string Name { get; private set; }
        public int ProcessorAffinity { get; private set; }
        public long Memory { get; private set; }
        public string Path { get; private set; }
        public int Pid { get; private set; }

        private Process _process;

        private const string Error = "- - - -";


        public ProcessInfo(Process process) => GetData(process);
        public ProcessInfo() => GetData(Process.GetCurrentProcess());

        private void GetData(Process process)
        {
            _process = process;

            // ReSharper disable once PossibleNullReferenceException
            Path = (string) ValidateProperty(() => _process.MainModule.FileName, string.Empty.GetType());

            Memory = (long) ValidateProperty(() => _process.WorkingSet64 / 1024, Memory.GetType()); // TO KBytes
            Name = (string) ValidateProperty(() => _process.ProcessName, string.Empty.GetType());
            Pid = (int) ValidateProperty(() => _process.Id, Pid.GetType());
            Priority = (string) ValidateProperty(() => _process.PriorityClass, string.Empty.GetType());
            ProcessorAffinity =
                (int) ValidateProperty(() => _process.ProcessorAffinity.ToInt32(), ProcessorAffinity.GetType());
        }

        private static object ValidateProperty(Func<object> valueGetter, Type toReturn)
        {
            // Win32Exception || InvalidOperationException || NullReferenceException
            try
            {
                return valueGetter() is long or int ? valueGetter() : valueGetter().ToString();
            }
            catch (Exception)
            {
                if (toReturn == typeof(long) || toReturn == typeof(int))
                {
                    return 0;
                }

                return Error;
            }
        }


        public static ProcessInfo operator ++(ProcessInfo process)
        {
            try
            {
                process._process.PriorityClass = IncrementProcessPriorityClass(process._process.PriorityClass);
                process.Priority = process._process.PriorityClass.ToString();
            }
            catch (Exception)
            {
                // ignored
            }

            return process;
        }

        public static ProcessInfo operator --(ProcessInfo process)
        {
            try
            {
                process._process.PriorityClass = DecrementProcessPriorityClass(process._process.PriorityClass);
                process.Priority = process._process.PriorityClass.ToString();
            }
            catch (Exception)
            {
                // ignored
            }

            return process;
        }


        private static ProcessPriorityClass IncrementProcessPriorityClass(ProcessPriorityClass priorityClass)
        {
            return priorityClass switch
            {
                ProcessPriorityClass.RealTime => ProcessPriorityClass.RealTime,
                ProcessPriorityClass.High => ProcessPriorityClass.RealTime,
                ProcessPriorityClass.AboveNormal => ProcessPriorityClass.High,
                ProcessPriorityClass.Normal => ProcessPriorityClass.AboveNormal,
                ProcessPriorityClass.BelowNormal => ProcessPriorityClass.Normal,
                ProcessPriorityClass.Idle => ProcessPriorityClass.BelowNormal,
                _ => throw new ArgumentOutOfRangeException(nameof(priorityClass), priorityClass, null)
            };
        }

        private static ProcessPriorityClass DecrementProcessPriorityClass(ProcessPriorityClass priorityClass)
        {
            return priorityClass switch
            {
                ProcessPriorityClass.RealTime => ProcessPriorityClass.High,
                ProcessPriorityClass.High => ProcessPriorityClass.AboveNormal,
                ProcessPriorityClass.AboveNormal => ProcessPriorityClass.Normal,
                ProcessPriorityClass.Normal => ProcessPriorityClass.BelowNormal,
                ProcessPriorityClass.BelowNormal => ProcessPriorityClass.Idle,
                ProcessPriorityClass.Idle => ProcessPriorityClass.Idle,
                _ => throw new ArgumentOutOfRangeException(nameof(priorityClass), priorityClass, null)
            };
        }
    }
}