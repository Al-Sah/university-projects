using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace LabWork3.Core
{
    public class ComputerManager
    {
        public Dictionary<string, Computer> Computers { get; }

        public ComputerManager()
        {
            var current = new Computer();
            Computers = new Dictionary<string, Computer> {{current.Name, current}};
        }

        public Computer AddComputer()
        {
            // TODO
            if (Computers.Count != 0)
                foreach (var pair in Computers)
                    return pair.Value;

            var current = new Computer();
            Computers.Add(current.Name, current);
            return current;
        }

        public bool DeleteComputer(Computer computer)
        {
            var item = Computers.First(kvp => kvp.Value == computer);
            return Computers.Remove(item.Key);
        }

        public Computer Get(string name) => Computers[name];


        public static bool StartProcess(CreationInfo creationInfo)
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = creationInfo.File;
                process.StartInfo.Arguments = creationInfo.Args;
                process.Start();
                process.PriorityClass = Enum.TryParse(creationInfo.Priority, true, out ProcessPriorityClass res)
                    ? res
                    : ProcessPriorityClass.Normal;
                process.ProcessorAffinity = new IntPtr(creationInfo.Affinity);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public static bool DeleteProcesses(IEnumerable<int> ids, out string errors)
        {
            var errorsBuilder = new StringBuilder();
            foreach (var id in ids)
            {
                try
                {
                    Process.GetProcessById(id).Kill();
                }
                catch (Exception e)
                {
                    errorsBuilder.Append(e).Append("/n");
                }
            }

            errors = errorsBuilder.ToString();
            return errorsBuilder.Length == 0;
        }

        [DllImport("user32.dll")]
        private static extern int SetWindowText(IntPtr hWnd, string text);

        public static bool ModifyProcesses(ModificationInfo info, List<int> ids, out string errors)
        {
            var errorsBuilder = new StringBuilder();
            foreach (var id in ids)
            {
                try
                {
                    var temp = Process.GetProcessById(id);
                    if (ids.Count == 1)
                    {
                        SetWindowText(temp.MainWindowHandle, info.Name);
                    }

                    temp.ProcessorAffinity = new IntPtr(info.Affinity);
                    temp.PriorityClass = Enum.TryParse(info.Priority, true, out ProcessPriorityClass res)
                        ? res
                        : temp.PriorityClass;
                }
                catch (Exception e)
                {
                    errorsBuilder.Append(e).Append("/n");
                }
            }

            errors = errorsBuilder.ToString();
            return errorsBuilder.Length == 0;
        }

        public readonly struct CreationInfo
        {
            public string File { get; }
            public string Args { get; }
            public string Priority { get; }
            public long Affinity { get; }

            public CreationInfo(string file, string args, string priority, long affinity)
            {
                File = file;
                Args = args;
                Priority = priority;
                Affinity = affinity;
            }
        }

        public readonly struct ModificationInfo
        {
            public string Name { get; }
            public string Priority { get; }
            public long Affinity { get; }

            public ModificationInfo(string name, string priority, long affinity)
            {
                Name = name;
                Priority = priority;
                Affinity = affinity;
            }
        }
    }
}