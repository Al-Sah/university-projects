
namespace LabWork3.Forms
{
    partial class SetupAffinityDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FinishBtn = new System.Windows.Forms.Button();
            this.ProcessorsList = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FinishBtn
            // 
            this.FinishBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FinishBtn.Location = new System.Drawing.Point(102, 361);
            this.FinishBtn.Margin = new System.Windows.Forms.Padding(100, 3, 100, 3);
            this.FinishBtn.Name = "FinishBtn";
            this.FinishBtn.Size = new System.Drawing.Size(180, 35);
            this.FinishBtn.TabIndex = 0;
            this.FinishBtn.Text = "OK";
            this.FinishBtn.UseVisualStyleBackColor = true;
            this.FinishBtn.Click += new System.EventHandler(this.FinishBtn_Click);
            // 
            // ProcessorsList
            // 
            this.ProcessorsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessorsList.FormattingEnabled = true;
            this.ProcessorsList.Location = new System.Drawing.Point(6, 66);
            this.ProcessorsList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ProcessorsList.Name = "ProcessorsList";
            this.ProcessorsList.Size = new System.Drawing.Size(372, 287);
            this.ProcessorsList.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.FinishBtn, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ProcessorsList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.InfoLabel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.62469F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.37531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 401);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoLabel.Location = new System.Drawing.Point(5, 2);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(374, 59);
            this.InfoLabel.TabIndex = 15;
            this.InfoLabel.Text = ".....";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetupAffinityDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 401);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SetupAffinityDialog";
            this.Text = "SetupAffinityDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetupAffinityDialog_FormClosing);
            this.Load += new System.EventHandler(this.SetupAffinityDialog_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button FinishBtn;

        #endregion

        private System.Windows.Forms.CheckedListBox ProcessorsList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label InfoLabel;
    }
}