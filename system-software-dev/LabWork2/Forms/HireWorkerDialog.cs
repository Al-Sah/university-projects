using System.Windows.Forms;

namespace LabWork2.Forms
{
    public partial class HireWorkerDialog : Form
    {
        public HireWorkerDialog()
        {
            InitializeComponent();
        }

        private void HireBtn_Click(object sender, System.EventArgs e)
        {
            if (int.TryParse(InputBox.Text, out var res))
            {
                ((MainWindow) Owner).ActiveSeaport.HireWorkers((ushort) res);
                WorkersNumberValue.Text = ((MainWindow) Owner).ActiveSeaport.GetWorkers().ToString();
                ((MainWindow) Owner).UpdateDocksViewer();
                ((MainWindow) Owner).UpdateLabels();
            }
            else
            {
                MessageBox.Show(
                    $"Input value is not a number: '{InputBox.Text}", "Ups ... ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void HireWorkerDialog_Load(object sender, System.EventArgs e)
        {
            WorkersNumberValue.Text = ((MainWindow) Owner).ActiveSeaport.GetWorkers().ToString();
        }
    }
}