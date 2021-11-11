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

        public Computer Selected { get; set; }

        public bool ResetGrid { get; set; }

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
                        RamUsageLabel.Text = (Selected.Memory.FreeVirtualMemory * 100 / Selected.Memory.TotalVirtualMemory)
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
        }

        private void DeleteComputerBtn_Click(object sender, EventArgs e)
        {
            if (ComputersList.Items.Count == 0) return;
            ComputersList.Items.Remove(ComputersList.SelectedItem);
            if (ComputersList.Items.Count != 0) return;
            ProcessesGridView.Rows.Clear();
            ComputerManager.DeleteComputer(Selected);
            Selected = null;
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
                ProcessesGridView.Rows.AddRange(DataMapper.Reset(DataMapper.SortProcesses(Selected.Processes.Values.ToList(), ProcessesGridView)));
                ProcessesLabel.Text = Selected.Processes.Count.ToString();
                ResetGrid = false;
                return;
            }
            DataMapper.Update(DataMapper.SortProcesses(Selected.Processes.Values.ToList(), ProcessesGridView), ProcessesGridView);
        }
        
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var computer in ComputerManager.Computers.Values)
            {
                computer.Updatable = false;
            }
        }
    }
}
