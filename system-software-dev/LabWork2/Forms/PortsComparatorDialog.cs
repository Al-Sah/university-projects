using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LabWork2.Forms
{
    public partial class PortsComparatorDialog : Form
    {
        private Seaport _seaport1;
        private Seaport _seaport2;

        public PortsComparatorDialog()
        {
            InitializeComponent();
        }

        private void PortsList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _seaport1 = ((MainWindow) Owner).Seaports.Find(item => item.Name == PortsList1.SelectedItem);
            SetupDockList(DocksList1, _seaport1);
            PortsCmp.Text = _seaport1 >= _seaport2 ? ">=" : "<=";
        }


        private void PortsList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _seaport2 = ((MainWindow) Owner).Seaports.Find(item => item.Name == PortsList2.SelectedItem);
            SetupDockList(DocksList2, _seaport2);
            PortsCmp.Text = _seaport1 >= _seaport2 ? ">=" : "<=";
        }

        private void DocksList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DocksList1.SelectedIndex < 0 || DocksList2.SelectedIndex < 0)
            {
                DocksCmp.Text = "???";
                return;
            }

            DocksCmp.Text = _seaport1.Equals(
                _seaport1.Docks[DocksList1.SelectedIndex],
                _seaport2.Docks[DocksList2.SelectedIndex])
                ? "=="
                : "!=";
        }

        private void DocksList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DocksList1.SelectedIndex < 0 || DocksList2.SelectedIndex < 0)
            {
                DocksCmp.Text = "???";
                return;
            }

            DocksCmp.Text = _seaport1.Equals(
                _seaport1.Docks[DocksList1.SelectedIndex],
                _seaport2.Docks[DocksList2.SelectedIndex])
                ? "=="
                : "!=";
        }


        private void PortsComparatorDialog_Load(object sender, EventArgs e)
        {
            var owner = (MainWindow) Owner;
            _seaport1 = owner.Seaports[0];
            _seaport2 = owner.Seaports[0];

            object[] ports = owner.Seaports.Select(port => port.Name).ToArray();

            PortsList1.Items.Clear();
            PortsList2.Items.Clear();
            PortsList1.Items.AddRange(ports);
            PortsList2.Items.AddRange(ports);

            PortsList1.SelectedItem = PortsList1.Items[0];
            PortsList2.SelectedItem = PortsList2.Items[0];
        }

        private static void SetupDockList(ComboBox list, Seaport port)
        {
            if (port.Docks.Count == 0) return;
            var docks = new List<string> {Capacity = port.Docks.Count};
            docks.AddRange(port.Docks.Select((t, index) => $"{index + 1} : {t.State}"));
            list.Items.Clear();
            list.Items.AddRange(docks.ToArray());
            list.SelectedItem = list.Items[0];
        }
    }
}