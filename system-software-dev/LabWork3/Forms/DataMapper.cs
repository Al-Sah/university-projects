using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LabWork3.Core;
using static System.String;

namespace LabWork3.Forms
{
    public static class DataMapper
    {
        public static DataGridViewRow[] Reset(IEnumerable<ProcessInfo> processes)
        {
            return processes.Select(process => new DataGridViewRow
                {
                    Cells =
                    {
                        new DataGridViewTextBoxCell {Value = process.Name},
                        new DataGridViewTextBoxCell {Value = process.Pid},
                        new DataGridViewTextBoxCell {Value = process.Priority},
                        new DataGridViewTextBoxCell {Value = process.ProcessorAffinity},
                        new DataGridViewTextBoxCell {Value = process.Memory},
                        new DataGridViewTextBoxCell {Value = process.Path}
                    }
                })
                .ToArray();
        }
        
        public static List<ProcessInfo> SortProcesses(List<ProcessInfo> process, DataGridView gridView)
        {
            switch (gridView.Columns.IndexOf(gridView.SortedColumn))
            {
                case 0: process.Sort((x, y) => CompareOrdinal(x.Name, y.Name)); break;
                case 1: process.Sort((x, y) => x.Pid.CompareTo(y.Pid)); break;
                case 2: process.Sort((x, y) => CompareOrdinal(x.Priority, y.Priority)); break;
                case 3: process.Sort((x, y) => x.ProcessorAffinity.CompareTo(y.ProcessorAffinity)); break;
                case 4: process.Sort((x, y) => x.Memory.CompareTo(y.Memory)); break;
                case 5: process.Sort((x, y) => CompareOrdinal(x.Path, y.Path)); break;
            }

            if (gridView.SortOrder == SortOrder.Descending)
            {
                process.Reverse();
            }
            return process;
        }
        
        // processes must be sorted as in gridView
        public static void Update(List<ProcessInfo> processes, DataGridView gridView)
        {
            for (var index = 0; index < gridView.Rows.Count; index++)
            {
                var process = processes[index];
                var row = gridView.Rows[index];
                UpdateUnit(row.Cells[0], process.Name);
                UpdateUnit(row.Cells[1], process.Pid);
                UpdateUnit(row.Cells[2], process.Priority);
                UpdateUnit(row.Cells[3], process.ProcessorAffinity);
                UpdateUnit(row.Cells[4], process.Memory);
                UpdateUnit(row.Cells[5], process.Path);
            }
        }

        private static void UpdateUnit(DataGridViewCell cell, object value)
        {
            if (cell.Value != value)
            {
                cell.Value = value;
            }
        }
    }
}