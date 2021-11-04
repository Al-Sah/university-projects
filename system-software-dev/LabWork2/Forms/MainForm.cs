using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace LabWork2.Forms
{
    public partial class MainWindow : Form
    {
        private readonly List<Seaport> _seaports;
        private Seaport _activeSeaport;

        private readonly HireWorkerDialog _hireDialog;
        private readonly FireWorkerDialog _fireDialog;

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
            _activeSeaport++;
            UpdateLabels();
        }

        private void IncBtn_Click(object sender, EventArgs e)
        {
            _activeSeaport--;
            UpdateLabels();
        }

        private void CalcIncomeBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(IncomeTextBox.Text, out var res))
            {
                MessageBox.Show(
                    $"Calculated income: {_activeSeaport.CalcIncome(res)}\n Value represented in EUR", "Result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    $"Input value is not a number: '{IncomeTextBox.Text}", "Ups ... ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CalcTimeBtn_Click(object sender, System.EventArgs e)
        {
            if (Int32.TryParse(IncomeTextBox.Text, out int res))
            {
                var result = MessageBox.Show(
                    $"Calculated service time: {_activeSeaport.ShipServiceTime * res}\nValue represented in days",
                    "Result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                var result = MessageBox.Show(
                    $"Input value is not a number: '{IncomeTextBox.Text}'", "Ups ...",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateLabels()
        {
            AddressLabelValue.Text = _activeSeaport.Address;
            NameLabelValue.Text = _activeSeaport.Name;

            ServicePriceLabelValue.Text = _activeSeaport.ShipServicePrice.ToString();
            ServiceTimeLabelValue.Text = _activeSeaport.ShipServiceTime.ToString();

            EqPriceValue.Text = _activeSeaport.EquipmentPrice.ToString(CultureInfo.CurrentCulture);
            EqNumberLabelValue.Text = (_activeSeaport.GetDocksNumber() * Seaport.GetDockEquipmentAmount()).ToString();

            WorkersLabelValue.Text = _activeSeaport.GetWorkers().ToString();
            DocksLabelValue.Text = _activeSeaport.GetDocksNumber().ToString();
            FunctioningDocksLabelValue.Text = _activeSeaport.GetFunctioningDocks().ToString();
        }

        private void PortsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox) sender;
            _activeSeaport = _seaports.Find(seaport => seaport.Name == (string) comboBox.SelectedItem);
            UpdateLabels();
        }
    }
}