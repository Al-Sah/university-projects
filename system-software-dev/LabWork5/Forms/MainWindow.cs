using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LabWork5.Model;
using Newtonsoft.Json;

namespace LabWork5.Forms
{
    public partial class MainWindow : Form
    {
        public List<StudentInfo> StudentList { get; set; }

        private readonly ManageStudentDialog _manageStudentDialog;

        public List<string> Groups { get; set; }

        public MainWindow()
        {
            Groups = new List<string> { "G1", "G2", "G3", "G4", "G5"};
            StudentList = new List<StudentInfo>();
            InitializeComponent();
            _manageStudentDialog = new ManageStudentDialog();
            SaveFileDialog.Filter = @"json files (*.json)|*.json";
            OpenFileDialog.Filter = @"json files (*.json)|*.json";
            SaveFileDialog.RestoreDirectory = true ;
        }

        private void LoadFileBtn_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            var fileData = File.ReadAllText(OpenFileDialog.FileName);
            StudentList = JsonConvert.DeserializeObject<List<StudentInfo>>(fileData);
            ResetDataGrid();
        }

        private void SaveFileBtn_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var stream = SaveFileDialog.OpenFile();
            var json = JsonConvert.SerializeObject(StudentList);
            var bytes = Encoding.UTF8.GetBytes(json);
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
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
                MessageBox.Show("You have select 1 student (1 row in data grid)", "Ups", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rowIndex = StudentsGrid.CurrentCell.RowIndex;
            _manageStudentDialog.IsModification = true;
            _manageStudentDialog.Groups = Groups;
            _manageStudentDialog.Student = StudentList.Find(s => s.StudentName == (string)StudentsGrid.SelectedRows[0].Cells["StudentName"].Value);
            if (_manageStudentDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var student = _manageStudentDialog.Student;
            StudentsGrid.Rows[rowIndex].Cells[1].Value = student.StudentName;
            StudentsGrid.Rows[rowIndex].Cells[2].Value = student.Group;
        }
        
        
        private void ResetDataGrid()
        {
            StudentsGrid.Rows.Clear();
            StudentsGrid.Rows.AddRange(StudentList.Select(student => new DataGridViewRow
            {
                Cells =
                {
                    new DataGridViewTextBoxCell {Value = student.StudentId},
                    new DataGridViewTextBoxCell {Value = student.StudentName},
                    new DataGridViewTextBoxCell {Value = student.Group},
                }
            }).ToArray());
        }

        private void DeleteStudentsBtn_Click(object sender, EventArgs e)
        {
            
            if (StudentsGrid.Rows.GetRowCount(DataGridViewElementStates.Selected) <= 0)
            {
                return;
            }
            
            var students = (from DataGridViewRow selectedRow in StudentsGrid.SelectedRows
                select  (string) selectedRow.Cells["StudentId"].Value).ToList();

            StudentList.RemoveAll(s => students.Contains(s.StudentId));
            foreach (DataGridViewRow row  in StudentsGrid.SelectedRows)
            {
                StudentsGrid.Rows.RemoveAt(row.Index);
            }
        }
    }
}