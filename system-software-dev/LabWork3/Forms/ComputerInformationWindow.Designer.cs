
namespace LabWork3.Forms
{
    partial class ComputerInformationWindow
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
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.InfoTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MemoryInfoGridView = new System.Windows.Forms.DataGridView();
            this.ProcessorInfoLabel = new System.Windows.Forms.Label();
            this.MemoryInfoLabel = new System.Windows.Forms.Label();
            this.ProcessorInfoGridView = new System.Windows.Forms.DataGridView();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.MemoryOption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoryValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessorOption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessorValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainLayout.SuspendLayout();
            this.InfoTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.MemoryInfoGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.ProcessorInfoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 1;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Controls.Add(this.InfoTableLayout, 0, 1);
            this.MainLayout.Controls.Add(this.InfoLabel, 0, 0);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 3;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.7551F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.39796F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.102041F));
            this.MainLayout.Size = new System.Drawing.Size(865, 392);
            this.MainLayout.TabIndex = 0;
            // 
            // InfoTableLayout
            // 
            this.InfoTableLayout.ColumnCount = 2;
            this.InfoTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.InfoTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.InfoTableLayout.Controls.Add(this.MemoryInfoGridView, 0, 1);
            this.InfoTableLayout.Controls.Add(this.ProcessorInfoLabel, 1, 0);
            this.InfoTableLayout.Controls.Add(this.MemoryInfoLabel, 0, 0);
            this.InfoTableLayout.Controls.Add(this.ProcessorInfoGridView, 1, 1);
            this.InfoTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoTableLayout.Location = new System.Drawing.Point(3, 52);
            this.InfoTableLayout.Name = "InfoTableLayout";
            this.InfoTableLayout.RowCount = 2;
            this.InfoTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.44776F));
            this.InfoTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.55224F));
            this.InfoTableLayout.Size = new System.Drawing.Size(859, 316);
            this.InfoTableLayout.TabIndex = 0;
            // 
            // MemoryInfoGridView
            // 
            this.MemoryInfoGridView.AllowUserToAddRows = false;
            this.MemoryInfoGridView.AllowUserToDeleteRows = false;
            this.MemoryInfoGridView.AllowUserToOrderColumns = true;
            this.MemoryInfoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MemoryInfoGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.MemoryOption, this.MemoryValue});
            this.MemoryInfoGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemoryInfoGridView.Location = new System.Drawing.Point(3, 36);
            this.MemoryInfoGridView.Name = "MemoryInfoGridView";
            this.MemoryInfoGridView.ReadOnly = true;
            this.MemoryInfoGridView.Size = new System.Drawing.Size(423, 277);
            this.MemoryInfoGridView.TabIndex = 3;
            // 
            // ProcessorInfoLabel
            // 
            this.ProcessorInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessorInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ProcessorInfoLabel.Location = new System.Drawing.Point(432, 0);
            this.ProcessorInfoLabel.Name = "ProcessorInfoLabel";
            this.ProcessorInfoLabel.Size = new System.Drawing.Size(424, 33);
            this.ProcessorInfoLabel.TabIndex = 1;
            this.ProcessorInfoLabel.Text = "Processor information";
            this.ProcessorInfoLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // MemoryInfoLabel
            // 
            this.MemoryInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemoryInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.MemoryInfoLabel.Location = new System.Drawing.Point(3, 0);
            this.MemoryInfoLabel.Name = "MemoryInfoLabel";
            this.MemoryInfoLabel.Size = new System.Drawing.Size(423, 33);
            this.MemoryInfoLabel.TabIndex = 0;
            this.MemoryInfoLabel.Text = "Memory information";
            this.MemoryInfoLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ProcessorInfoGridView
            // 
            this.ProcessorInfoGridView.AllowUserToAddRows = false;
            this.ProcessorInfoGridView.AllowUserToDeleteRows = false;
            this.ProcessorInfoGridView.AllowUserToOrderColumns = true;
            this.ProcessorInfoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessorInfoGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.ProcessorOption, this.ProcessorValue});
            this.ProcessorInfoGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessorInfoGridView.Location = new System.Drawing.Point(432, 36);
            this.ProcessorInfoGridView.Name = "ProcessorInfoGridView";
            this.ProcessorInfoGridView.ReadOnly = true;
            this.ProcessorInfoGridView.Size = new System.Drawing.Size(424, 277);
            this.ProcessorInfoGridView.TabIndex = 2;
            // 
            // InfoLabel
            // 
            this.InfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoLabel.Location = new System.Drawing.Point(3, 0);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(859, 49);
            this.InfoLabel.TabIndex = 1;
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // MemoryOption
            // 
            this.MemoryOption.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MemoryOption.HeaderText = "Option";
            this.MemoryOption.Name = "MemoryOption";
            this.MemoryOption.ReadOnly = true;
            // 
            // MemoryValue
            // 
            this.MemoryValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MemoryValue.HeaderText = "Value";
            this.MemoryValue.Name = "MemoryValue";
            this.MemoryValue.ReadOnly = true;
            this.MemoryValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProcessorOption
            // 
            this.ProcessorOption.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProcessorOption.HeaderText = "Option";
            this.ProcessorOption.Name = "ProcessorOption";
            this.ProcessorOption.ReadOnly = true;
            // 
            // ProcessorValue
            // 
            this.ProcessorValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProcessorValue.HeaderText = "Value";
            this.ProcessorValue.Name = "ProcessorValue";
            this.ProcessorValue.ReadOnly = true;
            this.ProcessorValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ComputerInformationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 392);
            this.Controls.Add(this.MainLayout);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ComputerInformationWindow";
            this.Text = "ComputerInformationWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComputerInformationWindow_FormClosing);
            this.Load += new System.EventHandler(this.ComputerInformationWindow_Load);
            this.MainLayout.ResumeLayout(false);
            this.InfoTableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.MemoryInfoGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.ProcessorInfoGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn MemoryOption;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoryValue;

        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessorOption;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessorValue;

        private System.Windows.Forms.DataGridView ProcessorInfoGridView;
        private System.Windows.Forms.DataGridView MemoryInfoGridView;

        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Label MemoryInfoLabel;
        private System.Windows.Forms.Label ProcessorInfoLabel;

        private System.Windows.Forms.TableLayoutPanel InfoTableLayout;
        private System.Windows.Forms.TableLayoutPanel MainLayout;

        #endregion
    }
}