using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LabWork3.Core;

namespace LabWork3.Forms
{
    public partial class ModifyProcessDialog : Form
    {
        public List<int> Ids { get; set; }

        private uint ProcessesCount { get; }

        public string ProcessName { get; set; }

        public long Affinity { get; set; }

        public string Priority { get; set; }

        private readonly SetupAffinityDialog _setupAffinityDialog;

        public ModifyProcessDialog(uint logicalProcessors)
        {
            InitializeComponent();
            Name = string.Empty;
            Priority = string.Empty;
            ProcessesCount = logicalProcessors;
            _setupAffinityDialog = new SetupAffinityDialog {Owner = this, ProcessorsCount = ProcessesCount};
            _setupAffinityDialog.FormClosing += (_, _) =>
            {
                Affinity = _setupAffinityDialog.Mask;
                AffinityTextBox.Text = Affinity.ToString();
            };
        }

        private void ModifyProcessDialog_Load(object sender, EventArgs e)
        {
            if (Ids.Count == 1)
            {
                InfoLabel.Text = $"Modification of \"{ProcessName}\" process";
                NameTextBox.Enabled = Enabled;
                NameTextBox.Text = ProcessName;
                AffinityTextBox.Text = Affinity.ToString();
                PrioritiesList.SelectedIndex = PrioritiesList.Items.IndexOf(Priority);
            }
            else
            {
                InfoLabel.Text = "Multiple processes configuration";
                NameTextBox.Enabled = false;
                NameTextBox.Text = string.Empty;
                AffinityTextBox.Text = string.Empty;
                PrioritiesList.SelectedIndex = 0;
            }
        }

        private void ConfigAffinityBtn_Click(object sender, EventArgs e)
        {
            _setupAffinityDialog.ShowDialog();
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(AffinityTextBox.Text, out var mask))
            {
                Notifier.ErrorMessageBox($"Failed to parse affinity: '{AffinityTextBox.Text}'");
                return;
            }

            if (!ComputerManager.ModifyProcesses(new ComputerManager.ModificationInfo(
                    NameTextBox.Text,
                    (string) PrioritiesList.SelectedItem,
                    mask),
                Ids,
                out var errors))
            {
                Notifier.ErrorMessageBox(errors);
            }
        }
    }
}