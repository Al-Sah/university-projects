using System;

namespace LabWork5.Model
{
    public class StudentInfo
    {
        public string StudentId { get; }
        public string StudentName { get; set; }
        public string Group { get; set; }

        public StudentInfo(string studentName, string group)
        {
            StudentId = Guid.NewGuid().ToString();
            StudentName = studentName;
            Group = group;
        }
    }
}