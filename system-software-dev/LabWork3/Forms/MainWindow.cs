using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using LabWork3.Core;
using static System.String;

namespace LabWork3.Forms
{
    public partial class MainWindow : Form
    {
        private delegate void SafeCallDelegate();

        private ComputerManager ComputerManager { get; }
        private Computer Selected { get; set; }

        private const string LoadingStr = " Loading . . . ";

        private readonly AddProcessDialog _addProcessDialog;
        private readonly ModifyProcessDialog _modifyProcessDialog;
        private readonly ComputerInformationWindow _computerInformationDialog;

        public MainWindow()
        {
            InitializeComponent();
            ComputerManager = new ComputerManager();
            // Get current computer
            foreach (var current in ComputerManager.Computers.Values)
            {
                ResetCurrent(current);
                break;
            }

            _addProcessDialog = new AddProcessDialog(Selected.Processor.NumberOfLogicalProcessors) {Owner = this};
            _modifyProcessDialog = new ModifyProcessDialog(Selected.Processor.NumberOfLogicalProcessors) {Owner = this};
            _computerInformationDialog = new ComputerInformationWindow {Owner = this};
            ComputersList.SelectedIndex = ComputersList.Items.Add(Selected.Name);
        }

        private void ResetCurrent(Computer computer)
        {
            Selected?.ClearEventsHandlers();
            Selected = computer;
            GridViewManager.ResetDataGrid(Selected.Processes.Values.ToList(), ProcessesGridView);
            SetComputerEventHandlers();
            ProcessesLabel.Text = Selected.Processes.Count.ToString();
        }

        private void SetComputerEventHandlers()
        {
            Selected.ProcessesUpdated += ProcessesGridViewSafeUpdate;
            Selected.ProcessesNumberChanged += () => ProcessesLabel.Text = Selected.Processes.Count.ToString();
            Selected.Processor.DataUpdated += () =>
            {
                if (Selected.Processor.IsValid)
                {
                    CpuUsageLabel.Text = Selected.Processor.LoadPercentage;
                }
            };
            Selected.Memory.DataUpdated +=
                () =>
                {
                    if (Selected.Memory.IsValid)
                    {
                        RamUsageLabel.Text =
                            (Selected.Memory.FreeVirtualMemory * 100 / Selected.Memory.TotalVirtualMemory)
                            .ToString();
                    }
                };
        }

        private void ComputersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComputersList.SelectedItem.Equals(LoadingStr))
            {
                return;
            }

