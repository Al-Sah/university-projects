using System.Windows.Forms;

namespace LabWork6
{
    public partial class MainWindow : Form
    {
        private readonly Factory _factory;

        public MainWindow()
        {
            InitializeComponent();
            _factory = new Factory {Money = 500};
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _factory.Runnable = false;
        }
    }
}