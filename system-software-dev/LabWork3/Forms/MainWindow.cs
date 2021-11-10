using System;
using System.Linq;
using System.Windows.Forms;
using LabWork3.Core;

namespace LabWork3.Forms
{
    public partial class MainWindow : Form
    {
        public ComputerManager ComputerManager { get; }

        public Computer Selected { get; set; }
        public MainWindow()
        {
            ComputerManager = new ComputerManager();
            InitializeComponent();
            
            // Get current computer
            foreach (var current in ComputerManager.Computers)
            {
                Selected = current.Value;
                break;
            }
            ComputersList.SelectedIndex = ComputersList.Items.Add(Selected.Name);
        }

        private void ComputersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selected = ComputerManager.Get(ComputersList.SelectedItem.ToString());
            FillProcessesGridView();
        }

        private void AddComputerBtn_Click(object sender, EventArgs e)
        {
            Selected = ComputerManager.AddComputer();
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

        public void FillProcessesGridView()
        {
            ProcessesGridView.Rows.Clear();
            if (Selected == null) return;
            
            foreach (var process in Selected.Processes.Select(o => o.Value))
            {
                ProcessesGridView.Rows.Add(
                    process.Name,
                    process.Pid,
                    process.Priority,
                    process.ProcessorAffinity,
                    process.Memory,
                    process.Path );
            }
        }

            
    }
}
