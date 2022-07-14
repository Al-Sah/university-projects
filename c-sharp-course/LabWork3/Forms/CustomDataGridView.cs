using System;
using System.Windows.Forms;

namespace LabWork3.Forms
{
    public class CustomDataGridView : DataGridView
    {
        public event Action? RightKeyDown;
        public event Action? LeftKeyDown;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyData & Keys.KeyCode)
            {
                case Keys.Right:
                    RightKeyDown?.Invoke();
                    return;
                case Keys.Left:
                    LeftKeyDown?.Invoke();
                    return;
            }

            base.OnKeyDown(e);
        }
    }
}