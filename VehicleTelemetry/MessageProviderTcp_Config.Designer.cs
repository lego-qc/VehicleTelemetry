namespace VehicleTelemetry {
    partial class MessageProviderTcp_Config {
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
            this.portButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.portTexBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // portButton
            // 
            this.portButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.portButton.Location = new System.Drawing.Point(266, 1);
            this.portButton.Name = "portButton";
            this.portButton.Size = new System.Drawing.Size(75, 23);
            this.portButton.TabIndex = 0;
            this.portButton.Text = "Set port";
            this.portButton.UseVisualStyleBackColor = true;
            this.portButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // portTexBox
            // 
            this.portTexBox.Location = new System.Drawing.Point(38, 3);
            this.portTexBox.Name = "portTexBox";
            this.portTexBox.Size = new System.Drawing.Size(100, 20);
            this.portTexBox.TabIndex = 2;
            this.portTexBox.Text = "5630";
            // 
            // MessageProviderTcp_Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.portTexBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portButton);
            this.Name = "MessageProviderTcp_Config";
            this.Size = new System.Drawing.Size(344, 96);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button portButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox portTexBox;
    }
}
