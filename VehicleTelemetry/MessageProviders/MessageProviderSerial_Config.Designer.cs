namespace VehicleTelemetry {
    partial class MessageProviderSerial_Config {
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
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.labelBaud = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelParity = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.labelStop = new System.Windows.Forms.Label();
            this.portSelector = new System.Windows.Forms.ComboBox();
            this.baudSelector = new System.Windows.Forms.ComboBox();
            this.paritySelector = new System.Windows.Forms.ComboBox();
            this.dataBitsSelector = new System.Windows.Forms.TextBox();
            this.stopBitsSelector = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(54, 151);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(90, 23);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(150, 151);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // labelBaud
            // 
            this.labelBaud.AutoSize = true;
            this.labelBaud.Location = new System.Drawing.Point(3, 34);
            this.labelBaud.Name = "labelBaud";
            this.labelBaud.Size = new System.Drawing.Size(56, 13);
            this.labelBaud.TabIndex = 2;
            this.labelBaud.Text = "Baud rate:";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(3, 6);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 13);
            this.labelPort.TabIndex = 3;
            this.labelPort.Text = "Port:";
            // 
            // labelParity
            // 
            this.labelParity.AutoSize = true;
            this.labelParity.Location = new System.Drawing.Point(3, 62);
            this.labelParity.Name = "labelParity";
            this.labelParity.Size = new System.Drawing.Size(36, 13);
            this.labelParity.TabIndex = 4;
            this.labelParity.Text = "Parity:";
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(3, 90);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(52, 13);
            this.labelData.TabIndex = 5;
            this.labelData.Text = "Data bits:";
            // 
            // labelStop
            // 
            this.labelStop.AutoSize = true;
            this.labelStop.Location = new System.Drawing.Point(3, 117);
            this.labelStop.Name = "labelStop";
            this.labelStop.Size = new System.Drawing.Size(51, 13);
            this.labelStop.TabIndex = 6;
            this.labelStop.Text = "Stop bits:";
            // 
            // portSelector
            // 
            this.portSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.portSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portSelector.FormattingEnabled = true;
            this.portSelector.Location = new System.Drawing.Point(64, 3);
            this.portSelector.Name = "portSelector";
            this.portSelector.Size = new System.Drawing.Size(176, 21);
            this.portSelector.TabIndex = 7;
            // 
            // baudSelector
            // 
            this.baudSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baudSelector.FormattingEnabled = true;
            this.baudSelector.Items.AddRange(new object[] {
            "110",
            "300 \t",
            "600",
            "1200 \t",
            "2400",
            "4800 \t",
            "9600",
            "14400 \t",
            "19200",
            "28800 \t",
            "38400",
            "56000 \t",
            "57600",
            "115200"});
            this.baudSelector.Location = new System.Drawing.Point(64, 31);
            this.baudSelector.Name = "baudSelector";
            this.baudSelector.Size = new System.Drawing.Size(176, 21);
            this.baudSelector.TabIndex = 8;
            // 
            // paritySelector
            // 
            this.paritySelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paritySelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paritySelector.FormattingEnabled = true;
            this.paritySelector.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd",
            "Space",
            "Mark"});
            this.paritySelector.Location = new System.Drawing.Point(64, 59);
            this.paritySelector.Name = "paritySelector";
            this.paritySelector.Size = new System.Drawing.Size(176, 21);
            this.paritySelector.TabIndex = 9;
            // 
            // dataBitsSelector
            // 
            this.dataBitsSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataBitsSelector.Location = new System.Drawing.Point(64, 87);
            this.dataBitsSelector.Name = "dataBitsSelector";
            this.dataBitsSelector.Size = new System.Drawing.Size(176, 20);
            this.dataBitsSelector.TabIndex = 10;
            // 
            // stopBitsSelector
            // 
            this.stopBitsSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stopBitsSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopBitsSelector.FormattingEnabled = true;
            this.stopBitsSelector.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.stopBitsSelector.Location = new System.Drawing.Point(64, 114);
            this.stopBitsSelector.Name = "stopBitsSelector";
            this.stopBitsSelector.Size = new System.Drawing.Size(176, 21);
            this.stopBitsSelector.TabIndex = 11;
            // 
            // MessageProviderSerial_Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stopBitsSelector);
            this.Controls.Add(this.dataBitsSelector);
            this.Controls.Add(this.paritySelector);
            this.Controls.Add(this.baudSelector);
            this.Controls.Add(this.portSelector);
            this.Controls.Add(this.labelStop);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.labelParity);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.labelBaud);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.MinimumSize = new System.Drawing.Size(200, 176);
            this.Name = "MessageProviderSerial_Config";
            this.Size = new System.Drawing.Size(243, 176);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label labelBaud;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelParity;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Label labelStop;
        private System.Windows.Forms.ComboBox portSelector;
        private System.Windows.Forms.ComboBox baudSelector;
        private System.Windows.Forms.ComboBox paritySelector;
        private System.Windows.Forms.TextBox dataBitsSelector;
        private System.Windows.Forms.ComboBox stopBitsSelector;
    }
}
