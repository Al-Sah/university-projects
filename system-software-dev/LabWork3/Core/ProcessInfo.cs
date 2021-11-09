﻿using System;
using System.ComponentModel;
using System.Diagnostics;

namespace LabWork3.Core
{
    public class ProcessInfo
    {
        public string Priority { get; set; }
        public string Name { get; set; }
        public string ProcessorAffinity { get; set; }
        public string Memory { get; set; }
        public string Path { get; set; }
        public int Pid { get; set; }

        private Process _process;
        
        
        public ProcessInfo(Process process) => GetData(process);
        public ProcessInfo() => GetData(Process.GetCurrentProcess());
        

        public void GetData(Process process)
        {
            _process = process;

            try
            {
                if (_process.MainModule != null)
                {
                    Path = _process.MainModule.FileName;
                }
            }
            catch (Win32Exception e)
            {
                Debug.WriteLine(_process + "  " + e.Message);
                Path = "ERROR";
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(_process + "  " + e.Message);
                Path = "ERROR";
            }
            
            Memory = _process.WorkingSet64.ToString();
            Name = _process.ProcessName;
            Pid = _process.Id;

            try
            {
                Priority = _process.PriorityClass.ToString();
            }
            catch (Win32Exception e)
            {
                Debug.WriteLine(_process + "  " + e.Message);
                Priority = "ERROR";
            }
            try
            {
                ProcessorAffinity = _process.ProcessorAffinity.ToString();
            }
            catch (Win32Exception e)
            {
                Debug.WriteLine(_process + "  " + e.Message);
                ProcessorAffinity = "ERROR";
            }

        }
    }
}