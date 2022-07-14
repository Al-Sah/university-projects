using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LabWork6
{
    public partial class MainWindow : Form
    {
        private readonly Factory _factory;

        public MainWindow()
        {
            InitializeComponent();
            OpenReportDialog.InitialDirectory = Directory.GetCurrentDirectory();
            OpenReportDialog.Filter = @"alx reports (*.alxrp;*.xml)|*.xml;*.alxrp";
            _factory = new Factory {Money = 200};
            DepartmentsLabel.Text = _factory.Departments.ToString();
            _factory.PropertiesUpdated += UpdateLabels;
            StateComboBox.SelectedIndex = 0;
        }


        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _factory.PropertiesUpdated -= UpdateLabels;
            _factory.Runnable = false;
            _factory.Event.Set();
        }

        private void SuspendBtn_Click(object sender, EventArgs e)
        {
            _factory.Event.Reset();
            ResumeBtn.Enabled = true;
            SuspendBtn.Enabled = false;
        }

        private void ResumeBtn_Click(object sender, EventArgs e)
        {
            _factory.Event.Set();
            ResumeBtn.Enabled = false;
            SuspendBtn.Enabled = true;
        }

        private void UpdateLabels()
        {
            ProductsLabel.Invoke((MethodInvoker) delegate { ProductsLabel.Text = _factory.Products.ToString(); });

            MoneyLabel.Invoke((MethodInvoker) delegate { MoneyLabel.Text = _factory.Money.ToString(); });

            RawMaterialLabel.Invoke((MethodInvoker) delegate
            {
                RawMaterialLabel.Text = _factory.RawMaterial.ToString();
            });

            CurrentStateLabel.Invoke((MethodInvoker) delegate
            {
                CurrentStateLabel.Text = _factory.CurrentState.ToString();
            });

            FreeStorageSpaceLabel.Invoke((MethodInvoker) delegate
            {
                FreeStorageSpaceLabel.Text = _factory.FreeStorageSpace.ToString();
            });
        }

        private void StateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (StateComboBox.SelectedIndex)
            {
                case 0:
                    _factory.CurrentState = State.Buying;
                    break;
                case 1:
                    _factory.CurrentState = State.Creating;
                    break;
                case 2:
                    _factory.CurrentState = State.Sailing;
                    break;
            }
        }

        private void ReportsBtn_Click(object sender, EventArgs e)
        {
            if (OpenReportDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var fileOpener = new Process();
            fileOpener.StartInfo.FileName = "explorer";
            fileOpener.StartInfo.Arguments = "\"" + OpenReportDialog.FileName + "\"";
            fileOpener.Start();
        }
    }
}