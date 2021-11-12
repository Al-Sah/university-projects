using System;
using System.Linq;
using System.Windows.Forms;

namespace LabWork3.Forms
{
    public partial class SetupAffinityDialog : Form
    {
        public long ProcessorsCount { get; set; }
        public long Mask { get; private set; }

        public SetupAffinityDialog() => InitializeComponent();

        private void SetupAffinityDialog_Load(object sender, EventArgs e)
        {
            ProcessorsList.Items.Clear();
            ProcessorsList.SetItemChecked(ProcessorsList.Items.Add("< Use All >"), true);
            for (var i = 1; i < ProcessorsCount + 1; i++)
            {
                ProcessorsList.SetItemChecked(ProcessorsList.Items.Add("CPU" + i), true);
            }
        }

        private long GetMask()
        {
            if (ProcessorsList.CheckedIndices.Contains(0))
            {
                return (1U << (int) ProcessorsCount) - 1U;
            }

            return ProcessorsList.CheckedIndices.Cast<int>()
                .Aggregate(0L, (current, item) => current | (uint) (1 << item));
        }

        private void FinishBtn_Click(object sender, EventArgs e)
        {
            Mask = GetMask();
            Close();
        }

        private void SetupAffinityDialog_FormClosing(object sender, FormClosingEventArgs e) => Mask = GetMask();
    }
}