namespace LabWork6
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
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.InfoLabelsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.CurrentStateLabel = new System.Windows.Forms.Label();
            this.CurrentStateInfoLabel = new System.Windows.Forms.Label();
            this.FreeStorageSpaceLabel = new System.Windows.Forms.Label();
            this.FreeStorageSpaceInfoLabel = new System.Windows.Forms.Label();
            this.MoneyLabel = new System.Windows.Forms.Label();
            this.MoneyInfoLabel = new System.Windows.Forms.Label();
            this.RawMaterialLabel = new System.Windows.Forms.Label();
            this.RawMaterialInfoLabel = new System.Windows.Forms.Label();
            this.ProductsLabel = new System.Windows.Forms.Label();
            this.ProductsInfoLabel = new System.Windows.Forms.Label();
            this.DepartmentsLabel = new System.Windows.Forms.Label();
            this.DepartmentsInfoLabel = new System.Windows.Forms.Label();
            this.TopCenterLayaut = new System.Windows.Forms.TableLayoutPanel();
            this.ReportsBtn = new System.Windows.Forms.Button();
            this.ControlElementsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ResumeBtn = new System.Windows.Forms.Button();
            this.SuspendBtn = new System.Windows.Forms.Button();
            this.StateComboBox = new System.Windows.Forms.ComboBox();
            this.OpenReportDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainLayout.SuspendLayout();
            this.InfoLabelsLayout.SuspendLayout();
            this.TopCenterLayaut.SuspendLayout();
            this.ControlElementsLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 3;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.11194F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.88806F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.MainLayout.Controls.Add(this.InfoLabelsLayout, 1, 1);
            this.MainLayout.Controls.Add(this.TopCenterLayaut, 1, 0);
            this.MainLayout.Controls.Add(this.ControlElementsLayout, 1, 2);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 3;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.93491F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.06509F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.MainLayout.Size = new System.Drawing.Size(800, 392);
            this.MainLayout.TabIndex = 0;
            // 
            // InfoLabelsLayout
            // 
            this.InfoLabelsLayout.ColumnCount = 2;
            this.InfoLabelsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.InfoLabelsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.InfoLabelsLayout.Controls.Add(this.CurrentStateLabel, 1, 5);
            this.InfoLabelsLayout.Controls.Add(this.CurrentStateInfoLabel, 0, 5);
            this.InfoLabelsLayout.Controls.Add(this.FreeStorageSpaceLabel, 1, 4);
            this.InfoLabelsLayout.Controls.Add(this.FreeStorageSpaceInfoLabel, 0, 4);
            this.InfoLabelsLayout.Controls.Add(this.MoneyLabel, 1, 3);
            this.InfoLabelsLayout.Controls.Add(this.MoneyInfoLabel, 0, 3);
            this.InfoLabelsLayout.Controls.Add(this.RawMaterialLabel, 1, 2);
            this.InfoLabelsLayout.Controls.Add(this.RawMaterialInfoLabel, 0, 2);
            this.InfoLabelsLayout.Controls.Add(this.ProductsLabel, 1, 1);
            this.InfoLabelsLayout.Controls.Add(this.ProductsInfoLabel, 0, 1);
            this.InfoLabelsLayout.Controls.Add(this.DepartmentsLabel, 1, 0);
            this.InfoLabelsLayout.Controls.Add(this.DepartmentsInfoLabel, 0, 0);
            this.InfoLabelsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoLabelsLayout.Location = new System.Drawing.Point(107, 67);
            this.InfoLabelsLayout.Name = "InfoLabelsLayout";
            this.InfoLabelsLayout.RowCount = 6;
            this.InfoLabelsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.InfoLabelsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.InfoLabelsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.InfoLabelsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.InfoLabelsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.InfoLabelsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.InfoLabelsLayout.Size = new System.Drawing.Size(579, 268);
            this.InfoLabelsLayout.TabIndex = 0;
            // 
            // CurrentStateLabel
            // 
            this.CurrentStateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentStateLabel.Location = new System.Drawing.Point(292, 220);
            this.CurrentStateLabel.Name = "CurrentStateLabel";
            this.CurrentStateLabel.Size = new System.Drawing.Size(284, 48);
            this.CurrentStateLabel.TabIndex = 11;
            this.CurrentStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentStateInfoLabel
            // 
            this.CurrentStateInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentStateInfoLabel.Location = new System.Drawing.Point(3, 220);
            this.CurrentStateInfoLabel.Name = "CurrentStateInfoLabel";
            this.CurrentStateInfoLabel.Size = new System.Drawing.Size(283, 48);
            this.CurrentStateInfoLabel.TabIndex = 10;
            this.CurrentStateInfoLabel.Text = "CurrentState";
            this.CurrentStateInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FreeStorageSpaceLabel
            // 
            this.FreeStorageSpaceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FreeStorageSpaceLabel.Location = new System.Drawing.Point(292, 176);
            this.FreeStorageSpaceLabel.Name = "FreeStorageSpaceLabel";
            this.FreeStorageSpaceLabel.Size = new System.Drawing.Size(284, 44);
            this.FreeStorageSpaceLabel.TabIndex = 9;
            this.FreeStorageSpaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FreeStorageSpaceInfoLabel
            // 
            this.FreeStorageSpaceInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FreeStorageSpaceInfoLabel.Location = new System.Drawing.Point(3, 176);
            this.FreeStorageSpaceInfoLabel.Name = "FreeStorageSpaceInfoLabel";
            this.FreeStorageSpaceInfoLabel.Size = new System.Drawing.Size(283, 44);
            this.FreeStorageSpaceInfoLabel.TabIndex = 8;
            this.FreeStorageSpaceInfoLabel.Text = "FreeStorageSpace";
            this.FreeStorageSpaceInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MoneyLabel
            // 
            this.MoneyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MoneyLabel.Location = new System.Drawing.Point(292, 132);
            this.MoneyLabel.Name = "MoneyLabel";
            this.MoneyLabel.Size = new System.Drawing.Size(284, 44);
            this.MoneyLabel.TabIndex = 7;
            this.MoneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MoneyInfoLabel
            // 
            this.MoneyInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MoneyInfoLabel.Location = new System.Drawing.Point(3, 132);
            this.MoneyInfoLabel.Name = "MoneyInfoLabel";
            this.MoneyInfoLabel.Size = new System.Drawing.Size(283, 44);
            this.MoneyInfoLabel.TabIndex = 6;
            this.MoneyInfoLabel.Text = "Money";
            this.MoneyInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RawMaterialLabel
            // 
            this.RawMaterialLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RawMaterialLabel.Location = new System.Drawing.Point(292, 88);
            this.RawMaterialLabel.Name = "RawMaterialLabel";
            this.RawMaterialLabel.Size = new System.Drawing.Size(284, 44);
            this.RawMaterialLabel.TabIndex = 5;
            this.RawMaterialLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RawMaterialInfoLabel
            // 
            this.RawMaterialInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RawMaterialInfoLabel.Location = new System.Drawing.Point(3, 88);
            this.RawMaterialInfoLabel.Name = "RawMaterialInfoLabel";
            this.RawMaterialInfoLabel.Size = new System.Drawing.Size(283, 44);
            this.RawMaterialInfoLabel.TabIndex = 4;
            this.RawMaterialInfoLabel.Text = "RawMaterial";
            this.RawMaterialInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ProductsLabel
            // 
            this.ProductsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductsLabel.Location = new System.Drawing.Point(292, 44);
            this.ProductsLabel.Name = "ProductsLabel";
            this.ProductsLabel.Size = new System.Drawing.Size(284, 44);
            this.ProductsLabel.TabIndex = 3;
            this.ProductsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProductsInfoLabel
            // 
            this.ProductsInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductsInfoLabel.Location = new System.Drawing.Point(3, 44);
            this.ProductsInfoLabel.Name = "ProductsInfoLabel";
            this.ProductsInfoLabel.Size = new System.Drawing.Size(283, 44);
            this.ProductsInfoLabel.TabIndex = 2;
            this.ProductsInfoLabel.Text = "Products";
            this.ProductsInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DepartmentsLabel
            // 
            this.DepartmentsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DepartmentsLabel.Location = new System.Drawing.Point(292, 0);
            this.DepartmentsLabel.Name = "DepartmentsLabel";
            this.DepartmentsLabel.Size = new System.Drawing.Size(284, 44);
            this.DepartmentsLabel.TabIndex = 1;
            this.DepartmentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DepartmentsInfoLabel
            // 
            this.DepartmentsInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DepartmentsInfoLabel.Location = new System.Drawing.Point(3, 0);
            this.DepartmentsInfoLabel.Name = "DepartmentsInfoLabel";
            this.DepartmentsInfoLabel.Size = new System.Drawing.Size(283, 44);
            this.DepartmentsInfoLabel.TabIndex = 0;
            this.DepartmentsInfoLabel.Text = "Departments";
            this.DepartmentsInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TopCenterLayaut
            // 
            this.TopCenterLayaut.ColumnCount = 3;
            this.TopCenterLayaut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TopCenterLayaut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TopCenterLayaut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TopCenterLayaut.Controls.Add(this.ReportsBtn, 1, 0);
            this.TopCenterLayaut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopCenterLayaut.Location = new System.Drawing.Point(107, 3);
            this.TopCenterLayaut.Name = "TopCenterLayaut";
            this.TopCenterLayaut.RowCount = 1;
            this.TopCenterLayaut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TopCenterLayaut.Size = new System.Drawing.Size(579, 58);
            this.TopCenterLayaut.TabIndex = 1;
            // 
            // ReportsBtn
            // 
            this.ReportsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportsBtn.Location = new System.Drawing.Point(196, 3);
            this.ReportsBtn.Name = "ReportsBtn";
            this.ReportsBtn.Size = new System.Drawing.Size(187, 52);
            this.ReportsBtn.TabIndex = 0;
            this.ReportsBtn.Text = "See reports";
            this.ReportsBtn.UseVisualStyleBackColor = true;
            this.ReportsBtn.Click += new System.EventHandler(this.ReportsBtn_Click);
            // 
            // ControlElementsLayout
            // 
            this.ControlElementsLayout.ColumnCount = 3;
            this.ControlElementsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ControlElementsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ControlElementsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ControlElementsLayout.Controls.Add(this.ResumeBtn, 2, 0);
            this.ControlElementsLayout.Controls.Add(this.SuspendBtn, 1, 0);
            this.ControlElementsLayout.Controls.Add(this.StateComboBox, 0, 0);
            this.ControlElementsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlElementsLayout.Location = new System.Drawing.Point(107, 341);
            this.ControlElementsLayout.Name = "ControlElementsLayout";
            this.ControlElementsLayout.RowCount = 1;
            this.ControlElementsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ControlElementsLayout.Size = new System.Drawing.Size(579, 48);
            this.ControlElementsLayout.TabIndex = 2;
            // 
            // ResumeBtn
            // 
            this.ResumeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResumeBtn.Location = new System.Drawing.Point(389, 3);
            this.ResumeBtn.Name = "ResumeBtn";
            this.ResumeBtn.Size = new System.Drawing.Size(187, 42);
            this.ResumeBtn.TabIndex = 1;
            this.ResumeBtn.Text = "Resume";
            this.ResumeBtn.UseVisualStyleBackColor = true;
            this.ResumeBtn.Click += new System.EventHandler(this.ResumeBtn_Click);
            // 
            // SuspendBtn
            // 
            this.SuspendBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SuspendBtn.Enabled = false;
            this.SuspendBtn.Location = new System.Drawing.Point(196, 3);
            this.SuspendBtn.Name = "SuspendBtn";
            this.SuspendBtn.Size = new System.Drawing.Size(187, 42);
            this.SuspendBtn.TabIndex = 2;
            this.SuspendBtn.Text = "Suspend";
            this.SuspendBtn.UseVisualStyleBackColor = true;
            this.SuspendBtn.Click += new System.EventHandler(this.SuspendBtn_Click);
            // 
            // StateComboBox
            // 
            this.StateComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StateComboBox.FormattingEnabled = true;
            this.StateComboBox.Items.AddRange(new object[] {"Buying materials", "Creating products", "Sailing products"});
            this.StateComboBox.Location = new System.Drawing.Point(3, 3);
            this.StateComboBox.Name = "StateComboBox";
            this.StateComboBox.Size = new System.Drawing.Size(187, 28);
            this.StateComboBox.TabIndex = 3;
            this.StateComboBox.SelectedIndexChanged += new System.EventHandler(this.StateComboBox_SelectedIndexChanged);
            // 
            // OpenReportDialog
            // 
            this.OpenReportDialog.FileName = "OpenReportDialog";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 392);
            this.Controls.Add(this.MainLayout);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.MainLayout.ResumeLayout(false);
            this.InfoLabelsLayout.ResumeLayout(false);
            this.TopCenterLayaut.ResumeLayout(false);
            this.ControlElementsLayout.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.OpenFileDialog OpenReportDialog;

        private System.Windows.Forms.ComboBox StateComboBox;

        private System.Windows.Forms.Button ResumeBtn;
        private System.Windows.Forms.Button SuspendBtn;
        private System.Windows.Forms.Button ReportsBtn;

        private System.Windows.Forms.TableLayoutPanel ControlElementsLayout;
        private System.Windows.Forms.TableLayoutPanel TopCenterLayaut;

        private System.Windows.Forms.Label FreeStorageSpaceInfoLabel;
        private System.Windows.Forms.Label MoneyInfoLabel;
        private System.Windows.Forms.Label RawMaterialInfoLabel;
        private System.Windows.Forms.Label ProductsInfoLabel;
        private System.Windows.Forms.Label DepartmentsInfoLabel;
        private System.Windows.Forms.Label CurrentStateInfoLabel;
        
        public System.Windows.Forms.Label CurrentStateLabel;
        public System.Windows.Forms.Label DepartmentsLabel;
        public System.Windows.Forms.Label ProductsLabel;
        public System.Windows.Forms.Label RawMaterialLabel;
        public System.Windows.Forms.Label MoneyLabel;
        public System.Windows.Forms.Label FreeStorageSpaceLabel;

        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.TableLayoutPanel InfoLabelsLayout;

        #endregion
    }
}