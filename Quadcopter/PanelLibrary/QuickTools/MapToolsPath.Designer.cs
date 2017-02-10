namespace VehicleTelemetryApp {
    partial class MapToolsPath {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.pathName = new System.Windows.Forms.Label();
			this.clearPoints = new System.Windows.Forms.Button();
			this.colorSelector = new System.Windows.Forms.Button();
			this.visibilityToggle = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pathName
			// 
			this.pathName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pathName.AutoSize = true;
			this.pathName.Location = new System.Drawing.Point(1, 1);
			this.pathName.Margin = new System.Windows.Forms.Padding(1);
			this.pathName.Name = "pathName";
			this.pathName.Size = new System.Drawing.Size(35, 13);
			this.pathName.TabIndex = 0;
			this.pathName.Text = "Name";
			// 
			// clearPoints
			// 
			this.clearPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.clearPoints.AutoSize = true;
			this.clearPoints.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.clearPoints.Location = new System.Drawing.Point(136, 1);
			this.clearPoints.Margin = new System.Windows.Forms.Padding(1);
			this.clearPoints.Name = "clearPoints";
			this.clearPoints.Size = new System.Drawing.Size(41, 23);
			this.clearPoints.TabIndex = 1;
			this.clearPoints.Text = "Clear";
			this.clearPoints.UseVisualStyleBackColor = true;
			this.clearPoints.Click += new System.EventHandler(this.clearPoints_Click);
			// 
			// colorSelector
			// 
			this.colorSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.colorSelector.AutoSize = true;
			this.colorSelector.Location = new System.Drawing.Point(93, 1);
			this.colorSelector.Margin = new System.Windows.Forms.Padding(1);
			this.colorSelector.Name = "colorSelector";
			this.colorSelector.Size = new System.Drawing.Size(41, 23);
			this.colorSelector.TabIndex = 2;
			this.colorSelector.Text = "Color";
			this.colorSelector.UseVisualStyleBackColor = true;
			this.colorSelector.Click += new System.EventHandler(this.colorSelector_Click);
			// 
			// visibilityToggle
			// 
			this.visibilityToggle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.visibilityToggle.AutoSize = true;
			this.visibilityToggle.Location = new System.Drawing.Point(38, 1);
			this.visibilityToggle.Margin = new System.Windows.Forms.Padding(1);
			this.visibilityToggle.Name = "visibilityToggle";
			this.visibilityToggle.Size = new System.Drawing.Size(53, 17);
			this.visibilityToggle.TabIndex = 3;
			this.visibilityToggle.Text = "Show";
			this.visibilityToggle.UseVisualStyleBackColor = true;
			this.visibilityToggle.CheckedChanged += new System.EventHandler(this.visibilityToggle_CheckedChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.pathName, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.clearPoints, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.colorSelector, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.visibilityToggle, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(178, 27);
			this.tableLayoutPanel1.TabIndex = 4;
			// 
			// MapToolsPath
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(180, 28);
			this.Name = "MapToolsPath";
			this.Size = new System.Drawing.Size(180, 32);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pathName;
        private System.Windows.Forms.Button clearPoints;
        private System.Windows.Forms.Button colorSelector;
		private System.Windows.Forms.CheckBox visibilityToggle;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}
