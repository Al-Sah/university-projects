using System.Windows.Forms;

namespace LabWork2
{
    public partial class MainWindow : Form
    {
        private Seaport seaport;


        public MainWindow()
        {
            InitializeComponent();
            seaport = new Seaport("UK12", "Seaport Z", 100, 100, 100);
        }
    }
}