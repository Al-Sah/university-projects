using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace server
{
    public partial class MainWindow : Form
    {
        private readonly ConnectionManager _connectionManager;
        private Thread _connectionHandler;
        public MainWindow()
        {
            InitializeComponent();
            _connectionManager = new ConnectionManager {Run = true};
            _connectionManager.ConnectionStateChanged += () =>
            {
                ConnectionStateValueLabel.Text = _connectionManager.ConnectionState;
            };
            _connectionManager.DataReceived += () =>
            {
                var colour = Color.FromArgb(
                    _connectionManager.Data[0],_connectionManager.Data[1], _connectionManager.Data[2]);
                BackColor = colour;
                statusStrip1.BackColor = colour;
            };
            _connectionHandler = new Thread(_connectionManager.Start);
            _connectionHandler.Start();
        }


        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) => _connectionManager.Stop();
    }
}