using System;
using System.Windows.Forms;

namespace LabWork5.Forms
{
    public partial class AddGroupDialog : Form
    {
        public AddGroupDialog() => InitializeComponent();

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (TextBox.Text == string.Empty)
            {
                return;
            }

            if (!((ManageGroupsDialog) Owner).AddNewGroup(TextBox.Text))
            {
                MessageBox.Show("Failed to add group", "Ups", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}