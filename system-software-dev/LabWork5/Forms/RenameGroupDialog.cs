using System;
using System.Windows.Forms;

namespace LabWork5.Forms
{
    public partial class RenameGroupDialog : Form
    {
        public string GroupName { get; set; }

        public RenameGroupDialog()
        {
            InitializeComponent();
        }

        private void RenameBtn_Click(object sender, EventArgs e)
        {
            if (TextBox.Text == string.Empty || TextBox.Text == GroupName)
            {
                return;
            }

            if (!((ManageGroupsDialog) Owner).RenameGroup(TextBox.Text, GroupName))
            {
                MessageBox.Show("Failed to rename group", "Ups", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }

        private void RenameGroupDialog_Load(object sender, EventArgs e) => TextBox.Text = GroupName;
    }
}