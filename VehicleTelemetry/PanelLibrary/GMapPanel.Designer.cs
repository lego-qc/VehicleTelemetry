namespace VehicleTelemetry {
    partial class GMapPanel {
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
            this.mapMainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mapParamsControlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.mapParamZoomOut = new System.Windows.Forms.Button();
            this.mapParamsZoomIn = new System.Windows.Forms.Button();
            this.mapParamsLabelLat = new System.Windows.Forms.Label();
            this.mapParamsLabelLong = new System.Windows.Forms.Label();
            this.mapParamsLat = new System.Windows.Forms.TextBox();
            this.mapParamsLong = new System.Windows.Forms.TextBox();
            this.mapParamsOptions = new System.Windows.Forms.Button();
            this.mapDisplayPanel = new System.Windows.Forms.Panel();
            this.mapMainPanel.SuspendLayout();
            this.mapParamsControlLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapMainPanel
            // 
            this.mapMainPanel.ColumnCount = 1;
            this.mapMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mapMainPanel.Controls.Add(this.mapParamsControlLayout, 0, 1);
            this.mapMainPanel.Controls.Add(this.mapDisplayPanel, 0, 0);
            this.mapMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapMainPanel.Location = new System.Drawing.Point(0, 0);
            this.mapMainPanel.Name = "mapMainPanel";
            this.mapMainPanel.RowCount = 2;
            this.mapMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mapMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mapMainPanel.Size = new System.Drawing.Size(499, 277);
            this.mapMainPanel.TabIndex = 0;
            // 
            // mapParamsControlLayout
            // 
            this.mapParamsControlLayout.ColumnCount = 4;
            this.mapParamsControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.mapParamsControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.mapParamsControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.mapParamsControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mapParamsControlLayout.Controls.Add(this.mapParamZoomOut, 2, 1);
            this.mapParamsControlLayout.Controls.Add(this.mapParamsZoomIn, 2, 0);
            this.mapParamsControlLayout.Controls.Add(this.mapParamsLabelLat, 0, 0);
            this.mapParamsControlLayout.Controls.Add(this.mapParamsLabelLong, 0, 1);
            this.mapParamsControlLayout.Controls.Add(this.mapParamsLat, 1, 0);
            this.mapParamsControlLayout.Controls.Add(this.mapParamsLong, 1, 1);
            this.mapParamsControlLayout.Controls.Add(this.mapParamsOptions, 3, 0);
            this.mapParamsControlLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mapParamsControlLayout.Location = new System.Drawing.Point(3, 222);
            this.mapParamsControlLayout.MaximumSize = new System.Drawing.Size(0, 52);
            this.mapParamsControlLayout.MinimumSize = new System.Drawing.Size(0, 52);
            this.mapParamsControlLayout.Name = "mapParamsControlLayout";
            this.mapParamsControlLayout.RowCount = 2;
            this.mapParamsControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.mapParamsControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.mapParamsControlLayout.Size = new System.Drawing.Size(493, 52);
            this.mapParamsControlLayout.TabIndex = 1;
            // 
            // mapParamZoomOut
            // 
            this.mapParamZoomOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapParamZoomOut.Location = new System.Drawing.Point(163, 29);
            this.mapParamZoomOut.Name = "mapParamZoomOut";
            this.mapParamZoomOut.Size = new System.Drawing.Size(74, 20);
            this.mapParamZoomOut.TabIndex = 0;
            this.mapParamZoomOut.Text = "Zoom Out";
            this.mapParamZoomOut.UseVisualStyleBackColor = true;
            this.mapParamZoomOut.Click += new System.EventHandler(this.mapParamZoomOut_Click);
            // 
            // mapParamsZoomIn
            // 
            this.mapParamsZoomIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapParamsZoomIn.Location = new System.Drawing.Point(163, 3);
            this.mapParamsZoomIn.Name = "mapParamsZoomIn";
            this.mapParamsZoomIn.Size = new System.Drawing.Size(74, 20);
            this.mapParamsZoomIn.TabIndex = 1;
            this.mapParamsZoomIn.Text = "Zoom In";
            this.mapParamsZoomIn.UseVisualStyleBackColor = true;
            this.mapParamsZoomIn.Click += new System.EventHandler(this.mapParamsZoomIn_Click);
            // 
            // mapParamsLabelLat
            // 
            this.mapParamsLabelLat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapParamsLabelLat.AutoSize = true;
            this.mapParamsLabelLat.Location = new System.Drawing.Point(23, 0);
            this.mapParamsLabelLat.Name = "mapParamsLabelLat";
            this.mapParamsLabelLat.Size = new System.Drawing.Size(54, 26);
            this.mapParamsLabelLat.TabIndex = 2;
            this.mapParamsLabelLat.Text = "Latitude =";
            this.mapParamsLabelLat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mapParamsLabelLong
            // 
            this.mapParamsLabelLong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapParamsLabelLong.AutoSize = true;
            this.mapParamsLabelLong.Location = new System.Drawing.Point(14, 26);
            this.mapParamsLabelLong.Name = "mapParamsLabelLong";
            this.mapParamsLabelLong.Size = new System.Drawing.Size(63, 26);
            this.mapParamsLabelLong.TabIndex = 3;
            this.mapParamsLabelLong.Text = "Longitude =";
            this.mapParamsLabelLong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mapParamsLat
            // 
            this.mapParamsLat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapParamsLat.Location = new System.Drawing.Point(83, 3);
            this.mapParamsLat.Name = "mapParamsLat";
            this.mapParamsLat.Size = new System.Drawing.Size(74, 20);
            this.mapParamsLat.TabIndex = 4;
            this.mapParamsLat.Text = "-";
            // 
            // mapParamsLong
            // 
            this.mapParamsLong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapParamsLong.Location = new System.Drawing.Point(83, 29);
            this.mapParamsLong.Name = "mapParamsLong";
            this.mapParamsLong.Size = new System.Drawing.Size(74, 20);
            this.mapParamsLong.TabIndex = 5;
            this.mapParamsLong.Text = "-";
            // 
            // mapParamsOptions
            // 
            this.mapParamsOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.mapParamsOptions.Location = new System.Drawing.Point(415, 3);
            this.mapParamsOptions.Name = "mapParamsOptions";
            this.mapParamsControlLayout.SetRowSpan(this.mapParamsOptions, 2);
            this.mapParamsOptions.Size = new System.Drawing.Size(75, 46);
            this.mapParamsOptions.TabIndex = 6;
            this.mapParamsOptions.Text = "Configure...";
            this.mapParamsOptions.UseVisualStyleBackColor = true;
            this.mapParamsOptions.Click += new System.EventHandler(this.mapParamsOptions_Click);
            // 
            // mapDisplayPanel
            // 
            this.mapDisplayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapDisplayPanel.Location = new System.Drawing.Point(3, 3);
            this.mapDisplayPanel.Name = "mapDisplayPanel";
            this.mapDisplayPanel.Size = new System.Drawing.Size(493, 213);
            this.mapDisplayPanel.TabIndex = 1;
            // 
            // GMapPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 277);
            this.Controls.Add(this.mapMainPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "GMapPanel";
            this.mapMainPanel.ResumeLayout(false);
            this.mapParamsControlLayout.ResumeLayout(false);
            this.mapParamsControlLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel mapMainPanel;
        private System.Windows.Forms.TableLayoutPanel mapParamsControlLayout;
        private System.Windows.Forms.Button mapParamZoomOut;
        private System.Windows.Forms.Button mapParamsZoomIn;
        private System.Windows.Forms.Label mapParamsLabelLat;
        private System.Windows.Forms.Label mapParamsLabelLong;
        private System.Windows.Forms.TextBox mapParamsLat;
        private System.Windows.Forms.TextBox mapParamsLong;
        private System.Windows.Forms.Button mapParamsOptions;
        private System.Windows.Forms.Panel mapDisplayPanel;
    }
}
