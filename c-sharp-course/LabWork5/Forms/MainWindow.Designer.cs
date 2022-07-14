namespace LabWork5.Forms
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
            this.TopControlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ManageGroupsBtn = new System.Windows.Forms.Button();
            this.FiltrationLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.StudentsFiltrationLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ChoseGroupLabel = new System.Windows.Forms.Label();
            this.GroupsComboBox = new System.Windows.Forms.ComboBox();
            this.StudentsGrid = new System.Windows.Forms.DataGridView();
            this.StudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FilesManagementLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SaveFileBtn = new System.Windows.Forms.Button();
            this.LoadFileBtn = new System.Windows.Forms.Button();
            this.StudentsControlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ModifyStudentsBtn = new System.Windows.Forms.Button();
            this.DeleteStudentsBtn = new System.Windows.Forms.Button();
            this.AddStudentBtn = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.MainLayout.SuspendLayout();
            this.TopControlLayout.SuspendLayout();
            this.FiltrationLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.StudentsGrid)).BeginInit();
            this.ControlPanel.SuspendLayout();
            this.FilesManagementLayout.SuspendLayout();
            this.StudentsControlLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 1;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Controls.Add(this.TopControlLayout, 0, 0);
            this.MainLayout.Controls.Add(this.StudentsGrid, 0, 1);
            this.MainLayout.Controls.Add(this.ControlPanel, 0, 2);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 3;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.07308F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.95365F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.97326F));
            this.MainLayout.Size = new System.Drawing.Size(784, 561);
            this.MainLayout.TabIndex = 0;
            // 
            // TopControlLayout
            // 
            this.TopControlLayout.ColumnCount = 2;
            this.TopControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.42783F));
            this.TopControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.57216F));
            this.TopControlLayout.Controls.Add(this.ManageGroupsBtn, 1, 0);
            this.TopControlLayout.Controls.Add(this.FiltrationLayout, 0, 0);
            this.TopControlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopControlLayout.Location = new System.Drawing.Point(4, 5);
            this.TopControlLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TopControlLayout.Name = "TopControlLayout";
            this.TopControlLayout.RowCount = 1;
            this.TopControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TopControlLayout.Size = new System.Drawing.Size(776, 96);
            this.TopControlLayout.TabIndex = 0;
            // 
            // ManageGroupsBtn
            // 
            this.ManageGroupsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ManageGroupsBtn.Location = new System.Drawing.Point(541, 10);
            this.ManageGroupsBtn.Margin = new System.Windows.Forms.Padding(10);
            this.ManageGroupsBtn.Name = "ManageGroupsBtn";
            this.ManageGroupsBtn.Size = new System.Drawing.Size(225, 76);
            this.ManageGroupsBtn.TabIndex = 0;
            this.ManageGroupsBtn.Text = "Manage groups";
            this.ManageGroupsBtn.UseVisualStyleBackColor = true;
            this.ManageGroupsBtn.Click += new System.EventHandler(this.ManageGroupsBtn_Click);
            // 
            // FiltrationLayout
            // 
            this.FiltrationLayout.ColumnCount = 3;
            this.FiltrationLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FiltrationLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.FiltrationLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.FiltrationLayout.Controls.Add(this.ApplyBtn, 2, 0);
            this.FiltrationLayout.Controls.Add(this.StudentsFiltrationLabel, 0, 0);
            this.FiltrationLayout.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.FiltrationLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FiltrationLayout.Location = new System.Drawing.Point(3, 3);
            this.FiltrationLayout.Name = "FiltrationLayout";
            this.FiltrationLayout.RowCount = 1;
            this.FiltrationLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FiltrationLayout.Size = new System.Drawing.Size(525, 90);
            this.FiltrationLayout.TabIndex = 1;
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ApplyBtn.Location = new System.Drawing.Point(400, 10);
            this.ApplyBtn.Margin = new System.Windows.Forms.Padding(10);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(115, 70);
            this.ApplyBtn.TabIndex = 2;
            this.ApplyBtn.Text = "Apply filter";
            this.ApplyBtn.UseVisualStyleBackColor = true;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // StudentsFiltrationLabel
            // 
            this.StudentsFiltrationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentsFiltrationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.StudentsFiltrationLabel.Location = new System.Drawing.Point(3, 0);
            this.StudentsFiltrationLabel.Name = "StudentsFiltrationLabel";
            this.StudentsFiltrationLabel.Size = new System.Drawing.Size(243, 90);
            this.StudentsFiltrationLabel.TabIndex = 0;
            this.StudentsFiltrationLabel.Text = "Students filtration";
            this.StudentsFiltrationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ChoseGroupLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.GroupsComboBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(252, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(135, 84);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // ChoseGroupLabel
            // 
            this.ChoseGroupLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChoseGroupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ChoseGroupLabel.Location = new System.Drawing.Point(3, 0);
            this.ChoseGroupLabel.Name = "ChoseGroupLabel";
            this.ChoseGroupLabel.Size = new System.Drawing.Size(129, 30);
            this.ChoseGroupLabel.TabIndex = 1;
            this.ChoseGroupLabel.Text = "Select group";
            this.ChoseGroupLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // GroupsComboBox
            // 
            this.GroupsComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupsComboBox.FormattingEnabled = true;
            this.GroupsComboBox.Location = new System.Drawing.Point(3, 33);
            this.GroupsComboBox.Name = "GroupsComboBox";
            this.GroupsComboBox.Size = new System.Drawing.Size(129, 28);
            this.GroupsComboBox.TabIndex = 2;
            // 
            // StudentsGrid
            // 
            this.StudentsGrid.AllowUserToAddRows = false;
            this.StudentsGrid.AllowUserToDeleteRows = false;
            this.StudentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.StudentId, this.StudentName, this.Group});
            this.StudentsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentsGrid.Location = new System.Drawing.Point(3, 109);
            this.StudentsGrid.Name = "StudentsGrid";
            this.StudentsGrid.ReadOnly = true;
            this.StudentsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StudentsGrid.Size = new System.Drawing.Size(778, 364);
            this.StudentsGrid.TabIndex = 1;
            // 
            // StudentId
            // 
            this.StudentId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StudentId.HeaderText = "StudentId";
            this.StudentId.Name = "StudentId";
            this.StudentId.ReadOnly = true;
            // 
            // StudentName
            // 
            this.StudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StudentName.HeaderText = "StudentName";
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            // 
            // Group
            // 
            this.Group.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Group.HeaderText = "Group";
            this.Group.Name = "Group";
            this.Group.ReadOnly = true;
            // 
            // ControlPanel
            // 
            this.ControlPanel.ColumnCount = 2;
            this.ControlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 469F));
            this.ControlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 309F));
            this.ControlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ControlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ControlPanel.Controls.Add(this.FilesManagementLayout, 1, 0);
            this.ControlPanel.Controls.Add(this.StudentsControlLayout, 0, 0);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlPanel.Location = new System.Drawing.Point(3, 479);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.RowCount = 1;
            this.ControlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ControlPanel.Size = new System.Drawing.Size(778, 79);
            this.ControlPanel.TabIndex = 2;
            // 
            // FilesManagementLayout
            // 
            this.FilesManagementLayout.ColumnCount = 2;
            this.FilesManagementLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FilesManagementLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FilesManagementLayout.Controls.Add(this.SaveFileBtn, 1, 0);
            this.FilesManagementLayout.Controls.Add(this.LoadFileBtn, 0, 0);
            this.FilesManagementLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilesManagementLayout.Location = new System.Drawing.Point(475, 6);
            this.FilesManagementLayout.Margin = new System.Windows.Forms.Padding(6);
            this.FilesManagementLayout.Name = "FilesManagementLayout";
            this.FilesManagementLayout.Padding = new System.Windows.Forms.Padding(3);
            this.FilesManagementLayout.RowCount = 1;
            this.FilesManagementLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FilesManagementLayout.Size = new System.Drawing.Size(297, 67);
            this.FilesManagementLayout.TabIndex = 0;
            // 
            // SaveFileBtn
            // 
            this.SaveFileBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveFileBtn.Location = new System.Drawing.Point(151, 6);
            this.SaveFileBtn.Name = "SaveFileBtn";
            this.SaveFileBtn.Size = new System.Drawing.Size(140, 55);
            this.SaveFileBtn.TabIndex = 1;
            this.SaveFileBtn.Text = "Save to file";
            this.SaveFileBtn.UseVisualStyleBackColor = true;
            this.SaveFileBtn.Click += new System.EventHandler(this.SaveFileBtn_Click);
            // 
            // LoadFileBtn
            // 
            this.LoadFileBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadFileBtn.Location = new System.Drawing.Point(6, 6);
            this.LoadFileBtn.Name = "LoadFileBtn";
            this.LoadFileBtn.Size = new System.Drawing.Size(139, 55);
            this.LoadFileBtn.TabIndex = 0;
            this.LoadFileBtn.Text = "Load file";
            this.LoadFileBtn.UseVisualStyleBackColor = true;
            this.LoadFileBtn.Click += new System.EventHandler(this.LoadFileBtn_Click);
            // 
            // StudentsControlLayout
            // 
            this.StudentsControlLayout.ColumnCount = 3;
            this.StudentsControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.StudentsControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.StudentsControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.StudentsControlLayout.Controls.Add(this.ModifyStudentsBtn, 0, 0);
            this.StudentsControlLayout.Controls.Add(this.DeleteStudentsBtn, 0, 0);
            this.StudentsControlLayout.Controls.Add(this.AddStudentBtn, 0, 0);
            this.StudentsControlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentsControlLayout.Location = new System.Drawing.Point(3, 3);
            this.StudentsControlLayout.Name = "StudentsControlLayout";
            this.StudentsControlLayout.Padding = new System.Windows.Forms.Padding(4);
            this.StudentsControlLayout.RowCount = 1;
            this.StudentsControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.StudentsControlLayout.Size = new System.Drawing.Size(463, 73);
            this.StudentsControlLayout.TabIndex = 1;
            // 
            // ModifyStudentsBtn
            // 
            this.ModifyStudentsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifyStudentsBtn.Location = new System.Drawing.Point(309, 7);
            this.ModifyStudentsBtn.Name = "ModifyStudentsBtn";
            this.ModifyStudentsBtn.Size = new System.Drawing.Size(147, 59);
            this.ModifyStudentsBtn.TabIndex = 3;
            this.ModifyStudentsBtn.Text = "Modify students";
            this.ModifyStudentsBtn.UseVisualStyleBackColor = true;
            this.ModifyStudentsBtn.Click += new System.EventHandler(this.ModifyStudentsBtn_Click);
            // 
            // DeleteStudentsBtn
            // 
            this.DeleteStudentsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteStudentsBtn.Location = new System.Drawing.Point(158, 7);
            this.DeleteStudentsBtn.Name = "DeleteStudentsBtn";
            this.DeleteStudentsBtn.Size = new System.Drawing.Size(145, 59);
            this.DeleteStudentsBtn.TabIndex = 2;
            this.DeleteStudentsBtn.Text = "Delete students";
            this.DeleteStudentsBtn.UseVisualStyleBackColor = true;
            this.DeleteStudentsBtn.Click += new System.EventHandler(this.DeleteStudentsBtn_Click);
            // 
            // AddStudentBtn
            // 
            this.AddStudentBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddStudentBtn.Location = new System.Drawing.Point(7, 7);
            this.AddStudentBtn.Name = "AddStudentBtn";
            this.AddStudentBtn.Size = new System.Drawing.Size(145, 59);
            this.AddStudentBtn.TabIndex = 1;
            this.AddStudentBtn.Text = "Add student";
            this.AddStudentBtn.UseVisualStyleBackColor = true;
            this.AddStudentBtn.Click += new System.EventHandler(this.AddStudentBtn_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.MainLayout);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.MainLayout.ResumeLayout(false);
            this.TopControlLayout.ResumeLayout(false);
            this.FiltrationLayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.StudentsGrid)).EndInit();
            this.ControlPanel.ResumeLayout(false);
            this.FilesManagementLayout.ResumeLayout(false);
            this.StudentsControlLayout.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox GroupsComboBox;

        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;

        private System.Windows.Forms.DataGridViewTextBoxColumn StudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        
        private System.Windows.Forms.TableLayoutPanel StudentsControlLayout;
        
        private System.Windows.Forms.Button AddStudentBtn;
        private System.Windows.Forms.Button DeleteStudentsBtn;
        private System.Windows.Forms.Button ModifyStudentsBtn;
        private System.Windows.Forms.Button LoadFileBtn;
        private System.Windows.Forms.Button SaveFileBtn;
        private System.Windows.Forms.Button ApplyBtn;
        private System.Windows.Forms.Button ManageGroupsBtn;

        private System.Windows.Forms.Label ChoseGroupLabel;
        private System.Windows.Forms.Label StudentsFiltrationLabel;
        private System.Windows.Forms.DataGridView StudentsGrid;
        
        private System.Windows.Forms.TableLayoutPanel FilesManagementLayout;
        private System.Windows.Forms.TableLayoutPanel ControlPanel;
        private System.Windows.Forms.TableLayoutPanel TopControlLayout;
        private System.Windows.Forms.TableLayoutPanel FiltrationLayout;
        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}