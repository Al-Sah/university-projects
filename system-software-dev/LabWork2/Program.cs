using System;
using System.Windows.Forms;

namespace LabWork2
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var seaport = new Seaport("UK12", "Seaport Z", 100, 100, 100);
            seaport++;
            var count = seaport.GetEquipmentNumber();
            seaport.HireWorkers(24);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}