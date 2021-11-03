namespace LabWork2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PortInfoBox = new System.Windows.Forms.GroupBox();
            this.AddressLabelValue = new System.Windows.Forms.Label();
            this.NameLabelValue = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.CreatePort = new System.Windows.Forms.Button();
            this.CopyPort = new System.Windows.Forms.Button();
            this.DeletePort = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sd = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.IncBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DecBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ServicePriceLabel = new System.Windows.Forms.Label();
            this.ServicePriceLabelValue = new System.Windows.Forms.Label();
            this.ServiceTimeLabel = new System.Windows.Forms.Label();
            this.EqPriceValue = new System.Windows.Forms.Label();
            this.EquipmentPriceLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FireWorkersBtn = new System.Windows.Forms.Button();
            this.WorkersLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HireWorkerBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.EquipmentLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PortsList = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.IncomeTextBox = new System.Windows.Forms.TextBox();
            this.TimeTextBox = new System.Windows.Forms.TextBox();
            this.CalcIncomeBtn = new System.Windows.Forms.Button();
            this.CalcTimeBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CmpPortsBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.PortInfoBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // PortInfoBox
            // 
            this.PortInfoBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PortInfoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PortInfoBox.Controls.Add(this.AddressLabelValue);
            this.PortInfoBox.Controls.Add(this.NameLabelValue);
            this.PortInfoBox.Controls.Add(this.AddressLabel);
            this.PortInfoBox.Controls.Add(this.NameLabel);
            this.PortInfoBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PortInfoBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PortInfoBox.Location = new System.Drawing.Point(359, 31);
            this.PortInfoBox.Margin = new System.Windows.Forms.Padding(4);
            this.PortInfoBox.Name = "PortInfoBox";
            this.PortInfoBox.Padding = new System.Windows.Forms.Padding(4);
            this.PortInfoBox.Size = new System.Drawing.Size(445, 126);
            this.PortInfoBox.TabIndex = 1;
            this.PortInfoBox.TabStop = false;
            this.PortInfoBox.Text = "Port Info";
            // 
            // AddressLabelValue
            // 
            this.AddressLabelValue.AutoSize = true;
            this.AddressLabelValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddressLabelValue.Location = new System.Drawing.Point(131, 40);
            this.AddressLabelValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddressLabelValue.Name = "AddressLabelValue";
            this.AddressLabelValue.Size = new System.Drawing.Size(27, 21);
            this.AddressLabelValue.TabIndex = 3;
            this.AddressLabelValue.Text = ". . .";
            // 
            // NameLabelValue
            // 
            this.NameLabelValue.AutoSize = true;
            this.NameLabelValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameLabelValue.Location = new System.Drawing.Point(127, 82);
            this.NameLabelValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLabelValue.Name = "NameLabelValue";
            this.NameLabelValue.Size = new System.Drawing.Size(31, 21);
            this.NameLabelValue.TabIndex = 2;
            this.NameLabelValue.Text = ". . . ";
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddressLabel.Location = new System.Drawing.Point(35, 40);
            this.AddressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(66, 21);
            this.AddressLabel.TabIndex = 1;
            this.AddressLabel.Text = "Address";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameLabel.Location = new System.Drawing.Point(35, 82);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(52, 21);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // CreatePort
            // 
            this.CreatePort.Location = new System.Drawing.Point(3, 3);
            this.CreatePort.Name = "CreatePort";
            this.CreatePort.Size = new System.Drawing.Size(115, 32);
            this.CreatePort.TabIndex = 3;
            this.CreatePort.Text = "Create New";
            this.CreatePort.UseVisualStyleBackColor = true;
            // 
            // CopyPort
            // 
            this.CopyPort.Location = new System.Drawing.Point(162, 3);
            this.CopyPort.Name = "CopyPort";
            this.CopyPort.Size = new System.Drawing.Size(130, 32);
            this.CopyPort.TabIndex = 4;
            this.CopyPort.Text = "Copy Selected";
            this.CopyPort.UseVisualStyleBackColor = true;
            // 
            // DeletePort
            // 
            this.DeletePort.Location = new System.Drawing.Point(298, 3);
            this.DeletePort.Name = "DeletePort";
            this.DeletePort.Size = new System.Drawing.Size(130, 32);
            this.DeletePort.TabIndex = 5;
            this.DeletePort.Text = "Delete Selected";
            this.DeletePort.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.sd);
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ServicePriceLabel);
            this.groupBox1.Controls.Add(this.ServicePriceLabelValue);
            this.groupBox1.Controls.Add(this.ServiceTimeLabel);
            this.groupBox1.Controls.Add(this.EqPriceValue);
            this.groupBox1.Controls.Add(this.EquipmentPriceLabel);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.EquipmentLabel);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(359, 165);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(445, 277);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port properties";
            // 
            // sd
            // 
            this.sd.Location = new System.Drawing.Point(320, 162);
            this.sd.Name = "sd";
            this.sd.Size = new System.Drawing.Size(68, 42);
            this.sd.TabIndex = 12;
            this.sd.Text = "Config";
            this.sd.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.26829F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.73171F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel3.Controls.Add(this.IncBtn, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.DecBtn, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(15, 65);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(422, 33);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // IncBtn
            // 
            this.IncBtn.Location = new System.Drawing.Point(279, 3);
            this.IncBtn.Name = "IncBtn";
            this.IncBtn.Size = new System.Drawing.Size(113, 27);
            this.IncBtn.TabIndex = 4;
            this.IncBtn.Text = "Inc";
            this.IncBtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Docks";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(75, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = ". . .";
            // 
            // DecBtn
            // 
            this.DecBtn.Location = new System.Drawing.Point(156, 3);
            this.DecBtn.Name = "DecBtn";
            this.DecBtn.Size = new System.Drawing.Size(109, 27);
            this.DecBtn.TabIndex = 5;
            this.DecBtn.Text = "Dec";
            this.DecBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(187, 206);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = ". . . ";
            // 
            // ServicePriceLabel
            // 
            this.ServicePriceLabel.AutoSize = true;
            this.ServicePriceLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ServicePriceLabel.Location = new System.Drawing.Point(17, 240);
            this.ServicePriceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServicePriceLabel.Name = "ServicePriceLabel";
            this.ServicePriceLabel.Size = new System.Drawing.Size(98, 21);
            this.ServicePriceLabel.TabIndex = 9;
            this.ServicePriceLabel.Text = "Service price";
            // 
            // ServicePriceLabelValue
            // 
            this.ServicePriceLabelValue.AutoSize = true;
            this.ServicePriceLabelValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ServicePriceLabelValue.Location = new System.Drawing.Point(188, 240);
            this.ServicePriceLabelValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServicePriceLabelValue.Name = "ServicePriceLabelValue";
            this.ServicePriceLabelValue.Size = new System.Drawing.Size(31, 21);
            this.ServicePriceLabelValue.TabIndex = 8;
            this.ServicePriceLabelValue.Text = ". . . ";
            // 
            // ServiceTimeLabel
            // 
            this.ServiceTimeLabel.AutoSize = true;
            this.ServiceTimeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ServiceTimeLabel.Location = new System.Drawing.Point(16, 206);
            this.ServiceTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServiceTimeLabel.Name = "ServiceTimeLabel";
            this.ServiceTimeLabel.Size = new System.Drawing.Size(158, 21);
            this.ServiceTimeLabel.TabIndex = 7;
            this.ServiceTimeLabel.Text = "Service time (in days)";
            // 
            // EqPriceValue
            // 
            this.EqPriceValue.AutoSize = true;
            this.EqPriceValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EqPriceValue.Location = new System.Drawing.Point(188, 152);
            this.EqPriceValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EqPriceValue.Name = "EqPriceValue";
            this.EqPriceValue.Size = new System.Drawing.Size(31, 21);
            this.EqPriceValue.TabIndex = 6;
            this.EqPriceValue.Text = ". . . ";
            // 
            // EquipmentPriceLabel
            // 
            this.EquipmentPriceLabel.AutoSize = true;
            this.EquipmentPriceLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EquipmentPriceLabel.Location = new System.Drawing.Point(17, 152);
            this.EquipmentPriceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EquipmentPriceLabel.Name = "EquipmentPriceLabel";
            this.EquipmentPriceLabel.Size = new System.Drawing.Size(123, 21);
            this.EquipmentPriceLabel.TabIndex = 5;
            this.EquipmentPriceLabel.Text = "Equipment price";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.26829F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.73171F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel2.Controls.Add(this.FireWorkersBtn, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.WorkersLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.HireWorkerBtn, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(16, 26);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(422, 33);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // FireWorkersBtn
            // 
            this.FireWorkersBtn.Location = new System.Drawing.Point(279, 3);
            this.FireWorkersBtn.Name = "FireWorkersBtn";
            this.FireWorkersBtn.Size = new System.Drawing.Size(113, 27);
            this.FireWorkersBtn.TabIndex = 4;
            this.FireWorkersBtn.Text = "Fire";
            this.FireWorkersBtn.UseVisualStyleBackColor = true;
            // 
            // WorkersLabel
            // 
            this.WorkersLabel.AutoSize = true;
            this.WorkersLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WorkersLabel.Location = new System.Drawing.Point(4, 4);
            this.WorkersLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.WorkersLabel.Name = "WorkersLabel";
            this.WorkersLabel.Size = new System.Drawing.Size(61, 29);
            this.WorkersLabel.TabIndex = 1;
            this.WorkersLabel.Text = "Workers";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(75, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = ". . .";
            // 
            // HireWorkerBtn
            // 
            this.HireWorkerBtn.Location = new System.Drawing.Point(156, 3);
            this.HireWorkerBtn.Name = "HireWorkerBtn";
            this.HireWorkerBtn.Size = new System.Drawing.Size(109, 27);
            this.HireWorkerBtn.TabIndex = 5;
            this.HireWorkerBtn.Text = "Hire";
            this.HireWorkerBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(187, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = ". . . ";
            // 
            // EquipmentLabel
            // 
            this.EquipmentLabel.AutoSize = true;
            this.EquipmentLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EquipmentLabel.Location = new System.Drawing.Point(16, 118);
            this.EquipmentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EquipmentLabel.Name = "EquipmentLabel";
            this.EquipmentLabel.Size = new System.Drawing.Size(144, 21);
            this.EquipmentLabel.TabIndex = 0;
            this.EquipmentLabel.Text = "Equipment number";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanel1.Controls.Add(this.CreatePort, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DeletePort, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.CopyPort, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(364, 461);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(433, 45);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // PortsList
            // 
            this.PortsList.AllowDrop = true;
            this.PortsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortsList.Items.AddRange(new object[] {
            "Example seaport",
            "seaport2"});
            this.PortsList.Location = new System.Drawing.Point(423, 538);
            this.PortsList.Name = "PortsList";
            this.PortsList.Size = new System.Drawing.Size(324, 29);
            this.PortsList.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Liberation Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(99, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Calc income";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Liberation Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(84, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "Calc service time";
            // 
            // IncomeTextBox
            // 
            this.IncomeTextBox.Location = new System.Drawing.Point(84, 137);
            this.IncomeTextBox.Name = "IncomeTextBox";
            this.IncomeTextBox.Size = new System.Drawing.Size(157, 29);
            this.IncomeTextBox.TabIndex = 13;
            // 
            // TimeTextBox
            // 
            this.TimeTextBox.Location = new System.Drawing.Point(82, 314);
            this.TimeTextBox.Name = "TimeTextBox";
            this.TimeTextBox.Size = new System.Drawing.Size(157, 29);
            this.TimeTextBox.TabIndex = 14;
            // 
            // CalcIncomeBtn
            // 
            this.CalcIncomeBtn.Location = new System.Drawing.Point(107, 172);
            this.CalcIncomeBtn.Name = "CalcIncomeBtn";
            this.CalcIncomeBtn.Size = new System.Drawing.Size(109, 27);
            this.CalcIncomeBtn.TabIndex = 15;
            this.CalcIncomeBtn.Text = "Get result";
            this.CalcIncomeBtn.UseVisualStyleBackColor = true;
            // 
            // CalcTimeBtn
            // 
            this.CalcTimeBtn.Location = new System.Drawing.Point(107, 349);
            this.CalcTimeBtn.Name = "CalcTimeBtn";
            this.CalcTimeBtn.Size = new System.Drawing.Size(109, 27);
            this.CalcTimeBtn.TabIndex = 16;
            this.CalcTimeBtn.Text = "Get result";
            this.CalcTimeBtn.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 21);
            this.label8.TabIndex = 17;
            this.label8.Text = "Enter number of ships";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(84, 290);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 21);
            this.label9.TabIndex = 18;
            this.label9.Text = "Enter number of ships";
            // 
            // CmpPortsBtn
            // 
            this.CmpPortsBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CmpPortsBtn.Location = new System.Drawing.Point(73, 464);
            this.CmpPortsBtn.Name = "CmpPortsBtn";
            this.CmpPortsBtn.Size = new System.Drawing.Size(186, 81);
            this.CmpPortsBtn.TabIndex = 19;
            this.CmpPortsBtn.Text = "Compare ports";
            this.CmpPortsBtn.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.State});
            this.dataGridView1.Location = new System.Drawing.Point(828, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(160, 448);
            this.dataGridView1.TabIndex = 20;
            // 
            // State
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.NullValue = "...";
            this.State.DefaultCellStyle = dataGridViewCellStyle2;
            this.State.Frozen = true;
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.State.Width = 115;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Liberation Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(844, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 24);
            this.label10.TabIndex = 21;
            this.label10.Text = "Docks viewer";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1028, 613);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.CmpPortsBtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CalcTimeBtn);
            this.Controls.Add(this.CalcIncomeBtn);
            this.Controls.Add(this.TimeTextBox);
            this.Controls.Add(this.IncomeTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PortsList);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PortInfoBox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Seaport";
            this.PortInfoBox.ResumeLayout(false);
            this.PortInfoBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PortInfoBox;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label AddressLabelValue;
        private System.Windows.Forms.Label NameLabelValue;
        private System.Windows.Forms.Button CreatePort;
        private System.Windows.Forms.Button CopyPort;
        private System.Windows.Forms.Button DeletePort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label WorkersLabel;
        private System.Windows.Forms.Label EquipmentLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox PortsList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button HireWorkerBtn;
        private System.Windows.Forms.Button FireWorkersBtn;
        private System.Windows.Forms.Label EquipmentPriceLabel;
        private System.Windows.Forms.Label ServicePriceLabel;
        private System.Windows.Forms.Label ServicePriceLabelValue;
        private System.Windows.Forms.Label ServiceTimeLabel;
        private System.Windows.Forms.Label EqPriceValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button IncBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button DecBtn;
        private System.Windows.Forms.Button sd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox IncomeTextBox;
        private System.Windows.Forms.TextBox TimeTextBox;
        private System.Windows.Forms.Button CalcIncomeBtn;
        private System.Windows.Forms.Button CalcTimeBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button CmpPortsBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.Label label10;
    }
}

