using System;
using System.Diagnostics;
using System.Dynamic;
using System.Management;
using System.Reflection;

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

        public ProcessorInformation() => GetData();

        public void GetData()
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
                    AddressWidth = obj["AddressWidth"].ToString();
                    CurrentClockSpeed = obj["CurrentClockSpeed"].ToString();
                    LoadPercentage = obj["LoadPercentage"].ToString();
                    break;
                }
                IsValid = true;
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