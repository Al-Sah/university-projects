
namespace LabWork2.Forms
{
    partial class HireWorkerDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.WorkersNumberValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.HireBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Currently hired";
            // 
            // WorkersNumberValue
            // 
            this.WorkersNumberValue.AutoSize = true;
            this.WorkersNumberValue.Location = new System.Drawing.Point(223, 66);
            this.WorkersNumberValue.Name = "WorkersNumberValue";
            this.WorkersNumberValue.Size = new System.Drawing.Size(20, 21);
            this.WorkersNumberValue.TabIndex = 1;
            this.WorkersNumberValue.Text = ". .";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "workers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Number to hire";
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(149, 138);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(161, 29);
            this.InputBox.TabIndex = 8;
            // 
            // HireBtn
            // 
            this.HireBtn.Location = new System.Drawing.Point(184, 173);
            this.HireBtn.Name = "HireBtn";
            this.HireBtn.Size = new System.Drawing.Size(99, 36);
            this.HireBtn.TabIndex = 10;
            this.HireBtn.Text = "Apply";
            this.HireBtn.UseVisualStyleBackColor = true;
            this.HireBtn.Click += new System.EventHandler(this.HireBtn_Click);
            // 
            // HireWorkerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 251);
            this.Controls.Add(this.HireBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WorkersNumberValue);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HireWorkerDialog";
            this.Text = "HireWorkerDialog";
            this.Load += new System.EventHandler(this.HireWorkerDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label WorkersNumberValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Button HireBtn;
    }
}