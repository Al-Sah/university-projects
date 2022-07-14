using System;
using System.Windows.Forms;

namespace LabWork7.View
{
    public partial class RenameGroupDialog : Form
    {
        public string GroupName { get; set; }
        public int Id { get; set; }

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

            if (!((ManageGroupsDialog) Owner).RenameGroup(Id, TextBox.Text))
            {
                MessageBox.Show("Failed to rename group", "Ups", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }

        private void RenameGroupDialog_Load(object sender, EventArgs e)
        {
            TextBox.Text = GroupName;
        }
    }
}