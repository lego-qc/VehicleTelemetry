namespace VehicleTelemetryApp {
    partial class ConnectionForm {
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
            this.mainSplitter = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.providerSelector = new System.Windows.Forms.ComboBox();
            this.providerSelectorLabel = new System.Windows.Forms.Label();
            this.stateIndicator = new System.Windows.Forms.PictureBox();
            this.actionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).BeginInit();
            this.mainSplitter.Panel1.SuspendLayout();
            this.mainSplitter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // mainSplitter
            // 
            this.mainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitter.IsSplitterFixed = true;
            this.mainSplitter.Location = new System.Drawing.Point(0, 0);
            this.mainSplitter.Name = "mainSplitter";
            this.mainSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitter.Panel1
            // 
            this.mainSplitter.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.mainSplitter.Size = new System.Drawing.Size(409, 241);
            this.mainSplitter.SplitterDistance = 33;
            this.mainSplitter.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.providerSelector, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.providerSelectorLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.stateIndicator, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.actionButton, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(409, 33);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // providerSelector
            // 
            this.providerSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.providerSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.providerSelector.FormattingEnabled = true;
            this.providerSelector.Location = new System.Drawing.Point(117, 6);
            this.providerSelector.Name = "providerSelector";
            this.providerSelector.Size = new System.Drawing.Size(168, 21);
            this.providerSelector.TabIndex = 1;
            this.providerSelector.SelectedIndexChanged += new System.EventHandler(this.providerSelector_SelectedIndexChanged);
            // 
            // providerSelectorLabel
            // 
            this.providerSelectorLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.providerSelectorLabel.AutoSize = true;
            this.providerSelectorLabel.Location = new System.Drawing.Point(3, 10);
            this.providerSelectorLabel.Name = "providerSelectorLabel";
            this.providerSelectorLabel.Size = new System.Drawing.Size(108, 13);
            this.providerSelectorLabel.TabIndex = 0;
            this.providerSelectorLabel.Text = "Connection interface:";
            this.providerSelectorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stateIndicator
            // 
            this.stateIndicator.Image = global::VehicleTelemetryApp.Properties.Resources.ConnectionForm_Disconnected;
            this.stateIndicator.Location = new System.Drawing.Point(372, 3);
            this.stateIndicator.Name = "stateIndicator";
            this.stateIndicator.Size = new System.Drawing.Size(34, 27);
            this.stateIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.stateIndicator.TabIndex = 2;
            this.stateIndicator.TabStop = false;
            // 
            // actionButton
            // 
            this.actionButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.actionButton.Location = new System.Drawing.Point(291, 5);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(75, 23);
            this.actionButton.TabIndex = 3;
            this.actionButton.Text = "Listen";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click);
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 241);
            this.Controls.Add(this.mainSplitter);
            this.MinimumSize = new System.Drawing.Size(400, 70);
            this.Name = "ConnectionForm";
            this.Text = "Connection Settings";
            this.mainSplitter.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).EndInit();
            this.mainSplitter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox providerSelector;
        private System.Windows.Forms.Label providerSelectorLabel;
        private System.Windows.Forms.PictureBox stateIndicator;
        private System.Windows.Forms.Button actionButton;
    }
}