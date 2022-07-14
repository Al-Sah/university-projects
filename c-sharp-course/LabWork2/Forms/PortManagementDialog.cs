using System;
using System.Windows.Forms;

namespace LabWork2.Forms
{
    public partial class PortManagementDialog : Form
    {
        public bool IsCreation { get; set; }
        public PortManagementDialog() => InitializeComponent();
        private const string ErrorCaption = "Ups ... ";

        private void PortBtn_Click(object sender, EventArgs e)
        {
            var port = ((MainWindow) Owner).ActiveSeaport;
            if (int.TryParse(InServiceTime.Text, out var time) &&
                int.TryParse(InServicePrice.Text, out var price) &&
                int.TryParse(InEquipmentPrice.Text, out var eqPrice))
            {
                if (IsCreation)
                {
                    if (InName.Text != "" && InAddress.Text != "")
                    {
                        if (((MainWindow) Owner).AddNewPort(new Seaport(InAddress.Text, InName.Text, time, price,
                            eqPrice)))
                        {
                            MessageBox.Show(
                                $" Port {InName.Text} created", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(
                                $"Failed to add port. {InName.Text} exists!", ErrorCaption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "Input error. 'Name' and 'Address' cannot be empty", ErrorCaption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    port.ShipServiceTime = time;
                    port.ShipServicePrice = price;
                    port.EquipmentPrice = eqPrice;
                    ((MainWindow) Owner).UpdateLabels();
                    MessageBox.Show(
                        $" Port {InName.Text} updated", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(
                    "Input error. Fields with prices and time must contain numbers", ErrorCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void PortManagementDialog_Load(object sender, EventArgs e)
        {
            var port = ((MainWindow) Owner).ActiveSeaport;

            if (IsCreation)
            {
                InName.Enabled = true;
                InAddress.Enabled = true;
                InName.Text = "";
                InAddress.Text = "";
                InServiceTime.Text = "";
                InServicePrice.Text = "";
                InEquipmentPrice.Text = "";
            }
            else
            {
                InName.Enabled = false;
                InAddress.Enabled = false;
                InName.Text = port.Name;
                InAddress.Text = port.Address;
                InServiceTime.Text = port.ShipServiceTime.ToString();
                InServicePrice.Text = port.ShipServicePrice.ToString();
                InEquipmentPrice.Text = port.EquipmentPrice.ToString();
            }
        }
    }
}