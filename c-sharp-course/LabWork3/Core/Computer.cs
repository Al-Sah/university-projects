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

        // Processes collection cannot be assigned by internal class => set is private 
        public Dictionary<int, ProcessInfo> Processes { get; private set; }

        private readonly Thread _dataManager;

        public event Action? ProcessesUpdated;
        public event Action? ProcessesNumberChanged;

        public void ClearEventsHandlers()
        {
            if (ProcessesUpdated == null) return;
            foreach (var d in ProcessesUpdated.GetInvocationList())
            {
                ProcessesUpdated -= (Action) d;
            }

            if (ProcessesNumberChanged == null) return;
            foreach (var d in ProcessesNumberChanged.GetInvocationList())
            {
                ProcessesNumberChanged -= (Action) d;
            }

            Memory.ClearEvent();
            Processor.ClearEvent();
        }

        public Computer()
        {
            Name = Environment.MachineName;

            Memory = new MemoryInformation(MemoryInformation.Unit.KBytes);
            Processor = new ProcessorInformation();
            Processes = new Dictionary<int, ProcessInfo>();
            UpdateProcesses();

            Updatable = true;
            _dataManager = new Thread(UpdateData);
            _dataManager.Start();
        }

        private void UpdateData()
        {
            while (Updatable)
            {
                UpdateProcesses();
                Memory.UpdateData();
                Processor.UpdateData();
                Thread.Sleep(1000);
            }
        }

        private void UpdateProcesses()
        {
            var newDictionary = Process.GetProcesses().Select(process => new ProcessInfo(process))
                .ToDictionary(processInfo => processInfo.Pid);
            if (Processes.Count != newDictionary.Count)
            {
                ProcessesNumberChanged?.Invoke();
            }

            Processes.Clear();
            Processes = newDictionary;
            ProcessesUpdated?.Invoke();
        }

        public void Dispose()
        {
            Updatable = false;
            _dataManager.Join();
        }
    }
}