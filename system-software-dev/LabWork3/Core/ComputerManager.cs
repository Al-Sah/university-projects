using System.Collections.Generic;
using System.Linq;

namespace LabWork3.Core
{
    public class ComputerManager
    {
        public Dictionary<string, Computer> Computers { get; }

        public ComputerManager()
        {
            var current = new Computer();
            current.ProcessesManager.Start();
            Computers = new Dictionary<string, Computer> { {current.Name, current} };
        }

        public Computer AddComputer()
        {
            // TODO
            if (Computers.Count != 0)
                foreach(var pair in Computers) return pair.Value;
            
            var current = new Computer();
            current.ProcessesManager.Start();
            Computers.Add(current.Name, current);
            return current;
        }

        public bool DeleteComputer(Computer computer)
        {
            var item = Computers.First(kvp => kvp.Value == computer);
            return Computers.Remove(item.Key);
        }

        public Computer Get(string name) => Computers[name];
        
    }
}