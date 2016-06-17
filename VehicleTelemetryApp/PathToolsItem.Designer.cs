namespace VehicleTelemetryApp {
    partial class PathToolsItem {
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
            this.SuspendLayout();
            // 
            // pathName
            // 
            this.pathName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathName.Location = new System.Drawing.Point(3, 8);
            this.pathName.Name = "pathName";
            this.pathName.Size = new System.Drawing.Size(44, 18);
            this.pathName.TabIndex = 0;
            this.pathName.Text = "Name";
            // 
            // clearPoints
            // 
            this.clearPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearPoints.AutoSize = true;
            this.clearPoints.Location = new System.Drawing.Point(103, 3);
            this.clearPoints.Name = "clearPoints";
            this.clearPoints.Size = new System.Drawing.Size(44, 23);
            this.clearPoints.TabIndex = 1;
            this.clearPoints.Text = "Clear";
            this.clearPoints.UseVisualStyleBackColor = true;
            this.clearPoints.Click += new System.EventHandler(this.clearPoints_Click);
            // 
            // colorSelector
            // 
            this.colorSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.colorSelector.AutoSize = true;
            this.colorSelector.Location = new System.Drawing.Point(53, 3);
            this.colorSelector.Name = "colorSelector";
            this.colorSelector.Size = new System.Drawing.Size(44, 23);
            this.colorSelector.TabIndex = 2;
            this.colorSelector.Text = "Color";
            this.colorSelector.UseVisualStyleBackColor = true;
            this.colorSelector.Click += new System.EventHandler(this.colorSelector_Click);
            // 
            // PathToolsItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorSelector);
            this.Controls.Add(this.clearPoints);
            this.Controls.Add(this.pathName);
            this.MinimumSize = new System.Drawing.Size(150, 28);
            this.Name = "PathToolsItem";
            this.Size = new System.Drawing.Size(150, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pathName;
        private System.Windows.Forms.Button clearPoints;
        private System.Windows.Forms.Button colorSelector;
    }
}
