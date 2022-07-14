using System;
using System.Windows.Forms;
using LabWork3.Core;

namespace LabWork3.Forms
{
    public partial class ComputerInformationWindow : Form
    {
        public Computer Computer { get; set; }

        public ComputerInformationWindow()
        {
            InitializeComponent();
            _updateMemoryGridAction = delegate
            {
                if (Computer.Processor.IsValid) UpdateMemoryGrid();
            };
            _updateProcessorGridAction = delegate
            {
                if (Computer.Memory.IsValid) UpdateProcessorGrid();
            };
        }

        private readonly Action _updateMemoryGridAction;
        private readonly Action _updateProcessorGridAction;

        private void ComputerInformationWindow_Load(object sender, EventArgs e)
        {
            InfoLabel.Text = $"Computer: {Computer.Name}";

            ProcessorInfoGridView.Rows.Clear();
            foreach (var propertyInfo in typeof(ProcessorInformation).GetProperties())
            {
                ProcessorInfoGridView.Rows.Add(propertyInfo.Name,
                    Computer.Processor.GetType().GetProperty(propertyInfo.Name)?.GetValue(Computer.Processor, null));
            }

            MemoryInfoGridView.Rows.Clear();
            foreach (var propertyInfo in typeof(MemoryInformation).GetProperties())
            {
                MemoryInfoGridView.Rows.Add(propertyInfo.Name,
                    Computer.Memory.GetType().GetProperty(propertyInfo.Name)?.GetValue(Computer.Memory, null));
            }


            Computer.Processor.DataUpdated += _updateMemoryGridAction;
            Computer.Memory.DataUpdated += _updateProcessorGridAction;
        }

        private void UpdateMemoryGrid()
        {
            foreach (DataGridViewRow row in MemoryInfoGridView.Rows)
            {
                row.Cells[1].Value = Computer.Memory.GetType().GetProperty((string) row.Cells[0].Value)
                    ?.GetValue(Computer.Memory, null);
            }
        }

        private void UpdateProcessorGrid()
        {
            foreach (DataGridViewRow row in ProcessorInfoGridView.Rows)
            {
                row.Cells[1].Value = Computer.Processor.GetType().GetProperty((string) row.Cells[0].Value)
                    ?.GetValue(Computer.Processor, null);
            }
        }

        private void ComputerInformationWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Computer == null) return;
            Computer.Processor.DataUpdated -= _updateMemoryGridAction;
            Computer.Memory.DataUpdated -= _updateProcessorGridAction;
        }
    }
}