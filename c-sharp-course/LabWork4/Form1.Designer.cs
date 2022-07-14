namespace LabWork4
{
    partial class Form1
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
            this.ProcessBtn = new System.Windows.Forms.Button();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // ProcessBtn
            // 
            this.ProcessBtn.Location = new System.Drawing.Point(80, 88);
            this.ProcessBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ProcessBtn.Name = "ProcessBtn";
            this.ProcessBtn.Size = new System.Drawing.Size(156, 35);
            this.ProcessBtn.TabIndex = 0;
            this.ProcessBtn.Text = "Do magic with file";
            this.ProcessBtn.UseVisualStyleBackColor = true;
            this.ProcessBtn.Click += new System.EventHandler(this.ProcessBtn_Click);
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Location = new System.Drawing.Point(257, 88);
            this.GenerateBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(112, 35);
            this.GenerateBtn.TabIndex = 1;
            this.GenerateBtn.Text = "Generate file";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "OpenFileDialog";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 231);
            this.Controls.Add(this.GenerateBtn);
            this.Controls.Add(this.ProcessBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "File processor";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.OpenFileDialog OpenFileDialog;

        private System.Windows.Forms.Button ProcessBtn;
        private System.Windows.Forms.Button GenerateBtn;

        #endregion
    }
}