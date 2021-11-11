using System;
using System.Diagnostics;
using System.Management;

namespace LabWork3.Core
{
    public class ProcessorInformation
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string MaxClockSpeed { get; set; }
        public string NumberOfCores { get; set; }
        public string NumberOfLogicalProcessors { get; set; }
        public string Architecture { get; set; }
        public string AddressWidth { get; set; }

        // dynamic data TODO update
        public string LoadPercentage { get; set; }
        public string CurrentClockSpeed { get; set; }

        public bool IsValid { get; set; }
        
        public event Action DataUpdated;
        
        public void ClearEvent()
        {
            if (DataUpdated == null) return;
            foreach (var d in DataUpdated.GetInvocationList())
            {
                DataUpdated -= (Action)d;
            }
        }
        public ProcessorInformation() => InitData();

        private void InitData()
        {
            IsValid = false;
            try
            {
                // Get CPU properties (ProcessorType - 3 : CPU)
                var processorProperties = new ManagementObjectSearcher("select * from Win32_Processor where ProcessorType = 3");
                foreach (var o in processorProperties.Get())
                {
                    var obj = (ManagementObject) o;
                    Name = obj["Name"].ToString();
                    Manufacturer = obj["Manufacturer"].ToString();
                    CurrentClockSpeed = obj["CurrentClockSpeed"].ToString();
                    NumberOfCores = obj["NumberOfCores"].ToString();
                    MaxClockSpeed = obj["MaxClockSpeed"].ToString();
                    NumberOfLogicalProcessors = obj["NumberOfLogicalProcessors"].ToString();
                    Architecture = ArchitectureMapper.Get((ushort)obj["Architecture"]);
                    AddressWidth = obj["AddressWidth"]?.ToString();
                    CurrentClockSpeed = obj["CurrentClockSpeed"].ToString();
                    LoadPercentage = obj["LoadPercentage"]?.ToString();
                    break;
                }
                IsValid = true;
                DataUpdated?.Invoke();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        
        public void UpdateData()
        {
            IsValid = false;
            try
            {
                var percentProcessorTime = new ManagementObjectSearcher("select PercentProcessorTime from Win32_PerfFormattedData_PerfOS_Processor");
                //select LoadPercentage from Win32_Processor
                //select PercentProcessorTime from Win32_PerfFormattedData_PerfOS_Processor
                foreach (var o in percentProcessorTime.Get())
                {
                    var obj = (ManagementObject) o;
                    LoadPercentage = obj["PercentProcessorTime"].ToString();
                    break;
                }
                var currentClockSpeed = new ManagementObjectSearcher("select CurrentClockSpeed from Win32_Processor");
                foreach (var o in currentClockSpeed.Get())
                {
                    var obj = (ManagementObject) o;
                    CurrentClockSpeed = obj["CurrentClockSpeed"].ToString();
                    break;
                }
                IsValid = true;
                DataUpdated?.Invoke();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private static class ArchitectureMapper
        {
            public static string Get(uint architectureId)
            {
                return architectureId switch
                {
                    0 => "x86",
                    1 => "MIPS",
                    2 => "Alpha",
                    3 => "PowerPC",
                    5 => "ARM",
                    6 => "ia64",
                    9 => "x64",
                    _ => $"undefined (code {architectureId.ToString()})"
                };
            }
        }
    }
}