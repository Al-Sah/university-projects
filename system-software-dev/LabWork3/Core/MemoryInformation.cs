using System;
using System.Diagnostics;
using System.Management;

namespace LabWork3.Core
{
    public class MemoryInformation
    {
        public ulong TotalVisibleMemory { get; set; }
        public ulong FreePhysicalMemory { get; set; }
        public ulong TotalVirtualMemory { get; set; }
        public ulong FreeVirtualMemory  { get; set; }

        public Unit CurrentUnit  { get; set; }

        public bool IsValid { get; set; }
        
        public MemoryInformation(Unit unit = Unit.GBytes )
        {
            CurrentUnit = unit;
            GetData();
        }

        public void GetData()
        {
            IsValid = false;

            try
            {
                var memoryProperties = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
                foreach (var o in memoryProperties.Get())
                {
                    // All selected data represented in KB
                    var result = (ManagementObject) o;
                    TotalVisibleMemory = ToCurrentUnit(ulong.Parse(result["TotalVisibleMemorySize"].ToString()));
                    TotalVirtualMemory = ToCurrentUnit(ulong.Parse(result["TotalVirtualMemorySize"].ToString()));
                    
                    FreePhysicalMemory = ToCurrentUnit(ulong.Parse(result["FreePhysicalMemory"].ToString()));
                    FreeVirtualMemory = ToCurrentUnit(ulong.Parse(result["FreeVirtualMemory"].ToString()));
                    break;
                }
                IsValid = true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        
        public enum Unit
        {
            KBytes,
            MBytes,
            GBytes
        }

        public ulong ToCurrentUnit(ulong input)
        {
            return CurrentUnit switch
            {
                Unit.KBytes => input,
                Unit.MBytes => input / 1_024,
                Unit.GBytes => input / 1_048_576,
                _ => input
            };
        }
        
    }
}