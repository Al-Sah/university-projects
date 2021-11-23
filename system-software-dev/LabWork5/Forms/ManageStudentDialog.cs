using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LabWork5.Model;

namespace LabWork5.Forms
{
    public partial class ManageStudentDialog : Form
    {

        public List<string> Groups { get; set; }

        public StudentInfo Student { get; set; }
        
        public bool IsModification { get; set; }

        public ManageStudentDialog()
        {
            Groups = new List<string>();
            InitializeComponent();
        }

        private void AddStudentDialog_Load(object sender, EventArgs e)
        {
            GroupsListBox.Items.Clear();
            GroupsListBox.Items.AddRange(Groups.ToArray());
            
            if (IsModification)
            {
                AddStudentLabel.Text = $"Modifying student {Student.StudentName}.\n Current Group {Student.Group}";
                GroupsListBox.SelectedItem = Student.Group;
                NameTextBox.Text = Student.StudentName;
            }
            else
            {
                AddStudentLabel.Text = "Add new student";
                GroupsListBox.SelectedIndex = -1;
                NameTextBox.Text = string.Empty;
            }
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == string.Empty ||  GroupsListBox.SelectedItem == null || GroupsListBox.SelectedItem.ToString() == string.Empty)
            {
                MessageBox.Show("Failed to create student; Input contains emty fields", "Ups", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Student = new StudentInfo(NameTextBox.Text, GroupsListBox.SelectedItem.ToString());
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
