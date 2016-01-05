namespace VehicleTelemetry {
    partial class Form_VehicleTelemetryMain {
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
            this.dataGroupBox = new System.Windows.Forms.GroupBox();
            this.dataPanel = new VehicleTelemetry.DataPanel();
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
            this.dataGroupBox.SuspendLayout();
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
            this.mainSplitLayout.Panel2.Controls.Add(this.dataGroupBox);
            this.mainSplitLayout.Panel2MinSize = 200;
            this.mainSplitLayout.Size = new System.Drawing.Size(718, 433);
            this.mainSplitLayout.SplitterDistance = 514;
            this.mainSplitLayout.TabIndex = 2;
            // 
            // dataGroupBox
            // 
            this.dataGroupBox.Controls.Add(this.dataPanel);
            this.dataGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGroupBox.Location = new System.Drawing.Point(0, 0);
            this.dataGroupBox.Name = "dataGroupBox";
            this.dataGroupBox.Size = new System.Drawing.Size(200, 433);
            this.dataGroupBox.TabIndex = 1;
            this.dataGroupBox.TabStop = false;
            this.dataGroupBox.Text = "Data";
            // 
            // dataPanel
            // 
            this.dataPanel.Count = 0;
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanel.Location = new System.Drawing.Point(3, 16);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(194, 414);
            this.dataPanel.TabIndex = 0;
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
            // Form_VehicleTelemetryMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 457);
            this.Controls.Add(this.mainSplitLayout);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_VehicleTelemetryMain";
            this.Text = "Vehicle Telemetry";
            this.mainSplitLayout.Panel1.ResumeLayout(false);
            this.mainSplitLayout.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitLayout)).EndInit();
            this.mainSplitLayout.ResumeLayout(false);
            this.dataGroupBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox mapGroup;
        private System.Windows.Forms.SplitContainer mainSplitLayout;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuNetwork;
        private System.Windows.Forms.ToolStripMenuItem menuOptions;
        private System.Windows.Forms.ToolStripMenuItem menuItemMapOptions;
        private System.Windows.Forms.GroupBox dataGroupBox;
        private DataPanel dataPanel;
    }
}

