namespace client
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
            this.RedTrackBar = new System.Windows.Forms.TrackBar();
            this.TrackersLayout = new System.Windows.Forms.TableLayoutPanel();
            this.BlueTrackBar = new System.Windows.Forms.TrackBar();
            this.GreenTrackBar = new System.Windows.Forms.TrackBar();
            this.BlueLabel = new System.Windows.Forms.Label();
            this.GreenLabel = new System.Windows.Forms.Label();
            this.RedLabel = new System.Windows.Forms.Label();
            this.SetBtn = new System.Windows.Forms.Button();
            this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ConnectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConnectionStatusValueLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ColourLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.RedTrackBar)).BeginInit();
            this.TrackersLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.BlueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.GreenTrackBar)).BeginInit();
            this.MainLayoutPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RedTrackBar
            // 
            this.RedTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RedTrackBar.Location = new System.Drawing.Point(4, 5);
            this.RedTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RedTrackBar.Maximum = 255;
            this.RedTrackBar.Name = "RedTrackBar";
            this.RedTrackBar.Size = new System.Drawing.Size(784, 56);
            this.RedTrackBar.TabIndex = 0;
            this.RedTrackBar.TickFrequency = 3;
            this.RedTrackBar.Scroll += new System.EventHandler(this.RedTrackBar_Scroll);
            // 
            // TrackersLayout
            // 
            this.TrackersLayout.ColumnCount = 2;
            this.TrackersLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.63338F));
            this.TrackersLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.36662F));
            this.TrackersLayout.Controls.Add(this.BlueTrackBar, 0, 2);
            this.TrackersLayout.Controls.Add(this.GreenTrackBar, 0, 1);
            this.TrackersLayout.Controls.Add(this.BlueLabel, 1, 2);
            this.TrackersLayout.Controls.Add(this.GreenLabel, 1, 1);
            this.TrackersLayout.Controls.Add(this.RedTrackBar, 0, 0);
            this.TrackersLayout.Controls.Add(this.RedLabel, 1, 0);
            this.TrackersLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackersLayout.Location = new System.Drawing.Point(4, 5);
            this.TrackersLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TrackersLayout.Name = "TrackersLayout";
            this.TrackersLayout.RowCount = 3;
            this.TrackersLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TrackersLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TrackersLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TrackersLayout.Size = new System.Drawing.Size(884, 200);
            this.TrackersLayout.TabIndex = 3;
            // 
            // BlueTrackBar
            // 
            this.BlueTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlueTrackBar.Location = new System.Drawing.Point(4, 137);
            this.BlueTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BlueTrackBar.Maximum = 255;
            this.BlueTrackBar.Name = "BlueTrackBar";
            this.BlueTrackBar.Size = new System.Drawing.Size(784, 58);
            this.BlueTrackBar.TabIndex = 7;
            this.BlueTrackBar.TickFrequency = 3;
            this.BlueTrackBar.Scroll += new System.EventHandler(this.BlueTrackBar_Scroll);
            // 
            // GreenTrackBar
            // 
            this.GreenTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GreenTrackBar.Location = new System.Drawing.Point(4, 71);
            this.GreenTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GreenTrackBar.Maximum = 255;
            this.GreenTrackBar.Name = "GreenTrackBar";
            this.GreenTrackBar.Size = new System.Drawing.Size(784, 56);
            this.GreenTrackBar.TabIndex = 6;
            this.GreenTrackBar.TickFrequency = 3;
            this.GreenTrackBar.Scroll += new System.EventHandler(this.GreenTrackBar_Scroll);
            // 
            // BlueLabel
            // 
            this.BlueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlueLabel.Location = new System.Drawing.Point(796, 132);
            this.BlueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BlueLabel.Name = "BlueLabel";
            this.BlueLabel.Size = new System.Drawing.Size(84, 68);
            this.BlueLabel.TabIndex = 5;
            this.BlueLabel.Text = "Blue";
            this.BlueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GreenLabel
            // 
            this.GreenLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GreenLabel.Location = new System.Drawing.Point(796, 66);
            this.GreenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GreenLabel.Name = "GreenLabel";
            this.GreenLabel.Size = new System.Drawing.Size(84, 66);
            this.GreenLabel.TabIndex = 4;
            this.GreenLabel.Text = "Green";
            this.GreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RedLabel
            // 
            this.RedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RedLabel.Location = new System.Drawing.Point(796, 0);
            this.RedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RedLabel.Name = "RedLabel";
            this.RedLabel.Size = new System.Drawing.Size(84, 66);
            this.RedLabel.TabIndex = 3;
            this.RedLabel.Text = "Red";
            this.RedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SetBtn
            // 
            this.SetBtn.Location = new System.Drawing.Point(447, 5);
            this.SetBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SetBtn.Name = "SetBtn";
            this.SetBtn.Size = new System.Drawing.Size(154, 28);
            this.SetBtn.TabIndex = 4;
            this.SetBtn.Text = "Set value";
            this.SetBtn.UseVisualStyleBackColor = true;
            this.SetBtn.Click += new System.EventHandler(this.SetBtn_Click);
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.ColumnCount = 1;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainLayoutPanel.Controls.Add(this.statusStrip1, 0, 2);
            this.MainLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.MainLayoutPanel.Controls.Add(this.TrackersLayout, 0, 0);
            this.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainLayoutPanel.Name = "MainLayoutPanel";
            this.MainLayoutPanel.RowCount = 3;
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.67326F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.32673F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.MainLayoutPanel.Size = new System.Drawing.Size(892, 281);
            this.MainLayoutPanel.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.ConnectionStatusLabel, this.ConnectionStatusValueLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 254);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(892, 27);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ConnectionStatusLabel
            // 
            this.ConnectionStatusLabel.Name = "ConnectionStatusLabel";
            this.ConnectionStatusLabel.Size = new System.Drawing.Size(106, 22);
            this.ConnectionStatusLabel.Text = "Connection status:";
            // 
            // ConnectionStatusValueLabel
            // 
            this.ConnectionStatusValueLabel.Name = "ConnectionStatusValueLabel";
            this.ConnectionStatusValueLabel.Size = new System.Drawing.Size(84, 22);
            this.ConnectionStatusValueLabel.Text = "not connected";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ColourLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SetBtn, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 213);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(886, 38);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // ColourLabel
            // 
            this.ColourLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColourLabel.Location = new System.Drawing.Point(4, 0);
            this.ColourLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ColourLabel.Name = "ColourLabel";
            this.ColourLabel.Size = new System.Drawing.Size(435, 38);
            this.ColourLabel.TabIndex = 5;
            this.ColourLabel.Text = "( 0; 0; 0; )";
            this.ColourLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 281);
            this.Controls.Add(this.MainLayoutPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize) (this.RedTrackBar)).EndInit();
            this.TrackersLayout.ResumeLayout(false);
            this.TrackersLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.BlueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.GreenTrackBar)).EndInit();
            this.MainLayoutPanel.ResumeLayout(false);
            this.MainLayoutPanel.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ToolStripStatusLabel ConnectionStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel ConnectionStatusValueLabel;

        private System.Windows.Forms.StatusStrip statusStrip1;

        private System.Windows.Forms.Label ColourLabel;

        private System.Windows.Forms.TableLayoutPanel TrackersLayout;

        private System.Windows.Forms.TableLayoutPanel MainLayoutPanel;

        private System.Windows.Forms.Button SetBtn;

        private System.Windows.Forms.Label BlueLabel;
        private System.Windows.Forms.Label GreenLabel;
        private System.Windows.Forms.Label RedLabel;

        private System.Windows.Forms.TrackBar RedTrackBar;
        private System.Windows.Forms.TrackBar BlueTrackBar;
        private System.Windows.Forms.TrackBar GreenTrackBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}