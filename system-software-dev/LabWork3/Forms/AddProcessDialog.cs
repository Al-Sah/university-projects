using System.Windows.Forms;
using LabWork3.Core;

namespace LabWork3.Forms
{
    public partial class AddProcessDialog : Form
    {
        private readonly SetupAffinityDialog _setupAffinityDialog;

        public AddProcessDialog(long processorsCount)
        {
            InitializeComponent();
            _setupAffinityDialog = new SetupAffinityDialog {Owner = this, ProcessorsCount = processorsCount};
        }

        private void SetupProcess() => ComputerManager.StartProcess(
            new ComputerManager.CreationInfo(
                FileTextBox.Text,
                ArgumentsTextBox.Text,
                PrioritiesList.SelectedItem.ToString(),
                _setupAffinityDialog.Mask
            ));

        private void SetupProcessBtn_Click(object sender, System.EventArgs e) => SetupProcess();

        private void OpenFileBtn_Click(object sender, System.EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            FileTextBox.Text = OpenFileDialog.FileName;
        }

        private void AddProcessDialog_Load(object sender, System.EventArgs e) => PrioritiesList.SelectedIndex = 0;
        private void ManageAffinityBtn_Click(object sender, System.EventArgs e) => _setupAffinityDialog.ShowDialog();
    }
}