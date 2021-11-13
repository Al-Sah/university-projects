using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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


        public static bool StartProcess(string file, string args, string priority, long affinity)
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = file;
                process.StartInfo.Arguments = args;
                process.Start();
                process.PriorityClass = Enum.TryParse(priority, true, out ProcessPriorityClass res)
                    ? res
                    : ProcessPriorityClass.Normal;
                process.ProcessorAffinity = new IntPtr(affinity);
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
    }
}