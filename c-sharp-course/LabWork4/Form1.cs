using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabWork4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OpenFileDialog.Filter = "txt files (*.txt)|*.txt";
        }

        private void ProcessBtn_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            
            var filename = OpenFileDialog.FileName;
            var fileText = File.ReadAllText(filename).Split(' ');
            try
            {
                var list = fileText.Except(new []{string.Empty}).Select(t => double.Parse(t)).ToList();
                var maxIndex = list.IndexOf(list.Max());
                var minIndex = list.IndexOf(list.Min());
                MessageBox.Show(
                    $"index of max value: {maxIndex}; value {list[maxIndex]}\n" +
                        $"index of min value: {minIndex}; value {list[minIndex]}\n", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //deconstruction
                (list[maxIndex], list[minIndex]) = (list[minIndex], list[maxIndex]);
                WriteToFile(list, filename);
            }
            catch (Exception)
            {
                MessageBox.Show("File contains bad values", "Ups", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            var fileStream = new FileStream(Directory.GetCurrentDirectory() + "/numbers.txt", FileMode.Create);
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var bytes = Encoding.UTF8.GetBytes(random.NextDouble() * 1000 + " ");
                fileStream.Write(bytes, 0, bytes.Length);
            }
            fileStream.Close();
        }
        
        private static void WriteToFile(IEnumerable<double> values, string file)
        {
            File.WriteAllText(file,string.Empty);
            var fileStream = new FileStream(file, FileMode.Open);
            foreach (var bytes in values.Select(value => Encoding.UTF8.GetBytes(value + " ")))
            {
                fileStream.Write(bytes, 0, bytes.Length);
            }
            fileStream.Close();
        }
    }
}