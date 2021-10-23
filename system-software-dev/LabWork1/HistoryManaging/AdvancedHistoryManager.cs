using System;
using System.Collections.Generic;
using System.Globalization;

namespace LabWork1.HistoryManaging
{
    public class AdvancedHistoryManager : IHistoryManager
    {
        private readonly List<string> _history;

        public AdvancedHistoryManager()
        {
            _history = new List<string>();
        }

        public void Clear()
        {
            _history.Clear();
            Console.WriteLine("Cleaning history");
        }

        public void Print()
        {
            foreach (var str in _history)
            {
                Console.WriteLine(str);
            }
        }

        public void AddLine(string taskInfo)
        {
            _history.Add($"[{DateTime.Now.ToString(CultureInfo.CurrentCulture)}] Task: {taskInfo}\n");
        }
    }
}