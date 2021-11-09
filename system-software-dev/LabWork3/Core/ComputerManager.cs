using System.Collections.Generic;

namespace LabWork3.Core
{
    public class ComputerManager
    {
        public Dictionary<string, Computer> Computers { get; }

        public ComputerManager()
        {
            var current = new Computer();
            Computers = new Dictionary<string, Computer> { {current.Name, current} };
        }

        public void AddComputer()
        {
            if (Computers.Count != 0) return;
            var current = new Computer();
            Computers.Add(current.Name, current);
        }
        public void DeleteComputer() => Computers.Clear();
    }
}