            ResetCurrent(ComputerManager.Get(ComputersList.SelectedItem.ToString()));
            ProcessesGridViewSafeUpdate();
        }

        private void AddComputerBtn_Click(object sender, EventArgs e)
        {
            ComputersList.SelectedIndex = ComputersList.Items.Add(LoadingStr);
            ResetCurrent(ComputerManager.AddComputer());
            ComputersList.Items.Remove(LoadingStr);
            ComputersList.SelectedIndex = ComputersList.Items.Add(Selected.Name);
            if (ComputersList.Items.Count == 1)
            {
                InvertButtonsState();
            }
        }

        private void DeleteComputerBtn_Click(object sender, EventArgs e)
        {
            if (ComputersList.Items.Count == 0) return;
            ComputersList.Items.Remove(ComputersList.SelectedItem);
            if (ComputersList.Items.Count != 0)
            {
                ComputersList.SelectedIndex = 0;
                return;
            }

            ProcessesGridView.Rows.Clear();
            ComputerManager.DeleteComputer(Selected);
            Selected.ClearEventsHandlers();
            Selected = null;
            InvertButtonsState();

            const string zero = "0";
            ProcessesLabel.Text = zero;
            CpuUsageLabel.Text = zero;
            RamUsageLabel.Text = zero;
        }

        private void InvertButtonsState()
        {
            AddProcessBtn.Enabled = !AddProcessBtn.Enabled;
            ModifyProcessBtn.Enabled = !ModifyProcessBtn.Enabled;
            DeleteProcessBtn.Enabled = !DeleteProcessBtn.Enabled;
            ShowInfoComputerBtn.Enabled = !ShowInfoComputerBtn.Enabled;
            DeleteComputerBtn.Enabled = !DeleteComputerBtn.Enabled;
        }

        private void ProcessesGridViewSafeUpdate()
        {
            try
            {
                if (ProcessesGridView.InvokeRequired)
                    ProcessesGridView.Invoke(new SafeCallDelegate(ProcessesGridViewSafeUpdate));
                else
                    FillProcessesGridView();
            }
            catch (InvalidAsynchronousStateException e)
            {
                Debug.WriteLine(e);
            }
        }

        private void FillProcessesGridView()
        {
            if (Selected == null) return;
            GridViewManager.Update(Selected.Processes.Values.ToList(), ProcessesGridView);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var computer in ComputerManager.Computers.Values)
            {
                computer.Updatable = false;
            }
        }

        private void DeleteProcesses()
        {
            var selectedRowCount = ProcessesGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount <= 0) return;

            var processesIds = (from DataGridViewRow selectedRow in ProcessesGridView.SelectedRows
                select (int) selectedRow.Cells[1].Value).ToList();
            if (!ComputerManager.DeleteProcesses(processesIds, out var errors))
            {
                Notifier.ErrorMessageBox(errors);
            }
        }

        private void AddProcessBtn_Click(object sender, EventArgs e) => _addProcessDialog.ShowDialog();

        private void DeleteProcessBtn_Click(object sender, EventArgs e) => DeleteProcesses();

        private void ModifyProcesses()
        {
            var selectedRowCount = ProcessesGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount <= 0) return;

            _modifyProcessDialog.Ids = (from DataGridViewRow selectedRow in ProcessesGridView.SelectedRows
                select (int) selectedRow.Cells[1].Value).ToList();

            if (ProcessesGridView.SelectedRows.Count == 1)
            {
                var row = ProcessesGridView.SelectedRows[0];
                _modifyProcessDialog.ProcessName = (string) row.Cells["Process"].Value;
                _modifyProcessDialog.Affinity = (int) row.Cells["Affinity"].Value;
                _modifyProcessDialog.Priority = (string) row.Cells["Priority"].Value;
            }

            _modifyProcessDialog.ShowDialog();
        }

        private void ShowInfoProcessBtn_Click(object sender, EventArgs e) => ModifyProcesses();
        private void ProcessesGridView_MouseDoubleClick(object sender, MouseEventArgs e) => ModifyProcesses();

        private void ModifyComputerBtn_Click(object sender, EventArgs e)
        {
            _computerInformationDialog.Computer = Selected;
            _computerInformationDialog.ShowDialog();
        }


        private static class GridViewManager
        {
            public static void ResetDataGrid(List<ProcessInfo> processes, DataGridView gridView)
            {
                gridView.Rows.Clear();
                SortProcesses(processes, gridView);
                gridView.Rows.AddRange(processes.Select(process => new DataGridViewRow
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
                }).ToArray());
            }

            public static void Update(List<ProcessInfo> processes, DataGridView gridView)
            {
                if (processes.Count != gridView.Rows.Count)
                {
                    UpdateRows(processes.Count, gridView);
                }

                SortProcesses(processes, gridView);

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

            private static void SortProcesses(List<ProcessInfo> processes, DataGridView gridView)
            {
                switch (gridView.Columns.IndexOf(gridView.SortedColumn))
                {
                    case 0:
                        processes.Sort((x, y) => CompareOrdinal(x.Name, y.Name));
                        break;
                    case 1:
                        processes.Sort((x, y) => x.Pid.CompareTo(y.Pid));
                        break;
                    case 2:
                        processes.Sort((x, y) => CompareOrdinal(x.Priority, y.Priority));
                        break;
                    case 3:
                        processes.Sort((x, y) => x.ProcessorAffinity.CompareTo(y.ProcessorAffinity));
                        break;
                    case 4:
                        processes.Sort((x, y) => x.Memory.CompareTo(y.Memory));
                        break;
                    case 5:
                        processes.Sort((x, y) => CompareOrdinal(x.Path, y.Path));
                        break;
                }

                if (gridView.SortOrder == SortOrder.Descending)
                {
                    processes.Reverse();
                }
            }

            private static void UpdateRows(int processes, DataGridView gridView)
            {
                var res = processes - gridView.Rows.Count;
                if (res <= 0)
                {
                    for (var i = 0; i < (res * -1); i++)
                    {
                        gridView.Rows.RemoveAt(gridView.Rows.Count - 1);
                    }
                }
                else
                {
                    gridView.Rows.Add(res);
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
}