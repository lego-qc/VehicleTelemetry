namespace VehicleTelemetryApp {
    partial class MapToolsItem {
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
			this.mapName = new System.Windows.Forms.Label();
			this.showPathsButton = new System.Windows.Forms.Button();
			this.showConfigureButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.follow = new System.Windows.Forms.CheckBox();
			this.pathContainer = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mapName
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.mapName, 3);
			this.mapName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mapName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.mapName.Location = new System.Drawing.Point(3, 0);
			this.mapName.Name = "mapName";
			this.mapName.Size = new System.Drawing.Size(194, 26);
			this.mapName.TabIndex = 1;
			this.mapName.Text = "Map Title";
			this.mapName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// showPathsButton
			// 
			this.showPathsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.showPathsButton.AutoSize = true;
			this.showPathsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.showPathsButton.Location = new System.Drawing.Point(137, 28);
			this.showPathsButton.Margin = new System.Windows.Forms.Padding(2);
			this.showPathsButton.Name = "showPathsButton";
			this.showPathsButton.Size = new System.Drawing.Size(61, 23);
			this.showPathsButton.TabIndex = 2;
			this.showPathsButton.Text = "Paths";
			this.showPathsButton.UseVisualStyleBackColor = true;
			this.showPathsButton.Click += new System.EventHandler(this.showPathsButton_Click);
			// 
			// showConfigureButton
			// 
			this.showConfigureButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.showConfigureButton.AutoSize = true;
			this.showConfigureButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.showConfigureButton.Location = new System.Drawing.Point(62, 28);
			this.showConfigureButton.Margin = new System.Windows.Forms.Padding(2);
			this.showConfigureButton.Name = "showConfigureButton";
			this.showConfigureButton.Size = new System.Drawing.Size(71, 23);
			this.showConfigureButton.TabIndex = 3;
			this.showConfigureButton.Text = "Configure...";
			this.showConfigureButton.UseVisualStyleBackColor = true;
			this.showConfigureButton.Click += new System.EventHandler(this.showConfigureButton_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.showConfigureButton, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.mapName, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.showPathsButton, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.follow, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 55);
			this.tableLayoutPanel1.TabIndex = 4;
			// 
			// follow
			// 
			this.follow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.follow.AutoSize = true;
			this.follow.Location = new System.Drawing.Point(2, 28);
			this.follow.Margin = new System.Windows.Forms.Padding(2);
			this.follow.Name = "follow";
			this.follow.Size = new System.Drawing.Size(56, 17);
			this.follow.TabIndex = 4;
			this.follow.Text = "Follow";
			this.follow.UseVisualStyleBackColor = true;
			this.follow.CheckedChanged += new System.EventHandler(this.follow_CheckedChanged);
			// 
			// pathContainer
			// 
			this.pathContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pathContainer.AutoSize = true;
			this.pathContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.pathContainer.Location = new System.Drawing.Point(3, 58);
			this.pathContainer.Name = "pathContainer";
			this.pathContainer.Size = new System.Drawing.Size(194, 10);
			this.pathContainer.TabIndex = 5;
			// 
			// MapToolsItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.pathContainer);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(200, 56);
			this.Name = "MapToolsItem";
			this.Size = new System.Drawing.Size(200, 71);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label mapName;
        private System.Windows.Forms.Button showPathsButton;
        private System.Windows.Forms.Button showConfigureButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox follow;
		private System.Windows.Forms.FlowLayoutPanel pathContainer;
	}
}
