using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LabWork3.Core;

namespace LabWork3.Forms
{
    public static class DataMapper
    {
        public static DataGridViewRow[] Reset(Dictionary<int, ProcessInfo> processes)
        {
            return processes.Select(o => o.Value)
                .Select(process => new DataGridViewRow
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