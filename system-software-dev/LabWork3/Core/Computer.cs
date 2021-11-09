
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LabWork3.Core
{
    public class Computer
    {
        public string Name { get; set; }

        public MemoryInformation Memory { get; set; }
        public ProcessorInformation Processor { get; set; }

        public Dictionary<int, ProcessInfo> Processes { get; set; }
        public Computer()
        {
            Name = Environment.MachineName;
            
            Memory = new MemoryInformation();
            Processor = new ProcessorInformation();
            Processes = new Dictionary<int, ProcessInfo>();
            
            foreach (var process in Process.GetProcesses())
            {
                var processInfo = new ProcessInfo(process);
                Processes.Add(processInfo.Pid,processInfo);
            }
        }
    }
}