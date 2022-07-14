using System.Windows.Forms;

namespace LabWork7.Model
{
    public class StudentInfo
    {
        public string StudentId { get; }
        public string StudentName { get; }
        public string Group { get; }

        public StudentInfo(string id, string studentName, string group)
        {
            StudentId = id;
            StudentName = studentName;
            Group = group;
        }

        public StudentInfo(DataGridViewRow row)
        {
            StudentId = row.Cells["Id"].Value.ToString();
            StudentName = row.Cells["StudentName"].Value.ToString();
            Group = row.Cells["Group"].Value.ToString();
            ;
        }
    }
}