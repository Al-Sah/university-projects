using System;
using System.Windows.Forms;

namespace client
{
    public partial class MainWindow : Form
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public MainWindow() => InitializeComponent();
        private void UpdateColourLabel() => ColourLabel.Text = $@"( {Red}; {Green}; {Blue}; )";

        
        private void RedTrackBar_Scroll(object sender, EventArgs e)
        {
            Red = RedTrackBar.Value;
            UpdateColourLabel();
        }
        private void GreenTrackBar_Scroll(object sender, EventArgs e)
        {
            Green = GreenTrackBar.Value;
            UpdateColourLabel();
        }
        private void BlueTrackBar_Scroll(object sender, EventArgs e)
        {
            Blue = BlueTrackBar.Value;
            UpdateColourLabel();
        }

        private void SetBtn_Click(object sender, EventArgs e)
        {
        }
    }
}