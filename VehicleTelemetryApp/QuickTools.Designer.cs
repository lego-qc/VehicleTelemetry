namespace VehicleTelemetryApp {
    partial class QuickTools {
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
            this.mapsBox = new System.Windows.Forms.GroupBox();
            this.mapTools = new VehicleTelemetryApp.MapTools();
            this.pathsBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.mapsBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapsBox
            // 
            this.mapsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapsBox.AutoSize = true;
            this.mapsBox.Controls.Add(this.mapTools);
            this.mapsBox.Location = new System.Drawing.Point(3, 112);
            this.mapsBox.Name = "mapsBox";
            this.mapsBox.Size = new System.Drawing.Size(243, 127);
            this.mapsBox.TabIndex = 0;
            this.mapsBox.TabStop = false;
            this.mapsBox.Text = "Maps";
            // 
            // mapTools
            // 
            this.mapTools.AutoSize = true;
            this.mapTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapTools.Location = new System.Drawing.Point(3, 16);
            this.mapTools.Name = "mapTools";
            this.mapTools.Size = new System.Drawing.Size(237, 108);
            this.mapTools.TabIndex = 0;
            // 
            // pathsBox
            // 
            this.pathsBox.Location = new System.Drawing.Point(3, 3);
            this.pathsBox.Name = "pathsBox";
            this.pathsBox.Size = new System.Drawing.Size(243, 103);
            this.pathsBox.TabIndex = 1;
            this.pathsBox.TabStop = false;
            this.pathsBox.Text = "Paths";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.pathsBox);
            this.flowLayoutPanel1.Controls.Add(this.mapsBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(258, 469);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // QuickTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 469);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "QuickTools";
            this.mapsBox.ResumeLayout(false);
            this.mapsBox.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox mapsBox;
        private System.Windows.Forms.GroupBox pathsBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MapTools mapTools;
    }
}
