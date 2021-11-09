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
        }
    }
}
