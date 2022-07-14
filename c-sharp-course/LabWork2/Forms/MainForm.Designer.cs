namespace LabWork2.Forms
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PortInfoBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.NameLabelValue = new System.Windows.Forms.Label();
            this.AddressLabelValue = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ConfigBtn = new System.Windows.Forms.Button();
            this.CreatePort = new System.Windows.Forms.Button();
            this.CopyPort = new System.Windows.Forms.Button();
            this.DeletePortBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.FunctioningDocksLabelValue = new System.Windows.Forms.Label();
            this.ServicePriceLabelValue = new System.Windows.Forms.Label();
            this.ServiceTimeLabelValue = new System.Windows.Forms.Label();
            this.ServicePriceLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FireWorkersBtn = new System.Windows.Forms.Button();
            this.ServiceTimeLabel = new System.Windows.Forms.Label();
            this.WorkersLabel = new System.Windows.Forms.Label();
            this.EqPriceValue = new System.Windows.Forms.Label();
            this.HireWorkerBtn = new System.Windows.Forms.Button();
            this.EquipmentPriceLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DocksLabelValue = new System.Windows.Forms.Label();
            this.EquipmentLabel = new System.Windows.Forms.Label();
            this.EqNumberLabelValue = new System.Windows.Forms.Label();
            this.WorkersLabelValue = new System.Windows.Forms.Label();
            this.IncBtn = new System.Windows.Forms.Button();
            this.DecBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PortsList = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.IncomeTextBox = new System.Windows.Forms.TextBox();
            this.TimeTextBox = new System.Windows.Forms.TextBox();
            this.CalcIncomeBtn = new System.Windows.Forms.Button();
            this.CalcTimeBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CmpPortsBtn = new System.Windows.Forms.Button();
            this.DocksView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.PortInfoBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DocksView)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // PortInfoBox
            // 
            this.PortInfoBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PortInfoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PortInfoBox.Controls.Add(this.tableLayoutPanel3);
            this.PortInfoBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.PortInfoBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PortInfoBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PortInfoBox.Location = new System.Drawing.Point(4, 77);
            this.PortInfoBox.Margin = new System.Windows.Forms.Padding(4);
            this.PortInfoBox.Name = "PortInfoBox";
            this.PortInfoBox.Padding = new System.Windows.Forms.Padding(4);
            this.PortInfoBox.Size = new System.Drawing.Size(465, 109);
            this.PortInfoBox.TabIndex = 1;
            this.PortInfoBox.TabStop = false;
            this.PortInfoBox.Text = "Port Info";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ConfigBtn, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 26);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(457, 79);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.31461F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.68539F));
            this.tableLayoutPanel2.Controls.Add(this.AddressLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.NameLabelValue, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.AddressLabelValue, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.NameLabel, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(222, 73);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddressLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddressLabel.Location = new System.Drawing.Point(4, 0);
            this.AddressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(99, 36);
            this.AddressLabel.TabIndex = 1;
            this.AddressLabel.Text = "Address  ";
            this.AddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NameLabelValue
            // 
            this.NameLabelValue.AutoSize = true;
            this.NameLabelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabelValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameLabelValue.Location = new System.Drawing.Point(111, 36);
            this.NameLabelValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLabelValue.Name = "NameLabelValue";
            this.NameLabelValue.Size = new System.Drawing.Size(107, 37);
            this.NameLabelValue.TabIndex = 2;
            this.NameLabelValue.Text = ". . . ";
            this.NameLabelValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddressLabelValue
            // 
            this.AddressLabelValue.AutoSize = true;
            this.AddressLabelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddressLabelValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddressLabelValue.Location = new System.Drawing.Point(111, 0);
            this.AddressLabelValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddressLabelValue.Name = "AddressLabelValue";
            this.AddressLabelValue.Size = new System.Drawing.Size(107, 36);
            this.AddressLabelValue.TabIndex = 3;
            this.AddressLabelValue.Text = ". . .";
            this.AddressLabelValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameLabel.Location = new System.Drawing.Point(4, 36);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(99, 37);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name  ";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConfigBtn
            // 
            this.ConfigBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ConfigBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigBtn.Location = new System.Drawing.Point(231, 3);
            this.ConfigBtn.Name = "ConfigBtn";
            this.ConfigBtn.Size = new System.Drawing.Size(223, 73);
            this.ConfigBtn.TabIndex = 12;
            this.ConfigBtn.Text = "Config";
            this.ConfigBtn.UseVisualStyleBackColor = false;
            this.ConfigBtn.Click += new System.EventHandler(this.ConfigBtn_Click);
            // 
            // CreatePort
            // 
            this.CreatePort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreatePort.Location = new System.Drawing.Point(3, 3);
            this.CreatePort.Name = "CreatePort";
            this.CreatePort.Size = new System.Drawing.Size(115, 63);
            this.CreatePort.TabIndex = 3;
            this.CreatePort.Text = "Create New";
            this.CreatePort.UseVisualStyleBackColor = true;
            this.CreatePort.Click += new System.EventHandler(this.CreatePort_Click);
            // 
            // CopyPort
            // 
            this.CopyPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CopyPort.Location = new System.Drawing.Point(162, 3);
            this.CopyPort.Name = "CopyPort";
            this.CopyPort.Size = new System.Drawing.Size(130, 63);
            this.CopyPort.TabIndex = 4;
            this.CopyPort.Text = "Copy Selected";
            this.CopyPort.UseVisualStyleBackColor = true;
            this.CopyPort.Click += new System.EventHandler(this.CopyPort_Click);
            // 
            // DeletePortBtn
            // 
            this.DeletePortBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeletePortBtn.Location = new System.Drawing.Point(298, 3);
            this.DeletePortBtn.Name = "DeletePortBtn";
            this.DeletePortBtn.Size = new System.Drawing.Size(132, 63);
            this.DeletePortBtn.TabIndex = 5;
            this.DeletePortBtn.Text = "Delete Selected";
            this.DeletePortBtn.UseVisualStyleBackColor = true;
            this.DeletePortBtn.Click += new System.EventHandler(this.DeletePortBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.tableLayoutPanel4);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(4, 194);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(465, 316);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port properties";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.FunctioningDocksLabelValue, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.ServicePriceLabelValue, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.ServiceTimeLabelValue, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.ServicePriceLabel, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.FireWorkersBtn, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.ServiceTimeLabel, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.WorkersLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.EqPriceValue, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.HireWorkerBtn, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.EquipmentPriceLabel, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.DocksLabelValue, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.EquipmentLabel, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.EqNumberLabelValue, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.WorkersLabelValue, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.IncBtn, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.DecBtn, 3, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 26);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 7;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(457, 286);
            this.tableLayoutPanel4.TabIndex = 23;
            // 
            // FunctioningDocksLabelValue
            // 
            this.FunctioningDocksLabelValue.AutoSize = true;
            this.FunctioningDocksLabelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FunctioningDocksLabelValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FunctioningDocksLabelValue.Location = new System.Drawing.Point(143, 80);
            this.FunctioningDocksLabelValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FunctioningDocksLabelValue.Name = "FunctioningDocksLabelValue";
            this.FunctioningDocksLabelValue.Size = new System.Drawing.Size(31, 40);
            this.FunctioningDocksLabelValue.TabIndex = 14;
            this.FunctioningDocksLabelValue.Text = ". . . ";
            this.FunctioningDocksLabelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServicePriceLabelValue
            // 
            this.ServicePriceLabelValue.AutoSize = true;
            this.ServicePriceLabelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServicePriceLabelValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ServicePriceLabelValue.Location = new System.Drawing.Point(143, 240);
            this.ServicePriceLabelValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServicePriceLabelValue.Name = "ServicePriceLabelValue";
            this.ServicePriceLabelValue.Size = new System.Drawing.Size(31, 46);
            this.ServicePriceLabelValue.TabIndex = 8;
            this.ServicePriceLabelValue.Text = ". . . ";
            this.ServicePriceLabelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServiceTimeLabelValue
            // 
            this.ServiceTimeLabelValue.AutoSize = true;
            this.ServiceTimeLabelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServiceTimeLabelValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ServiceTimeLabelValue.Location = new System.Drawing.Point(143, 200);
            this.ServiceTimeLabelValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServiceTimeLabelValue.Name = "ServiceTimeLabelValue";
            this.ServiceTimeLabelValue.Size = new System.Drawing.Size(31, 40);
            this.ServiceTimeLabelValue.TabIndex = 10;
            this.ServiceTimeLabelValue.Text = ". . . ";
            this.ServiceTimeLabelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServicePriceLabel
            // 
            this.ServicePriceLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ServicePriceLabel.AutoSize = true;
            this.ServicePriceLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ServicePriceLabel.Location = new System.Drawing.Point(11, 242);
            this.ServicePriceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServicePriceLabel.Name = "ServicePriceLabel";
            this.ServicePriceLabel.Size = new System.Drawing.Size(124, 42);
            this.ServicePriceLabel.TabIndex = 9;
            this.ServicePriceLabel.Text = "Service price (in EUR)";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(39, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 40);
            this.label1.TabIndex = 13;
            this.label1.Text = "Functioning docks";
            // 
            // FireWorkersBtn
            // 
            this.FireWorkersBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FireWorkersBtn.Location = new System.Drawing.Point(320, 3);
            this.FireWorkersBtn.Name = "FireWorkersBtn";
            this.FireWorkersBtn.Size = new System.Drawing.Size(134, 34);
            this.FireWorkersBtn.TabIndex = 4;
            this.FireWorkersBtn.Text = "Fire";
            this.FireWorkersBtn.UseVisualStyleBackColor = true;
            this.FireWorkersBtn.Click += new System.EventHandler(this.FireWorkersBtn_Click);
            // 
            // ServiceTimeLabel
            // 
            this.ServiceTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ServiceTimeLabel.AutoSize = true;
            this.ServiceTimeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ServiceTimeLabel.Location = new System.Drawing.Point(14, 200);
            this.ServiceTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServiceTimeLabel.Name = "ServiceTimeLabel";
            this.ServiceTimeLabel.Size = new System.Drawing.Size(121, 40);
            this.ServiceTimeLabel.TabIndex = 7;
            this.ServiceTimeLabel.Text = "Service time (in days)";
            // 
            // WorkersLabel
            // 
            this.WorkersLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.WorkersLabel.AutoSize = true;
            this.WorkersLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WorkersLabel.Location = new System.Drawing.Point(67, 11);
            this.WorkersLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.WorkersLabel.Name = "WorkersLabel";
            this.WorkersLabel.Size = new System.Drawing.Size(68, 21);
            this.WorkersLabel.TabIndex = 1;
            this.WorkersLabel.Text = "Workers";
            // 
            // EqPriceValue
            // 
            this.EqPriceValue.AutoSize = true;
            this.EqPriceValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EqPriceValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EqPriceValue.Location = new System.Drawing.Point(143, 160);
            this.EqPriceValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EqPriceValue.Name = "EqPriceValue";
            this.EqPriceValue.Size = new System.Drawing.Size(31, 40);
            this.EqPriceValue.TabIndex = 6;
            this.EqPriceValue.Text = ". . . ";
            this.EqPriceValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HireWorkerBtn
            // 
            this.HireWorkerBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HireWorkerBtn.Location = new System.Drawing.Point(181, 3);
            this.HireWorkerBtn.Name = "HireWorkerBtn";
            this.HireWorkerBtn.Size = new System.Drawing.Size(133, 34);
            this.HireWorkerBtn.TabIndex = 5;
            this.HireWorkerBtn.Text = "Hire";
            this.HireWorkerBtn.UseVisualStyleBackColor = true;
            this.HireWorkerBtn.Click += new System.EventHandler(this.HireWorkerBtn_Click);
            // 
            // EquipmentPriceLabel
            // 
            this.EquipmentPriceLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.EquipmentPriceLabel.AutoSize = true;
            this.EquipmentPriceLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EquipmentPriceLabel.Location = new System.Drawing.Point(12, 169);
            this.EquipmentPriceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EquipmentPriceLabel.Name = "EquipmentPriceLabel";
            this.EquipmentPriceLabel.Size = new System.Drawing.Size(123, 21);
            this.EquipmentPriceLabel.TabIndex = 5;
            this.EquipmentPriceLabel.Text = "Equipment price";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(83, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Docks";
            // 
            // DocksLabelValue
            // 
            this.DocksLabelValue.AutoSize = true;
            this.DocksLabelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocksLabelValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DocksLabelValue.Location = new System.Drawing.Point(139, 45);
            this.DocksLabelValue.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.DocksLabelValue.Name = "DocksLabelValue";
            this.DocksLabelValue.Size = new System.Drawing.Size(39, 35);
            this.DocksLabelValue.TabIndex = 3;
            this.DocksLabelValue.Text = ". . .";
            this.DocksLabelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EquipmentLabel
            // 
            this.EquipmentLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.EquipmentLabel.AutoSize = true;
            this.EquipmentLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EquipmentLabel.Location = new System.Drawing.Point(46, 120);
            this.EquipmentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EquipmentLabel.Name = "EquipmentLabel";
            this.EquipmentLabel.Size = new System.Drawing.Size(89, 40);
            this.EquipmentLabel.TabIndex = 0;
            this.EquipmentLabel.Text = "Equipment number";
            // 
            // EqNumberLabelValue
            // 
            this.EqNumberLabelValue.AutoSize = true;
            this.EqNumberLabelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EqNumberLabelValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EqNumberLabelValue.Location = new System.Drawing.Point(143, 120);
            this.EqNumberLabelValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EqNumberLabelValue.Name = "EqNumberLabelValue";
            this.EqNumberLabelValue.Size = new System.Drawing.Size(31, 40);
            this.EqNumberLabelValue.TabIndex = 2;
            this.EqNumberLabelValue.Text = ". . . ";
            this.EqNumberLabelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WorkersLabelValue
            // 
            this.WorkersLabelValue.AutoSize = true;
            this.WorkersLabelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkersLabelValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WorkersLabelValue.Location = new System.Drawing.Point(139, 5);
            this.WorkersLabelValue.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.WorkersLabelValue.Name = "WorkersLabelValue";
            this.WorkersLabelValue.Size = new System.Drawing.Size(39, 35);
            this.WorkersLabelValue.TabIndex = 3;
            this.WorkersLabelValue.Text = ". . .";
            this.WorkersLabelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IncBtn
            // 
            this.IncBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IncBtn.Location = new System.Drawing.Point(181, 43);
            this.IncBtn.Name = "IncBtn";
            this.IncBtn.Size = new System.Drawing.Size(133, 34);
            this.IncBtn.TabIndex = 4;
            this.IncBtn.Text = "Inc";
            this.IncBtn.UseVisualStyleBackColor = true;
            this.IncBtn.Click += new System.EventHandler(this.IncBtn_Click);
            // 
            // DecBtn
            // 
            this.DecBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DecBtn.Location = new System.Drawing.Point(320, 43);
            this.DecBtn.Name = "DecBtn";
            this.DecBtn.Size = new System.Drawing.Size(134, 34);
            this.DecBtn.TabIndex = 5;
            this.DecBtn.Text = "Dec";
            this.DecBtn.UseVisualStyleBackColor = true;
            this.DecBtn.Click += new System.EventHandler(this.DecBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanel1.Controls.Add(this.CreatePort, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DeletePortBtn, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.CopyPort, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 519);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(433, 69);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // PortsList
            // 
            this.PortsList.AllowDrop = true;
            this.PortsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PortsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortsList.Location = new System.Drawing.Point(50, 36);
            this.PortsList.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.PortsList.Name = "PortsList";
            this.PortsList.Size = new System.Drawing.Size(367, 29);
            this.PortsList.TabIndex = 8;
            this.PortsList.SelectedIndexChanged += new System.EventHandler(this.PortsList_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Liberation Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(241, 31);
            this.label7.TabIndex = 12;
            this.label7.Text = "Calc service time";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IncomeTextBox
            // 
            this.IncomeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IncomeTextBox.Location = new System.Drawing.Point(15, 71);
            this.IncomeTextBox.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.IncomeTextBox.Name = "IncomeTextBox";
            this.IncomeTextBox.Size = new System.Drawing.Size(217, 29);
            this.IncomeTextBox.TabIndex = 13;
            // 
            // TimeTextBox
            // 
            this.TimeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeTextBox.Location = new System.Drawing.Point(15, 65);
            this.TimeTextBox.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.TimeTextBox.Name = "TimeTextBox";
            this.TimeTextBox.Size = new System.Drawing.Size(217, 29);
            this.TimeTextBox.TabIndex = 14;
            // 
            // CalcIncomeBtn
            // 
            this.CalcIncomeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalcIncomeBtn.Location = new System.Drawing.Point(30, 105);
            this.CalcIncomeBtn.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.CalcIncomeBtn.Name = "CalcIncomeBtn";
            this.CalcIncomeBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.CalcIncomeBtn.Size = new System.Drawing.Size(187, 31);
            this.CalcIncomeBtn.TabIndex = 15;
            this.CalcIncomeBtn.Text = "Get result";
            this.CalcIncomeBtn.UseVisualStyleBackColor = true;
            this.CalcIncomeBtn.Click += new System.EventHandler(this.CalcIncomeBtn_Click);
            // 
            // CalcTimeBtn
            // 
            this.CalcTimeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalcTimeBtn.Location = new System.Drawing.Point(30, 96);
            this.CalcTimeBtn.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.CalcTimeBtn.Name = "CalcTimeBtn";
            this.CalcTimeBtn.Size = new System.Drawing.Size(187, 28);
            this.CalcTimeBtn.TabIndex = 16;
            this.CalcTimeBtn.Text = "Get result";
            this.CalcTimeBtn.UseVisualStyleBackColor = true;
            this.CalcTimeBtn.Click += new System.EventHandler(this.CalcTimeBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(3, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(241, 34);
            this.label8.TabIndex = 17;
            this.label8.Text = "Enter number of ships";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(241, 31);
            this.label9.TabIndex = 18;
            this.label9.Text = "Enter number of ships";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // CmpPortsBtn
            // 
            this.CmpPortsBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.CmpPortsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmpPortsBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CmpPortsBtn.Location = new System.Drawing.Point(10, 393);
            this.CmpPortsBtn.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.CmpPortsBtn.Name = "CmpPortsBtn";
            this.CmpPortsBtn.Size = new System.Drawing.Size(233, 87);
            this.CmpPortsBtn.TabIndex = 19;
            this.CmpPortsBtn.Text = "Compare ports";
            this.CmpPortsBtn.UseVisualStyleBackColor = false;
            this.CmpPortsBtn.Click += new System.EventHandler(this.CmpPortsBtn_Click);
            // 
            // DocksView
            // 
            this.DocksView.AllowUserToAddRows = false;
            this.DocksView.AllowUserToDeleteRows = false;
            this.DocksView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DocksView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.State});
            this.DocksView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocksView.Location = new System.Drawing.Point(3, 41);
            this.DocksView.Name = "DocksView";
            this.DocksView.ReadOnly = true;
            this.DocksView.RowTemplate.Height = 25;
            this.DocksView.Size = new System.Drawing.Size(240, 544);
            this.DocksView.TabIndex = 20;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 48;
            // 
            // State
            // 
            this.State.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.NullValue = "...";
            this.State.DefaultCellStyle = dataGridViewCellStyle1;
            this.State.FillWeight = 10F;
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Liberation Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(240, 38);
            this.label10.TabIndex = 21;
            this.label10.Text = "Docks viewer";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Liberation Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(461, 33);
            this.label2.TabIndex = 22;
            this.label2.Text = "Select Port";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.CalcIncomeBtn, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.IncomeTextBox, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(247, 139);
            this.tableLayoutPanel5.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Liberation Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 34);
            this.label4.TabIndex = 25;
            this.label4.Text = "Calc income";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.TimeTextBox, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.CalcTimeBtn, 0, 3);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 179);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(247, 127);
            this.tableLayoutPanel6.TabIndex = 24;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.CmpPortsBtn, 0, 4);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(10, 80);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(10, 80, 10, 20);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 6;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.17949F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.948718F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.10257F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.76923F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(253, 513);
            this.tableLayoutPanel7.TabIndex = 25;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.PortsList, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(467, 67);
            this.tableLayoutPanel8.TabIndex = 26;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.PortInfoBox, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(293, 10);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(20, 10, 5, 10);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 4;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.38938F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.73018F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.63744F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.09735F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(473, 593);
            this.tableLayoutPanel9.TabIndex = 27;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 3;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.40856F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.59144F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel11, 2, 0);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel9, 1, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(1028, 613);
            this.tableLayoutPanel10.TabIndex = 28;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.DocksView, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(774, 10);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(3, 10, 8, 15);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.462585F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.53741F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(246, 588);
            this.tableLayoutPanel11.TabIndex = 29;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1028, 613);
            this.Controls.Add(this.tableLayoutPanel10);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Seaport";
            this.PortInfoBox.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DocksView)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox PortInfoBox;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label AddressLabelValue;
        private System.Windows.Forms.Label NameLabelValue;
        private System.Windows.Forms.Button CreatePort;
        private System.Windows.Forms.Button CopyPort;
        private System.Windows.Forms.Button DeletePortBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label WorkersLabelValue;
        private System.Windows.Forms.Label EqNumberLabelValue;
        private System.Windows.Forms.Label WorkersLabel;
        private System.Windows.Forms.Label EquipmentLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox PortsList;
        private System.Windows.Forms.Button HireWorkerBtn;
        private System.Windows.Forms.Button FireWorkersBtn;
        private System.Windows.Forms.Label EquipmentPriceLabel;
        private System.Windows.Forms.Label ServicePriceLabel;
        private System.Windows.Forms.Label ServicePriceLabelValue;
        private System.Windows.Forms.Label ServiceTimeLabel;
        private System.Windows.Forms.Label EqPriceValue;
        private System.Windows.Forms.Label ServiceTimeLabelValue;
        private System.Windows.Forms.Button IncBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label DocksLabelValue;
        private System.Windows.Forms.Button DecBtn;
        private System.Windows.Forms.Button ConfigBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox IncomeTextBox;
        private System.Windows.Forms.TextBox TimeTextBox;
        private System.Windows.Forms.Button CalcIncomeBtn;
        private System.Windows.Forms.Button CalcTimeBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button CmpPortsBtn;
        private System.Windows.Forms.DataGridView DocksView;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FunctioningDocksLabelValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
    }
}

