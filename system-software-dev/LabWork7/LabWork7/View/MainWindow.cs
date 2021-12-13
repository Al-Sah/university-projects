using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using LabWork7.Model;

namespace LabWork7.View

{
    public partial class MainWindow : Form
    {
        private List<StudentInfo> StudentList { get; set; }

        private readonly ManageStudentDialog _manageStudentDialog;
        private readonly ManageGroupsDialog _manageGroupsDialog;
        private const string ConnectData = @"Server=localhost\SQLEXPRESS;Database=test;Trusted_Connection=True;";
        private readonly SqlConnection _conn;
        public List<string> Groups { get; private set; }

        public MainWindow()
        {
            Groups = new List<string>();
            StudentList = new List<StudentInfo>();
            InitializeComponent();
            _manageStudentDialog = new ManageStudentDialog();
            _manageGroupsDialog = new ManageGroupsDialog {Owner = this};
            SaveFileDialog.Filter = @"json files (*.json)|*.json";
            OpenFileDialog.Filter = @"json files (*.json)|*.json";
            SaveFileDialog.RestoreDirectory = true;
            GroupsComboBox.Items.Add("All");
            GroupsComboBox.Items.Add("Undefined");
            GroupsComboBox.SelectedItem = "All";

            _conn = new SqlConnection(ConnectData);
            try
            {
                _conn.Open();
                new SqlCommand("IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'students') " +
                               "CREATE TABLE students ( s_name INT);", _conn).ExecuteNonQuery();
            }
            catch (SqlException)
            {
            }
        }

        private void AddStudentBtn_Click(object sender, EventArgs e)
        {
            _manageStudentDialog.IsModification = false;
            _manageStudentDialog.Groups = Groups;
            if (_manageStudentDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var student = _manageStudentDialog.Student;
            StudentList.Add(student);
            StudentsGrid.Rows.Add(student.StudentId, student.StudentName, student.Group);
        }


        private void ModifyStudentsBtn_Click(object sender, EventArgs e)
        {
            if (StudentsGrid.SelectedRows.Count != 1)
            {
                MessageBox.Show(@"You have select 1 student (1 row in data grid)", @"Ups", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var rowIndex = StudentsGrid.CurrentCell.RowIndex;
            _manageStudentDialog.IsModification = true;
            _manageStudentDialog.Groups = Groups;
            _manageStudentDialog.Student = StudentList.Find(s =>
                s.StudentName == (string) StudentsGrid.SelectedRows[0].Cells["StudentName"].Value);
            if (_manageStudentDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var student = _manageStudentDialog.Student;
            StudentsGrid.Rows[rowIndex].Cells[1].Value = student.StudentName;
            StudentsGrid.Rows[rowIndex].Cells[2].Value = student.Group;
            // TODO fix StudentList
        }


        private void ResetDataGrid()
        {
            StudentsGrid.Rows.Clear();
            var toPrintList = GroupsComboBox.SelectedItem.ToString() == "All"
                ? StudentList
                : StudentList.FindAll(s => s.Group == GroupsComboBox.SelectedItem.ToString());

            StudentsGrid.Rows.AddRange(toPrintList.Select(student => new DataGridViewRow
            {
                Cells =
                {
                    new DataGridViewTextBoxCell {Value = student.StudentId},
                    new DataGridViewTextBoxCell {Value = student.StudentName},
                    new DataGridViewTextBoxCell {Value = student.Group},
                }
            }).ToArray());
        }

        public void OnGroupAdded(string group) => GroupsComboBox.Items.Add(group);

        public void OnGroupsDeleted(List<string> deleted)
        {
            foreach (var studentInfo in StudentList.Where(studentInfo => deleted.Contains(studentInfo.Group)))
            {
                studentInfo.Group = "Undefined";
            }

            foreach (var s in deleted)
            {
                GroupsComboBox.Items.Remove(s);
            }

            GroupsComboBox.SelectedItem = "All";
            ResetDataGrid();
        }

        public void OnGroupsRenamed(string newName, string oldName)
        {
            foreach (var studentInfo in StudentList.Where(studentInfo => studentInfo.Group == oldName))
            {
                studentInfo.Group = newName;
            }

            GroupsComboBox.Items[GroupsComboBox.Items.IndexOf(oldName)] = newName;
            ResetDataGrid();
        }

        private void DeleteStudentsBtn_Click(object sender, EventArgs e)
        {
            if (StudentsGrid.Rows.GetRowCount(DataGridViewElementStates.Selected) <= 0)
            {
                return;
            }

            var students = (from DataGridViewRow selectedRow in StudentsGrid.SelectedRows
                select (string) selectedRow.Cells["StudentId"].Value).ToList();

            StudentList.RemoveAll(s => students.Contains(s.StudentId));
            foreach (DataGridViewRow row in StudentsGrid.SelectedRows)
            {
                StudentsGrid.Rows.RemoveAt(row.Index);
            }
        }

        private void ManageGroupsBtn_Click(object sender, EventArgs e)
        {
            _manageGroupsDialog.ShowDialog();
        }

        private void ApplyBtn_Click(object sender, EventArgs e) => ResetDataGrid();

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) => _conn.Close();
    }
}