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
            this.showPathsMap = new System.Windows.Forms.CheckedListBox();
            this.mapName = new System.Windows.Forms.Label();
            this.showPathsButton = new System.Windows.Forms.Button();
            this.showConfigureButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.follow = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showPathsMap
            // 
            this.showPathsMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showPathsMap.FormattingEnabled = true;
            this.showPathsMap.Location = new System.Drawing.Point(3, 58);
            this.showPathsMap.Name = "showPathsMap";
            this.showPathsMap.Size = new System.Drawing.Size(221, 34);
            this.showPathsMap.TabIndex = 0;
            this.showPathsMap.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.showPathsMap_ItemCheck);
            // 
            // mapName
            // 
            this.mapName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mapName.Location = new System.Drawing.Point(3, 0);
            this.mapName.Name = "mapName";
            this.tableLayoutPanel1.SetRowSpan(this.mapName, 2);
            this.mapName.Size = new System.Drawing.Size(85, 55);
            this.mapName.TabIndex = 1;
            this.mapName.Text = "Map Title";
            this.mapName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // showPathsButton
            // 
            this.showPathsButton.AutoSize = true;
            this.showPathsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.showPathsButton, 2);
            this.showPathsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.showPathsButton.Location = new System.Drawing.Point(93, 28);
            this.showPathsButton.Margin = new System.Windows.Forms.Padding(2);
            this.showPathsButton.Name = "showPathsButton";
            this.showPathsButton.Size = new System.Drawing.Size(132, 23);
            this.showPathsButton.TabIndex = 2;
            this.showPathsButton.Text = "Paths";
            this.showPathsButton.UseVisualStyleBackColor = true;
            this.showPathsButton.Click += new System.EventHandler(this.showPathsButton_Click);
            // 
            // showConfigureButton
            // 
            this.showConfigureButton.AutoSize = true;
            this.showConfigureButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showConfigureButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.showConfigureButton.Location = new System.Drawing.Point(93, 2);
            this.showConfigureButton.Margin = new System.Windows.Forms.Padding(2);
            this.showConfigureButton.Name = "showConfigureButton";
            this.showConfigureButton.Size = new System.Drawing.Size(72, 22);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.showConfigureButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mapName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.showPathsButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.follow, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(227, 55);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // follow
            // 
            this.follow.AutoSize = true;
            this.follow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.follow.Location = new System.Drawing.Point(169, 2);
            this.follow.Margin = new System.Windows.Forms.Padding(2);
            this.follow.Name = "follow";
            this.follow.Size = new System.Drawing.Size(56, 22);
            this.follow.TabIndex = 4;
            this.follow.Text = "Follow";
            this.follow.UseVisualStyleBackColor = true;
            this.follow.CheckedChanged += new System.EventHandler(this.follow_CheckedChanged);
            // 
            // MapToolsItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.showPathsMap);
            this.Name = "MapToolsItem";
            this.Size = new System.Drawing.Size(227, 107);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox showPathsMap;
        private System.Windows.Forms.Label mapName;
        private System.Windows.Forms.Button showPathsButton;
        private System.Windows.Forms.Button showConfigureButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox follow;
    }
}
