using System;
using System.Collections.Generic;

namespace LabWork1.HistoryManaging
{
    public class HistoryManager : IHistoryManager
    {
        private readonly List<string> _history;

        public HistoryManager()
        {
            _history = new List<string>();
        }

        public void Clear()
        {
            _history.Clear();
        }

        public void Print()
        {
            for (var index = 0; index < _history.Count; index++)
            {
                Console.WriteLine($"{index}: {_history[index]}");
            }
        }

        public void AddLine(string log)
        {
            _history.Add(log);
        }
    }
}