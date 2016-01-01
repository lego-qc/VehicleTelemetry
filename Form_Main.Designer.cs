namespace QCTracker {
    partial class QCTrackerMainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.mapGroup = new System.Windows.Forms.GroupBox();
            this.mainSplitLayout = new System.Windows.Forms.SplitContainer();
            this.dataPanelGroup = new System.Windows.Forms.GroupBox();
            this.debugPushWaypoint = new System.Windows.Forms.Button();
            this.dataPanelMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.dataPanelLabelPos = new System.Windows.Forms.Label();
            this.dataPanelLabelLat = new System.Windows.Forms.Label();
            this.dataPanelLabelLong = new System.Windows.Forms.Label();
            this.dataPanelLat = new System.Windows.Forms.TextBox();
            this.dataPanelLong = new System.Windows.Forms.TextBox();
            this.dataPanelLabelAlt = new System.Windows.Forms.Label();
            this.dataPanelAlt = new System.Windows.Forms.TextBox();
            this.dataPanelPositionLock = new System.Windows.Forms.CheckBox();
            this.dataPanelLocate = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMapOptions = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitLayout)).BeginInit();
            this.mainSplitLayout.Panel1.SuspendLayout();
            this.mainSplitLayout.Panel2.SuspendLayout();
            this.mainSplitLayout.SuspendLayout();
            this.dataPanelGroup.SuspendLayout();
            this.dataPanelMainLayout.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapGroup
            // 
            this.mapGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapGroup.Location = new System.Drawing.Point(0, 0);
            this.mapGroup.Name = "mapGroup";
            this.mapGroup.Size = new System.Drawing.Size(514, 433);
            this.mapGroup.TabIndex = 1;
            this.mapGroup.TabStop = false;
            this.mapGroup.Text = "Viewport";
            // 
            // mainSplitLayout
            // 
            this.mainSplitLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitLayout.Location = new System.Drawing.Point(0, 24);
            this.mainSplitLayout.Name = "mainSplitLayout";
            // 
            // mainSplitLayout.Panel1
            // 
            this.mainSplitLayout.Panel1.Controls.Add(this.mapGroup);
            // 
            // mainSplitLayout.Panel2
            // 
            this.mainSplitLayout.Panel2.Controls.Add(this.dataPanelGroup);
            this.mainSplitLayout.Panel2MinSize = 200;
            this.mainSplitLayout.Size = new System.Drawing.Size(718, 433);
            this.mainSplitLayout.SplitterDistance = 514;
            this.mainSplitLayout.TabIndex = 2;
            // 
            // dataPanelGroup
            // 
            this.dataPanelGroup.Controls.Add(this.debugPushWaypoint);
            this.dataPanelGroup.Controls.Add(this.dataPanelMainLayout);
            this.dataPanelGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanelGroup.Location = new System.Drawing.Point(0, 0);
            this.dataPanelGroup.Name = "dataPanelGroup";
            this.dataPanelGroup.Size = new System.Drawing.Size(200, 433);
            this.dataPanelGroup.TabIndex = 0;
            this.dataPanelGroup.TabStop = false;
            this.dataPanelGroup.Text = "Data";
            // 
            // debugPushWaypoint
            // 
            this.debugPushWaypoint.Location = new System.Drawing.Point(87, 356);
            this.debugPushWaypoint.Name = "debugPushWaypoint";
            this.debugPushWaypoint.Size = new System.Drawing.Size(75, 23);
            this.debugPushWaypoint.TabIndex = 1;
            this.debugPushWaypoint.Text = "Debug Push";
            this.debugPushWaypoint.UseVisualStyleBackColor = true;
            this.debugPushWaypoint.Click += new System.EventHandler(this.debugPushWaypoint_Click);
            // 
            // dataPanelMainLayout
            // 
            this.dataPanelMainLayout.ColumnCount = 2;
            this.dataPanelMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.dataPanelMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dataPanelMainLayout.Controls.Add(this.dataPanelLabelPos, 0, 0);
            this.dataPanelMainLayout.Controls.Add(this.dataPanelLabelLat, 0, 1);
            this.dataPanelMainLayout.Controls.Add(this.dataPanelLabelLong, 0, 2);
            this.dataPanelMainLayout.Controls.Add(this.dataPanelLat, 1, 1);
            this.dataPanelMainLayout.Controls.Add(this.dataPanelLong, 1, 2);
            this.dataPanelMainLayout.Controls.Add(this.dataPanelLabelAlt, 0, 3);
            this.dataPanelMainLayout.Controls.Add(this.dataPanelAlt, 1, 3);
            this.dataPanelMainLayout.Controls.Add(this.dataPanelPositionLock, 1, 4);
            this.dataPanelMainLayout.Controls.Add(this.dataPanelLocate, 0, 4);
            this.dataPanelMainLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataPanelMainLayout.Location = new System.Drawing.Point(3, 16);
            this.dataPanelMainLayout.Name = "dataPanelMainLayout";
            this.dataPanelMainLayout.RowCount = 7;
            this.dataPanelMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dataPanelMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dataPanelMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dataPanelMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dataPanelMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.dataPanelMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.dataPanelMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dataPanelMainLayout.Size = new System.Drawing.Size(194, 125);
            this.dataPanelMainLayout.TabIndex = 0;
            // 
            // dataPanelLabelPos
            // 
            this.dataPanelLabelPos.AutoSize = true;
            this.dataPanelLabelPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanelLabelPos.Location = new System.Drawing.Point(3, 0);
            this.dataPanelLabelPos.Name = "dataPanelLabelPos";
            this.dataPanelLabelPos.Size = new System.Drawing.Size(74, 20);
            this.dataPanelLabelPos.TabIndex = 0;
            this.dataPanelLabelPos.Text = "Position:";
            this.dataPanelLabelPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataPanelLabelLat
            // 
            this.dataPanelLabelLat.AutoSize = true;
            this.dataPanelLabelLat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanelLabelLat.Location = new System.Drawing.Point(1, 21);
            this.dataPanelLabelLat.Margin = new System.Windows.Forms.Padding(1);
            this.dataPanelLabelLat.Name = "dataPanelLabelLat";
            this.dataPanelLabelLat.Size = new System.Drawing.Size(78, 18);
            this.dataPanelLabelLat.TabIndex = 1;
            this.dataPanelLabelLat.Text = "Latitude = ";
            this.dataPanelLabelLat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataPanelLabelLong
            // 
            this.dataPanelLabelLong.AutoSize = true;
            this.dataPanelLabelLong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanelLabelLong.Location = new System.Drawing.Point(1, 41);
            this.dataPanelLabelLong.Margin = new System.Windows.Forms.Padding(1);
            this.dataPanelLabelLong.Name = "dataPanelLabelLong";
            this.dataPanelLabelLong.Size = new System.Drawing.Size(78, 18);
            this.dataPanelLabelLong.TabIndex = 2;
            this.dataPanelLabelLong.Text = "Longitude = ";
            this.dataPanelLabelLong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataPanelLat
            // 
            this.dataPanelLat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanelLat.Location = new System.Drawing.Point(81, 21);
            this.dataPanelLat.Margin = new System.Windows.Forms.Padding(1);
            this.dataPanelLat.Name = "dataPanelLat";
            this.dataPanelLat.ReadOnly = true;
            this.dataPanelLat.Size = new System.Drawing.Size(112, 20);
            this.dataPanelLat.TabIndex = 3;
            this.dataPanelLat.Text = "0.0";
            // 
            // dataPanelLong
            // 
            this.dataPanelLong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanelLong.Location = new System.Drawing.Point(81, 41);
            this.dataPanelLong.Margin = new System.Windows.Forms.Padding(1);
            this.dataPanelLong.Name = "dataPanelLong";
            this.dataPanelLong.ReadOnly = true;
            this.dataPanelLong.Size = new System.Drawing.Size(112, 20);
            this.dataPanelLong.TabIndex = 4;
            this.dataPanelLong.Text = "0.0";
            // 
            // dataPanelLabelAlt
            // 
            this.dataPanelLabelAlt.AutoSize = true;
            this.dataPanelLabelAlt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanelLabelAlt.Location = new System.Drawing.Point(3, 60);
            this.dataPanelLabelAlt.Name = "dataPanelLabelAlt";
            this.dataPanelLabelAlt.Size = new System.Drawing.Size(74, 20);
            this.dataPanelLabelAlt.TabIndex = 5;
            this.dataPanelLabelAlt.Text = "Altitude = ";
            this.dataPanelLabelAlt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataPanelAlt
            // 
            this.dataPanelAlt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanelAlt.Location = new System.Drawing.Point(81, 61);
            this.dataPanelAlt.Margin = new System.Windows.Forms.Padding(1);
            this.dataPanelAlt.Name = "dataPanelAlt";
            this.dataPanelAlt.ReadOnly = true;
            this.dataPanelAlt.Size = new System.Drawing.Size(112, 20);
            this.dataPanelAlt.TabIndex = 6;
            this.dataPanelAlt.Text = "0.0";
            // 
            // dataPanelPositionLock
            // 
            this.dataPanelPositionLock.AutoSize = true;
            this.dataPanelPositionLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanelPositionLock.Location = new System.Drawing.Point(81, 81);
            this.dataPanelPositionLock.Margin = new System.Windows.Forms.Padding(1);
            this.dataPanelPositionLock.Name = "dataPanelPositionLock";
            this.dataPanelPositionLock.Size = new System.Drawing.Size(112, 23);
            this.dataPanelPositionLock.TabIndex = 7;
            this.dataPanelPositionLock.Text = "Tracking";
            this.dataPanelPositionLock.UseVisualStyleBackColor = true;
            this.dataPanelPositionLock.CheckedChanged += new System.EventHandler(this.dataPanelPositionLock_CheckedChanged);
            // 
            // dataPanelLocate
            // 
            this.dataPanelLocate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanelLocate.Location = new System.Drawing.Point(1, 81);
            this.dataPanelLocate.Margin = new System.Windows.Forms.Padding(1);
            this.dataPanelLocate.Name = "dataPanelLocate";
            this.dataPanelLocate.Size = new System.Drawing.Size(78, 23);
            this.dataPanelLocate.TabIndex = 8;
            this.dataPanelLocate.Text = "Locate";
            this.dataPanelLocate.UseVisualStyleBackColor = true;
            this.dataPanelLocate.Click += new System.EventHandler(this.dataPanelLocate_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuNetwork,
            this.menuOptions});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(718, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(92, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuNetwork
            // 
            this.menuNetwork.Name = "menuNetwork";
            this.menuNetwork.Size = new System.Drawing.Size(64, 20);
            this.menuNetwork.Text = "Network";
            // 
            // menuOptions
            // 
            this.menuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemMapOptions});
            this.menuOptions.Name = "menuOptions";
            this.menuOptions.Size = new System.Drawing.Size(61, 20);
            this.menuOptions.Text = "Options";
            // 
            // menuItemMapOptions
            // 
            this.menuItemMapOptions.Name = "menuItemMapOptions";
            this.menuItemMapOptions.Size = new System.Drawing.Size(143, 22);
            this.menuItemMapOptions.Text = "Map Options";
            this.menuItemMapOptions.Click += new System.EventHandler(this.menuItemMapOptions_Click);
            // 
            // QCTrackerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 457);
            this.Controls.Add(this.mainSplitLayout);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "QCTrackerMainForm";
            this.Text = "Quadcopter Tracker";
            this.mainSplitLayout.Panel1.ResumeLayout(false);
            this.mainSplitLayout.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitLayout)).EndInit();
            this.mainSplitLayout.ResumeLayout(false);
            this.dataPanelGroup.ResumeLayout(false);
            this.dataPanelMainLayout.ResumeLayout(false);
            this.dataPanelMainLayout.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox mapGroup;
        private System.Windows.Forms.SplitContainer mainSplitLayout;
        private System.Windows.Forms.GroupBox dataPanelGroup;
        private System.Windows.Forms.TableLayoutPanel dataPanelMainLayout;
        private System.Windows.Forms.Label dataPanelLabelLong;
        private System.Windows.Forms.Label dataPanelLabelAlt;
        private System.Windows.Forms.TextBox dataPanelAlt;
        private System.Windows.Forms.TextBox dataPanelLong;
        private System.Windows.Forms.TextBox dataPanelLat;
        private System.Windows.Forms.Label dataPanelLabelLat;
        private System.Windows.Forms.Label dataPanelLabelPos;
        private System.Windows.Forms.CheckBox dataPanelPositionLock;
        private System.Windows.Forms.Button dataPanelLocate;
        private System.Windows.Forms.Button debugPushWaypoint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuNetwork;
        private System.Windows.Forms.ToolStripMenuItem menuOptions;
        private System.Windows.Forms.ToolStripMenuItem menuItemMapOptions;
    }
}

