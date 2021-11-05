
namespace LabWork2.Forms
{
    partial class PortsComparatorDialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.PortsList1 = new System.Windows.Forms.ComboBox();
            this.DocksList1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DocksList2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PortsList2 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PortsCmp = new System.Windows.Forms.Label();
            this.DocksCmp = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Liberation Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(127, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 51);
            this.label2.TabIndex = 24;
            this.label2.Text = "Select Port";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PortsList1
            // 
            this.PortsList1.AllowDrop = true;
            this.PortsList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PortsList1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortsList1.Location = new System.Drawing.Point(127, 105);
            this.PortsList1.Name = "PortsList1";
            this.PortsList1.Size = new System.Drawing.Size(118, 29);
            this.PortsList1.TabIndex = 23;
            this.PortsList1.SelectedIndexChanged += new System.EventHandler(this.PortsList1_SelectedIndexChanged);
            // 
            // DocksList1
            // 
            this.DocksList1.AllowDrop = true;
            this.DocksList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocksList1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DocksList1.Location = new System.Drawing.Point(127, 207);
            this.DocksList1.Name = "DocksList1";
            this.DocksList1.Size = new System.Drawing.Size(118, 29);
            this.DocksList1.TabIndex = 25;
            this.DocksList1.SelectedIndexChanged += new System.EventHandler(this.DocksList1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Liberation Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(127, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 51);
            this.label1.TabIndex = 26;
            this.label1.Text = "Select Dock";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Liberation Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(375, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 51);
            this.label3.TabIndex = 30;
            this.label3.Text = "Select Dock";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DocksList2
            // 
            this.DocksList2.AllowDrop = true;
            this.DocksList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocksList2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DocksList2.Location = new System.Drawing.Point(375, 207);
            this.DocksList2.Name = "DocksList2";
            this.DocksList2.Size = new System.Drawing.Size(118, 29);
            this.DocksList2.TabIndex = 29;
            this.DocksList2.SelectedIndexChanged += new System.EventHandler(this.DocksList2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Liberation Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(375, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 51);
            this.label4.TabIndex = 28;
            this.label4.Text = "Select Port";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PortsList2
            // 
            this.PortsList2.AllowDrop = true;
            this.PortsList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PortsList2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortsList2.Location = new System.Drawing.Point(375, 105);
            this.PortsList2.Name = "PortsList2";
            this.PortsList2.Size = new System.Drawing.Size(118, 29);
            this.PortsList2.TabIndex = 27;
            this.PortsList2.SelectedIndexChanged += new System.EventHandler(this.PortsList2_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.PortsList2, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.DocksList1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.PortsList1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.DocksList2, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.PortsCmp, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.DocksCmp, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 361);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // PortsCmp
            // 
            this.PortsCmp.AutoSize = true;
            this.PortsCmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PortsCmp.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PortsCmp.Location = new System.Drawing.Point(251, 102);
            this.PortsCmp.Name = "PortsCmp";
            this.PortsCmp.Size = new System.Drawing.Size(118, 51);
            this.PortsCmp.TabIndex = 32;
            this.PortsCmp.Text = "....";
            this.PortsCmp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DocksCmp
            // 
            this.DocksCmp.AutoSize = true;
            this.DocksCmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocksCmp.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DocksCmp.Location = new System.Drawing.Point(251, 204);
            this.DocksCmp.Name = "DocksCmp";
            this.DocksCmp.Size = new System.Drawing.Size(118, 51);
            this.DocksCmp.TabIndex = 33;
            this.DocksCmp.Text = "....";
            this.DocksCmp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PortsComparatorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 361);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PortsComparatorDialog";
            this.Text = "PortsComparatorDialog";
            this.Load += new System.EventHandler(this.PortsComparatorDialog_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PortsList1;
        private System.Windows.Forms.ComboBox DocksList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox DocksList2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox PortsList2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label PortsCmp;
        private System.Windows.Forms.Label DocksCmp;
    }
}