
namespace LabWork3.Forms
{
    partial class MainWindow
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
            this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ComutersControlBasePanel = new System.Windows.Forms.TableLayoutPanel();
            this.ComputersLabel = new System.Windows.Forms.Label();
            this.ComputersControlPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DeleteComputerBtn = new System.Windows.Forms.Button();
            this.AddComputerBtn = new System.Windows.Forms.Button();
            this.ModifyComputerBtn = new System.Windows.Forms.Button();
            this.ListPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ComputersList = new System.Windows.Forms.ComboBox();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StripLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProcessesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.CpuUsageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PercentLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.RamUsageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PersentLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProcessControlPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DeleteProcessBtn = new System.Windows.Forms.Button();
            this.AddProcessBtn = new System.Windows.Forms.Button();
            this.ModifyProcessBtn = new System.Windows.Forms.Button();
            this.ProcessesGridView = new System.Windows.Forms.DataGridView();
            this.Process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Affinity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainLayoutPanel.SuspendLayout();
            this.ComutersControlBasePanel.SuspendLayout();
            this.ComputersControlPanel.SuspendLayout();
            this.ListPanel.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.ProcessControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.ProcessesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.ColumnCount = 1;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayoutPanel.Controls.Add(this.ComutersControlBasePanel, 0, 0);
            this.MainLayoutPanel.Controls.Add(this.StatusStrip, 0, 3);
            this.MainLayoutPanel.Controls.Add(this.ProcessControlPanel, 0, 2);
            this.MainLayoutPanel.Controls.Add(this.ProcessesGridView, 0, 1);
            this.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainLayoutPanel.Name = "MainLayoutPanel";
            this.MainLayoutPanel.RowCount = 4;
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.612625F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.34433F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.07463F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.MainLayoutPanel.Size = new System.Drawing.Size(1008, 729);
            this.MainLayoutPanel.TabIndex = 0;
            // 
            // ComutersControlBasePanel
            // 
            this.ComutersControlBasePanel.ColumnCount = 3;
            this.ComutersControlBasePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ComutersControlBasePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.72255F));
            this.ComutersControlBasePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.31736F));
            this.ComutersControlBasePanel.Controls.Add(this.ComputersLabel, 0, 0);
            this.ComutersControlBasePanel.Controls.Add(this.ComputersControlPanel, 2, 0);
            this.ComutersControlBasePanel.Controls.Add(this.ListPanel, 1, 0);
            this.ComutersControlBasePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComutersControlBasePanel.Location = new System.Drawing.Point(3, 3);
            this.ComutersControlBasePanel.Name = "ComutersControlBasePanel";
            this.ComutersControlBasePanel.RowCount = 1;
            this.ComutersControlBasePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ComutersControlBasePanel.Size = new System.Drawing.Size(1002, 61);
            this.ComutersControlBasePanel.TabIndex = 6;
            // 
            // ComputersLabel
            // 
            this.ComputersLabel.AutoSize = true;
            this.ComputersLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComputersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ComputersLabel.Location = new System.Drawing.Point(3, 0);
            this.ComputersLabel.Name = "ComputersLabel";
            this.ComputersLabel.Size = new System.Drawing.Size(194, 61);
            this.ComputersLabel.TabIndex = 0;
            this.ComputersLabel.Text = "Computers";
            this.ComputersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComputersControlPanel
            // 
            this.ComputersControlPanel.ColumnCount = 3;
            this.ComputersControlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ComputersControlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ComputersControlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ComputersControlPanel.Controls.Add(this.DeleteComputerBtn, 0, 0);
            this.ComputersControlPanel.Controls.Add(this.AddComputerBtn, 0, 0);
            this.ComputersControlPanel.Controls.Add(this.ModifyComputerBtn, 0, 0);
            this.ComputersControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComputersControlPanel.Location = new System.Drawing.Point(590, 3);
            this.ComputersControlPanel.Name = "ComputersControlPanel";
            this.ComputersControlPanel.RowCount = 1;
            this.ComputersControlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ComputersControlPanel.Size = new System.Drawing.Size(409, 55);
            this.ComputersControlPanel.TabIndex = 1;
            // 
            // DeleteComputerBtn
            // 
            this.DeleteComputerBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteComputerBtn.Location = new System.Drawing.Point(276, 5);
            this.DeleteComputerBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeleteComputerBtn.Name = "DeleteComputerBtn";
            this.DeleteComputerBtn.Size = new System.Drawing.Size(129, 45);
            this.DeleteComputerBtn.TabIndex = 5;
            this.DeleteComputerBtn.Text = "Delete";
            this.DeleteComputerBtn.UseVisualStyleBackColor = true;
            this.DeleteComputerBtn.Click += new System.EventHandler(this.DeleteComputerBtn_Click);
            // 
            // AddComputerBtn
            // 
            this.AddComputerBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddComputerBtn.Location = new System.Drawing.Point(140, 5);
            this.AddComputerBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddComputerBtn.Name = "AddComputerBtn";
            this.AddComputerBtn.Size = new System.Drawing.Size(128, 45);
            this.AddComputerBtn.TabIndex = 4;
            this.AddComputerBtn.Text = "Add new";
            this.AddComputerBtn.UseVisualStyleBackColor = true;
            this.AddComputerBtn.Click += new System.EventHandler(this.AddComputerBtn_Click);
            // 
            // ModifyComputerBtn
            // 
            this.ModifyComputerBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifyComputerBtn.Location = new System.Drawing.Point(4, 5);
            this.ModifyComputerBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ModifyComputerBtn.Name = "ModifyComputerBtn";
            this.ModifyComputerBtn.Size = new System.Drawing.Size(128, 45);
            this.ModifyComputerBtn.TabIndex = 6;
            this.ModifyComputerBtn.Text = "Modify";
            this.ModifyComputerBtn.UseVisualStyleBackColor = true;
            // 
            // ListPanel
            // 
            this.ListPanel.ColumnCount = 1;
            this.ListPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ListPanel.Controls.Add(this.ComputersList, 0, 1);
            this.ListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListPanel.Location = new System.Drawing.Point(203, 3);
            this.ListPanel.Name = "ListPanel";
            this.ListPanel.RowCount = 3;
            this.ListPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.32653F));
            this.ListPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.38776F));
            this.ListPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.32653F));
            this.ListPanel.Size = new System.Drawing.Size(381, 55);
            this.ListPanel.TabIndex = 2;
            // 
            // ComputersList
            // 
            this.ComputersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComputersList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComputersList.FormattingEnabled = true;
            this.ComputersList.Location = new System.Drawing.Point(3, 11);
            this.ComputersList.Name = "ComputersList";
            this.ComputersList.Size = new System.Drawing.Size(375, 28);
            this.ComputersList.TabIndex = 0;
            this.ComputersList.SelectedIndexChanged += new System.EventHandler(this.ComputersList_SelectedIndexChanged);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.StripLabel1, this.ProcessesLabel, this.StripLabel2, this.CpuUsageLabel, this.PercentLabel1, this.StripLabel3, this.RamUsageLabel, this.PersentLabel2});
            this.StatusStrip.Location = new System.Drawing.Point(0, 697);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.StatusStrip.Size = new System.Drawing.Size(1008, 32);
            this.StatusStrip.TabIndex = 0;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // StripLabel1
            // 
            this.StripLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.StripLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides) (((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StripLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.StripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StripLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.StripLabel1.Name = "StripLabel1";
            this.StripLabel1.Size = new System.Drawing.Size(77, 27);
            this.StripLabel1.Text = "Processes :";
            // 
            // ProcessesLabel
            // 
            this.ProcessesLabel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ProcessesLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides) (((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ProcessesLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.ProcessesLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ProcessesLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ProcessesLabel.Name = "ProcessesLabel";
            this.ProcessesLabel.Size = new System.Drawing.Size(19, 27);
            this.ProcessesLabel.Text = "0";
            // 
            // StripLabel2
            // 
            this.StripLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.StripLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides) (((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StripLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.StripLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.StripLabel2.Name = "StripLabel2";
            this.StripLabel2.Size = new System.Drawing.Size(82, 27);
            this.StripLabel2.Text = "CPU usage :";
            // 
            // CpuUsageLabel
            // 
            this.CpuUsageLabel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CpuUsageLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides) ((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.CpuUsageLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.CpuUsageLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.CpuUsageLabel.Name = "CpuUsageLabel";
            this.CpuUsageLabel.Size = new System.Drawing.Size(19, 27);
            this.CpuUsageLabel.Text = "0";
            // 
            // PercentLabel1
            // 
            this.PercentLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PercentLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides) (((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.PercentLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.PercentLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.PercentLabel1.Name = "PercentLabel1";
            this.PercentLabel1.Size = new System.Drawing.Size(23, 27);
            this.PercentLabel1.Text = "%";
            // 
            // StripLabel3
            // 
            this.StripLabel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.StripLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides) (((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StripLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.StripLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.StripLabel3.Name = "StripLabel3";
            this.StripLabel3.Size = new System.Drawing.Size(86, 27);
            this.StripLabel3.Text = "RAM usage :";
            // 
            // RamUsageLabel
            // 
            this.RamUsageLabel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RamUsageLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides) ((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.RamUsageLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.RamUsageLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.RamUsageLabel.Name = "RamUsageLabel";
            this.RamUsageLabel.Size = new System.Drawing.Size(19, 27);
            this.RamUsageLabel.Text = "0";
            // 
            // PersentLabel2
            // 
            this.PersentLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PersentLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides) (((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.PersentLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.PersentLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.PersentLabel2.Name = "PersentLabel2";
            this.PersentLabel2.Size = new System.Drawing.Size(23, 27);
            this.PersentLabel2.Text = "%";
            // 
            // ProcessControlPanel
            // 
            this.ProcessControlPanel.ColumnCount = 4;
            this.ProcessControlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ProcessControlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ProcessControlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ProcessControlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ProcessControlPanel.Controls.Add(this.DeleteProcessBtn, 1, 0);
            this.ProcessControlPanel.Controls.Add(this.AddProcessBtn, 0, 0);
            this.ProcessControlPanel.Controls.Add(this.ModifyProcessBtn, 3, 0);
            this.ProcessControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessControlPanel.Location = new System.Drawing.Point(4, 632);
            this.ProcessControlPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ProcessControlPanel.Name = "ProcessControlPanel";
            this.ProcessControlPanel.RowCount = 1;
            this.ProcessControlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProcessControlPanel.Size = new System.Drawing.Size(1000, 60);
            this.ProcessControlPanel.TabIndex = 2;
            // 
            // DeleteProcessBtn
            // 
            this.DeleteProcessBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteProcessBtn.Location = new System.Drawing.Point(254, 5);
            this.DeleteProcessBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeleteProcessBtn.Name = "DeleteProcessBtn";
            this.DeleteProcessBtn.Size = new System.Drawing.Size(242, 50);
            this.DeleteProcessBtn.TabIndex = 2;
            this.DeleteProcessBtn.Text = "Delete process";
            this.DeleteProcessBtn.UseVisualStyleBackColor = true;
            this.DeleteProcessBtn.Click += new System.EventHandler(this.DeleteProcessBtn_Click);
            // 
            // AddProcessBtn
            // 
            this.AddProcessBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddProcessBtn.Location = new System.Drawing.Point(4, 5);
            this.AddProcessBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddProcessBtn.Name = "AddProcessBtn";
            this.AddProcessBtn.Size = new System.Drawing.Size(242, 50);
            this.AddProcessBtn.TabIndex = 1;
            this.AddProcessBtn.Text = "Add process";
            this.AddProcessBtn.UseVisualStyleBackColor = true;
            this.AddProcessBtn.Click += new System.EventHandler(this.AddProcessBtn_Click);
            // 
            // ModifyProcessBtn
            // 
            this.ModifyProcessBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifyProcessBtn.Location = new System.Drawing.Point(754, 5);
            this.ModifyProcessBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ModifyProcessBtn.Name = "ModifyProcessBtn";
            this.ModifyProcessBtn.Size = new System.Drawing.Size(242, 50);
            this.ModifyProcessBtn.TabIndex = 3;
            this.ModifyProcessBtn.Text = "Modify process";
            this.ModifyProcessBtn.UseVisualStyleBackColor = true;
            this.ModifyProcessBtn.Click += new System.EventHandler(this.ModifyProcessBtn_Click);
            // 
            // ProcessesGridView
            // 
            this.ProcessesGridView.AllowUserToAddRows = false;
            this.ProcessesGridView.AllowUserToOrderColumns = true;
            this.ProcessesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.Process, this.PID, this.Priority, this.Affinity, this.RAM, this.Path});
            this.ProcessesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessesGridView.Location = new System.Drawing.Point(3, 70);
            this.ProcessesGridView.Name = "ProcessesGridView";
            this.ProcessesGridView.ReadOnly = true;
            this.ProcessesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProcessesGridView.Size = new System.Drawing.Size(1002, 554);
            this.ProcessesGridView.TabIndex = 5;
            this.ProcessesGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ProcessesGridView_MouseDoubleClick);
            // 
            // Process
            // 
            this.Process.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Process.HeaderText = "Process";
            this.Process.Name = "Process";
            this.Process.ReadOnly = true;
            // 
            // PID
            // 
            this.PID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PID.HeaderText = "PID";
            this.PID.Name = "PID";
            this.PID.ReadOnly = true;
            // 
            // Priority
            // 
            this.Priority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            // 
            // Affinity
            // 
            this.Affinity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Affinity.HeaderText = "Affinity";
            this.Affinity.Name = "Affinity";
            this.Affinity.ReadOnly = true;
            // 
            // RAM
            // 
            this.RAM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RAM.HeaderText = "RAM usage";
            this.RAM.Name = "RAM";
            this.RAM.ReadOnly = true;
            // 
            // Path
            // 
            this.Path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Path.HeaderText = "Path";
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.MainLayoutPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 650);
            this.Name = "MainWindow";
            this.Text = "Task Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.MainLayoutPanel.ResumeLayout(false);
            this.MainLayoutPanel.PerformLayout();
            this.ComutersControlBasePanel.ResumeLayout(false);
            this.ComutersControlBasePanel.PerformLayout();
            this.ComputersControlPanel.ResumeLayout(false);
            this.ListPanel.ResumeLayout(false);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ProcessControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.ProcessesGridView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayoutPanel;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.TableLayoutPanel ProcessControlPanel;
        private System.Windows.Forms.Button DeleteProcessBtn;
        private System.Windows.Forms.Button AddProcessBtn;
        private System.Windows.Forms.Button ModifyProcessBtn;
        private System.Windows.Forms.DataGridView ProcessesGridView;
        private System.Windows.Forms.ToolStripStatusLabel StripLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ProcessesLabel;
        private System.Windows.Forms.ToolStripStatusLabel StripLabel2;
        private System.Windows.Forms.ToolStripStatusLabel CpuUsageLabel;
        private System.Windows.Forms.ToolStripStatusLabel PercentLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StripLabel3;
        private System.Windows.Forms.ToolStripStatusLabel RamUsageLabel;
        private System.Windows.Forms.ToolStripStatusLabel PersentLabel2;
        private System.Windows.Forms.TableLayoutPanel ComutersControlBasePanel;
        private System.Windows.Forms.Label ComputersLabel;
        private System.Windows.Forms.TableLayoutPanel ComputersControlPanel;
        private System.Windows.Forms.Button DeleteComputerBtn;
        private System.Windows.Forms.Button AddComputerBtn;
        private System.Windows.Forms.Button ModifyComputerBtn;
        private System.Windows.Forms.TableLayoutPanel ListPanel;
        private System.Windows.Forms.ComboBox ComputersList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Process;
        private System.Windows.Forms.DataGridViewTextBoxColumn PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Affinity;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
    }
}

