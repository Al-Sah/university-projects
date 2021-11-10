
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace LabWork3.Core
{
    public class Computer : IDisposable
    {
        public bool Updatable { get; set; }
        public string Name { get; set; }

        public MemoryInformation Memory { get; set; }
        public ProcessorInformation Processor { get; set; }

        public Dictionary<int, ProcessInfo> Processes { get; set; }
        
        public Thread ProcessesManager;
        
        public event Action ProcessesUpdated;
        public event Action ProcessesNumberChanged;

        public void ClearEventsHandlers()
        {
            if (ProcessesUpdated == null) return;
            foreach (var d in ProcessesUpdated.GetInvocationList())
            {
                ProcessesUpdated -=  (Action)d;
            }
            if (ProcessesNumberChanged == null) return;
            foreach (var d in ProcessesNumberChanged.GetInvocationList())
            {
                ProcessesNumberChanged -=  (Action)d;
            }
        }
        
        public Computer()
        {
            Name = Environment.MachineName;
            
            Memory = new MemoryInformation();
            Processor = new ProcessorInformation();
            Processes = new Dictionary<int, ProcessInfo>();

            Updatable = true;
            ProcessesManager = new Thread(UpdateProcesses);
        }

        private void UpdateProcesses()
        {
            while (Updatable)
            {
               
                var newDictionary = Process.GetProcesses().Select(process => new ProcessInfo(process)).ToDictionary(processInfo => processInfo.Pid);
                if ( Processes.Count != newDictionary.Count)
                {
                    ProcessesNumberChanged?.Invoke();
                }
                Processes = newDictionary;
                ProcessesUpdated?.Invoke();
                Thread.Sleep(1000);
            }
        }

        public void Dispose()
        {
            Updatable = false;
            ProcessesManager.Join();
        }
    }
}