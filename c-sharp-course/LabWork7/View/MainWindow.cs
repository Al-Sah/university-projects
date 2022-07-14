using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LabWork7.Model;

namespace LabWork7.View

{
    public partial class MainWindow : Form
    {
        //private List<StudentInfo> StudentList { get; set; }

        private readonly ManageStudentDialog _manageStudentDialog;
        private readonly ManageGroupsDialog _manageGroupsDialog;
        private const string ConnectData = @"Server=localhost\SQLEXPRESS;Database=alx-lab;Trusted_Connection=True;";
        public SqlConnection Conn { get; }
        public List<string> GroupsList { get; private set; }

        public MainWindow()
        {
            GroupsList = new List<string>();
            //StudentList = new List<StudentInfo>();
            InitializeComponent();
            _manageStudentDialog = new ManageStudentDialog();
            _manageGroupsDialog = new ManageGroupsDialog {Owner = this};
            SaveFileDialog.Filter = @"json files (*.json)|*.json";
            OpenFileDialog.Filter = @"json files (*.json)|*.json";
            SaveFileDialog.RestoreDirectory = true;

            Conn = new SqlConnection(ConnectData);
            try
            {
                Conn.Open();
            }
            catch (SqlException)
            {
            }
        }

        private void ResetGroups()
        {
            GroupsList.Clear();
            GroupsComboBox.Items.Clear();
            GroupsComboBox.Items.Add("All");
            GroupsComboBox.SelectedItem = "All";

            var cmd = new SqlCommand("Select Name From Groups", Conn);
            using (var dr = cmd.ExecuteReader(CommandBehavior.Default))
            {
                while (dr.Read())
                {
                    var group = dr.GetValue(0).ToString();
                    GroupsComboBox.Items.Add(group);
                    GroupsList.Add(group);
                }
            }
        }

        private void AddStudentBtn_Click(object sender, EventArgs e)
        {
            _manageStudentDialog.IsModification = false;
            _manageStudentDialog.Groups = GroupsList;
            if (_manageStudentDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var student = _manageStudentDialog.Student;
            try
            {
                var group = $"(Select Id from Groups where Name = '{student.Group}')";
                new SqlCommand(
                    $"Insert into Students (\"StudentName\", \"Group\") Values ('{student.StudentName}', {group})",
                    Conn).ExecuteNonQuery();
                ResetDataGrid();
            }
            catch (SqlException)
            {
            }
        }


        private void ModifyStudentsBtn_Click(object sender, EventArgs e)
        {
            if (StudentsGrid.SelectedRows.Count != 1)
            {
                MessageBox.Show(@"You have select 1 student (1 row in data grid)", @"Ups", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _manageStudentDialog.IsModification = true;
            _manageStudentDialog.Groups = GroupsList;
            _manageStudentDialog.Student = new StudentInfo(StudentsGrid.SelectedRows[0]);
            if (_manageStudentDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var student = _manageStudentDialog.Student;
            try
            {
                var group = $"(Select Id from Groups where Name = '{student.Group}')";
                new SqlCommand(
                    $"Update Students Set \"StudentName\" = '{student.StudentName}', \"Group\" = {group} where Id = '{student.StudentId}'",
                    Conn).ExecuteNonQuery();
                ResetDataGrid();
            }
            catch (SqlException)
            {
            }
        }


        private void ResetDataGrid()
        {
            const string getAllFromDb =
                "Select s.Id, s.StudentName, g.Name as \"Group\" from [alx-lab].[dbo].Students as s join [alx-lab].[dbo].Groups as g on (g.Id = s.[Group])";
            var dataString = getAllFromDb;
            if (GroupsComboBox.SelectedItem.ToString() != "All")
            {
                dataString +=
                    $" where s.\"Group\" = (Select Id from Groups where Name = '{GroupsComboBox.SelectedItem}')";
            }

            using (var data = new SqlDataAdapter(dataString, Conn))
            {
                var table = new DataTable();
                data.Fill(table);
                StudentsGrid.DataSource = table;
                StudentsGrid.ResetBindings();
            }

            foreach (DataGridViewColumn groupsGridColumn in StudentsGrid.Columns)
            {
                groupsGridColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void DeleteStudentsBtn_Click(object sender, EventArgs e)
        {
            if (StudentsGrid.Rows.GetRowCount(DataGridViewElementStates.Selected) <= 0)
            {
                return;
            }

            var students = (from DataGridViewRow selectedRow in StudentsGrid.SelectedRows
                select (int) selectedRow.Cells["Id"].Value).ToList();

            var stringBuilder = new StringBuilder();
            for (var index = 0; index < students.Count; index++)
            {
                stringBuilder.Append("'").Append(students[index]).Append("'");
                if (index < students.Count - 1)
                {
                    stringBuilder.Append(", ");
                }
            }

            var cmd = new SqlCommand($"Delete From Students where Id IN ({stringBuilder})", Conn);
            try
            {
                cmd.ExecuteNonQuery();
                ResetDataGrid();
            }
            catch
            {
                // ignored
            }
        }


        private void ManageGroupsBtn_Click(object sender, EventArgs e)
        {
            _manageGroupsDialog.ShowDialog();
            ResetGroups();
            ResetDataGrid();
        }

        private void ApplyBtn_Click(object sender, EventArgs e) => ResetDataGrid();

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) => Conn.Close();

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ResetGroups();
            ResetDataGrid();
        }
    }
}