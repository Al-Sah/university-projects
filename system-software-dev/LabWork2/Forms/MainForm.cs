using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace LabWork2.Forms
{
    public partial class MainWindow : Form
    {
        private readonly List<Seaport> _seaports;
        public Seaport ActiveSeaport { get; set; }

        private readonly HireWorkerDialog _hireDialog;
        private readonly FireWorkerDialog _fireDialog;

        private readonly PortManagementDialog _portManagementDialog;

        private const string ErrorCaption = "Ups ... ";

        public MainWindow()
        {
            InitializeComponent();

            _seaports = new List<Seaport>();
            _seaports.AddRange(new[]
            {
                new Seaport("1", "Example1", 100, 100, 100),
                new Seaport("2", "Example2", 100, 100, 100)
            });
            foreach (var item in _seaports)
            {
                PortsList.Items.Add(item.Name);
            }

            PortsList.SelectedItem = PortsList.Items[0];

            _hireDialog = new HireWorkerDialog();
            _hireDialog.Owner = this;
            _fireDialog = new FireWorkerDialog();
            _fireDialog.Owner = this;
            _portManagementDialog = new PortManagementDialog();
            _portManagementDialog.Owner = this;
        }

        public bool AddNewPort(Seaport seaport)
        {
            if (_seaports.Find(i => i.Name == seaport.Name) != null)
                return false;

            _seaports.Add(seaport);
            PortsList.SelectedItem = PortsList.Items[PortsList.Items.Add(seaport.Name)];
            return true;
        }

        public bool DeletePort(Seaport seaport)
        {
            if (_seaports.Count <= 1 || !_seaports.Remove(seaport)) return false;
            PortsList.Items.Remove(seaport.Name);
            PortsList.SelectedItem = PortsList.Items[0];
            ActiveSeaport = _seaports[0];
            return true;
        }

        private void HireWorkerBtn_Click(object sender, EventArgs e)
        {
            _hireDialog.ShowDialog();
        }

        private void FireWorkersBtn_Click(object sender, EventArgs e)
        {
            _fireDialog.ShowDialog();
        }

        private void DecBtn_Click(object sender, EventArgs e)
        {
            ActiveSeaport++;
            /*var count = ActiveSeaport.GetDocksNumber();
            DocksView.Rows.Add(count.ToString(), ActiveSeaport.GetDockAt(count-1).State.ToString());*/
            UpdateDocksViewer();
            UpdateLabels();
        }

        private void IncBtn_Click(object sender, EventArgs e)
        {
            ActiveSeaport--;
            UpdateDocksViewer();
            UpdateLabels();
        }

        private void CalcIncomeBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(IncomeTextBox.Text, out var res))
            {
                MessageBox.Show(
                    $"Calculated income: {ActiveSeaport.CalcIncome(res)}\n Value represented in EUR", "Result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    $"Input value is not a number: '{IncomeTextBox.Text}", ErrorCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CalcTimeBtn_Click(object sender, System.EventArgs e)
        {
            if (Int32.TryParse(IncomeTextBox.Text, out int res))
            {
                MessageBox.Show(
                    $"Calculated service time: {ActiveSeaport.ShipServiceTime * res}\nValue represented in days",
                    "Result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    $"Input value is not a number: '{IncomeTextBox.Text}'", ErrorCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void UpdateLabels()
        {
            AddressLabelValue.Text = ActiveSeaport.Address;
            NameLabelValue.Text = ActiveSeaport.Name;

            ServicePriceLabelValue.Text = ActiveSeaport.ShipServicePrice.ToString();
            ServiceTimeLabelValue.Text = ActiveSeaport.ShipServiceTime.ToString();

            EqPriceValue.Text = ActiveSeaport.EquipmentPrice.ToString(CultureInfo.CurrentCulture);
            EqNumberLabelValue.Text = (ActiveSeaport.GetDocksNumber() * Seaport.GetDockEquipmentAmount()).ToString();

            WorkersLabelValue.Text = ActiveSeaport.GetWorkers().ToString();
            DocksLabelValue.Text = ActiveSeaport.GetDocksNumber().ToString();
            FunctioningDocksLabelValue.Text = ActiveSeaport.GetFunctioningDocks().ToString();
        }

        private void PortsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox) sender;
            ActiveSeaport = _seaports.Find(seaport => seaport.Name == (string) comboBox.SelectedItem);
            UpdateDocksViewer();
            UpdateLabels();
        }


        private void CreatePort_Click(object sender, EventArgs e)
        {
            _portManagementDialog.IsCreation = true;
            _portManagementDialog.ShowDialog();
        }

        private void ConfigBtn_Click(object sender, EventArgs e)
        {
            _portManagementDialog.IsCreation = false;
            _portManagementDialog.ShowDialog();
        }

        private void DeletePortBtn_Click(object sender, EventArgs e) => DeletePort(ActiveSeaport);

        private void CopyPort_Click(object sender, EventArgs e)
        {
            var newPort = new Seaport(ActiveSeaport);
            newPort.Name += "(Clone)";
            if (AddNewPort(newPort))
            {
                MessageBox.Show(
                    $" Port {newPort.Name} created", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    $"Failed to add port. {newPort.Name} exists!", ErrorCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void UpdateDocksViewer()
        {
            DocksView.Rows.Clear();
            for (var i = 1; i < ActiveSeaport.GetDocksNumber() + 1; i++)
            {
                DocksView.Rows.Add(i.ToString(), ActiveSeaport.GetDockAt(i - 1).State.ToString());
            }
        }
    }
}