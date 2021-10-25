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
            if (_history.Count == 0)
            {
                Console.WriteLine(" History is empty");
                return;
            }

            Console.WriteLine(" History");
            for (var index = 0; index < _history.Count; index++)
            {
                Console.WriteLine($"{index}: {_history[index]}");
            }
        }

        public void AddLine(string taskInfo)
        {
            _history.Add($"[{DateTime.Now.ToString(CultureInfo.CurrentCulture)}] Task: {taskInfo}");
        }
    }
}