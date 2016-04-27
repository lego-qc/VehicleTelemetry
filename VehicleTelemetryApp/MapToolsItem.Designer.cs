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
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showPathsMap
            // 
            this.showPathsMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showPathsMap.FormattingEnabled = true;
            this.showPathsMap.Location = new System.Drawing.Point(3, 51);
            this.showPathsMap.Name = "showPathsMap";
            this.showPathsMap.Size = new System.Drawing.Size(221, 34);
            this.showPathsMap.TabIndex = 0;
            this.showPathsMap.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.showPathsMap_ItemCheck);
            // 
            // mapName
            // 
            this.mapName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mapName.Location = new System.Drawing.Point(3, 0);
            this.mapName.Name = "mapName";
            this.mapName.Size = new System.Drawing.Size(221, 19);
            this.mapName.TabIndex = 1;
            this.mapName.Text = "Map Title";
            this.mapName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // showPathsButton
            // 
            this.showPathsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showPathsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.showPathsButton.Location = new System.Drawing.Point(116, 3);
            this.showPathsButton.Name = "showPathsButton";
            this.showPathsButton.Size = new System.Drawing.Size(108, 23);
            this.showPathsButton.TabIndex = 2;
            this.showPathsButton.Text = "Paths";
            this.showPathsButton.UseVisualStyleBackColor = true;
            this.showPathsButton.Click += new System.EventHandler(this.showPathsButton_Click);
            // 
            // showConfigureButton
            // 
            this.showConfigureButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showConfigureButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.showConfigureButton.Location = new System.Drawing.Point(3, 3);
            this.showConfigureButton.Name = "showConfigureButton";
            this.showConfigureButton.Size = new System.Drawing.Size(107, 23);
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
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.showConfigureButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.showPathsButton, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 19);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(227, 29);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // MapToolsItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mapName);
            this.Controls.Add(this.showPathsMap);
            this.Name = "MapToolsItem";
            this.Size = new System.Drawing.Size(227, 107);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox showPathsMap;
        private System.Windows.Forms.Label mapName;
        private System.Windows.Forms.Button showPathsButton;
        private System.Windows.Forms.Button showConfigureButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
