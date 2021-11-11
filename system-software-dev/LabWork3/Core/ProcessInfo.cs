using System;
using System.Diagnostics;

namespace LabWork3.Core
{
    public class ProcessInfo
    {
        public string Priority { get; set; }
        public string Name { get; set; }
        public int ProcessorAffinity { get; set; }
        public long Memory { get; set; }
        public string Path { get; set; }
        public int Pid { get; set; }

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
            ProcessorAffinity = (int) ValidateProperty(() => _process.ProcessorAffinity.ToInt32(), ProcessorAffinity.GetType());
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
                //Debug.WriteLine(_process + "  " + e.Message);
                if (toReturn == typeof(long) || toReturn == typeof(int))
                {
                    return 0;
                }
                return Error;
            }
        }
    }
}