namespace VehicleTelemetryApp {
    partial class MapTools {
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
            this.mapFlowContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.mapFlowContainer.AutoSize = true;
            this.mapFlowContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mapFlowContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapFlowContainer.Location = new System.Drawing.Point(0, 0);
            this.mapFlowContainer.Name = "flowLayoutPanel1";
            this.mapFlowContainer.Size = new System.Drawing.Size(282, 145);
            this.mapFlowContainer.TabIndex = 0;
            // 
            // MapTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mapFlowContainer);
            this.Name = "MapTools";
            this.Size = new System.Drawing.Size(282, 145);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel mapFlowContainer;
    }
}
