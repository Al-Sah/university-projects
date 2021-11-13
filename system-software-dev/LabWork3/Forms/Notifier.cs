using System.Windows.Forms;

namespace LabWork3.Forms
{
    public static class Notifier
    {
        private const string ErrorCaption = "Ups";

        public static void ErrorMessageBox(string error)
        {
            MessageBox.Show(error, ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}