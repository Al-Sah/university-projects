using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using LabWork3.Core;

namespace LabWork3.Forms
{
    public partial class MainWindow : Form
    {
        private delegate void SafeCallDelegate();

        public ComputerManager ComputerManager { get; }
        private Computer Selected { get; set; }

        private bool ResetGrid { get; set; }

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
            Selected.ProcessesUpdated += FillProcessesGridViewSafe;
            Selected.ProcessesNumberChanged += () => ResetGrid = true;
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
            ResetCurrent(ComputerManager.Get(ComputersList.SelectedItem.ToString()));
            FillProcessesGridView();
        }

        private void AddComputerBtn_Click(object sender, EventArgs e)
        {
            ResetCurrent(ComputerManager.AddComputer());
            ComputersList.SelectedIndex = ComputersList.Items.Add(Selected.Name);
            if (ComputersList.Items.Count == 1)
            {
                ValidateButtons();
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
            ValidateButtons();

            const string zero = "0";
            ProcessesLabel.Text = zero;
            CpuUsageLabel.Text = zero;
            RamUsageLabel.Text = zero;
        }

        private void ValidateButtons()
        {
            AddProcessBtn.Enabled = !AddProcessBtn.Enabled;
            ModifyProcessBtn.Enabled = !ModifyProcessBtn.Enabled;
            DeleteProcessBtn.Enabled = !DeleteProcessBtn.Enabled;
            ShowInfoComputerBtn.Enabled = !ShowInfoComputerBtn.Enabled;
            DeleteComputerBtn.Enabled = !DeleteComputerBtn.Enabled;
        }

        private void FillProcessesGridViewSafe()
        {
            try
            {
                if (ProcessesGridView.InvokeRequired)
                    ProcessesGridView.Invoke(new SafeCallDelegate(FillProcessesGridViewSafe));
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
            if (ResetGrid)
            {
                ProcessesGridView.Rows.Clear();
                ProcessesGridView.Rows.AddRange(
                    DataMapper.Reset(DataMapper.SortProcesses(Selected.Processes.Values.ToList(), ProcessesGridView)));
                ProcessesLabel.Text = Selected.Processes.Count.ToString();
                ResetGrid = false;
                return;
            }

            DataMapper.Update(DataMapper.SortProcesses(Selected.Processes.Values.ToList(), ProcessesGridView),
                ProcessesGridView);
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
    }
}