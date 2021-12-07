using System;
using System.Threading;
using System.Windows.Forms;

namespace client
{
    public partial class MainWindow : Form
    {
        private byte Red { get; set; }
        private byte Green { get; set; }
        private byte Blue { get; set; }

        public delegate void UpdateState(bool state);
        public readonly UpdateState UpdateStateDelegate;

        private readonly Thread _connectionHandler;
        private readonly ConnectionManager _connectionManager;
        public MainWindow()
        {
            InitializeComponent();
            
            _connectionManager = new ConnectionManager();
            UpdateStateDelegate = UpdateButton;
            _connectionManager.ConnectionStateChanged += () =>
            {
                ConnectionStatusValueLabel.Text = _connectionManager.ConnectionDetails;
                SetBtn.Invoke(UpdateStateDelegate, _connectionManager.Connected);
            };
            _connectionHandler = new Thread(_connectionManager.HandleConnection);
            _connectionHandler.Start();
        }

        public void UpdateButton(bool state) => SetBtn.Enabled = state;
        private void UpdateColourLabel() => ColourLabel.Text = $@"( {Red}; {Green}; {Blue}; )";
        
        private void RedTrackBar_Scroll(object sender, EventArgs e)
        {
            Red = Convert.ToByte(RedTrackBar.Value);
            UpdateColourLabel();
        }
        private void GreenTrackBar_Scroll(object sender, EventArgs e)
        {
            Green = Convert.ToByte(GreenTrackBar.Value);
            UpdateColourLabel();
        }
        private void BlueTrackBar_Scroll(object sender, EventArgs e)
        {
            Blue = Convert.ToByte(BlueTrackBar.Value);
            UpdateColourLabel();
        }

        private void SetBtn_Click(object sender, EventArgs e)
        {
            _connectionManager.SendMessage(new[] {Red, Green, Blue});
        }

       

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _connectionManager.TryConnect = false;
        }
    }
}