using System.Collections.Generic;

namespace LabWork7.Model
{
    public class FileData
    {
        public List<string> Groups { get; set; }
        public List<StudentInfo> Students { get; set; }

        public FileData()
        {
            Groups = new List<string>();
            Students = new List<StudentInfo>();
        }
    }
}