namespace VehicleTelemetry {
    partial class TelemetryControl {
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
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitLayout)).BeginInit();
            this.mainSplitLayout.Panel1.SuspendLayout();
            this.mainSplitLayout.Panel2.SuspendLayout();
            this.mainSplitLayout.SuspendLayout();
            this.dataGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapGroup
            // 
            this.mapGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapGroup.Location = new System.Drawing.Point(0, 0);
            this.mapGroup.Name = "mapGroup";
            this.mapGroup.Size = new System.Drawing.Size(514, 457);
            this.mapGroup.TabIndex = 1;
            this.mapGroup.TabStop = false;
            this.mapGroup.Text = "Viewport";
            // 
            // mainSplitLayout
            // 
            this.mainSplitLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitLayout.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.mainSplitLayout.Location = new System.Drawing.Point(0, 0);
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
            this.mainSplitLayout.Size = new System.Drawing.Size(718, 457);
            this.mainSplitLayout.SplitterDistance = 514;
            this.mainSplitLayout.TabIndex = 2;
            // 
            // dataGroupBox
            // 
            this.dataGroupBox.Controls.Add(this.dataPanel);
            this.dataGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGroupBox.Location = new System.Drawing.Point(0, 0);
            this.dataGroupBox.Name = "dataGroupBox";
            this.dataGroupBox.Size = new System.Drawing.Size(200, 457);
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
            this.dataPanel.Size = new System.Drawing.Size(194, 438);
            this.dataPanel.TabIndex = 0;
            // 
            // TelemetryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainSplitLayout);
            this.Name = "TelemetryControl";
            this.Size = new System.Drawing.Size(718, 457);
            this.mainSplitLayout.Panel1.ResumeLayout(false);
            this.mainSplitLayout.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitLayout)).EndInit();
            this.mainSplitLayout.ResumeLayout(false);
            this.dataGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox mapGroup;
        private System.Windows.Forms.SplitContainer mainSplitLayout;
        private System.Windows.Forms.GroupBox dataGroupBox;
        private DataPanel dataPanel;
    }
}

