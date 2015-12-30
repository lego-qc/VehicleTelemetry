namespace QCTracker {
    partial class Form_MapOptions {
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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.confirmPanel = new System.Windows.Forms.Panel();
            this.confirmCancel = new System.Windows.Forms.Button();
            this.confirmOk = new System.Windows.Forms.Button();
            this.confirmSeparator = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.browseCacheLocation = new System.Windows.Forms.Button();
            this.cacheLocationLabel = new System.Windows.Forms.Label();
            this.currentCacheLocation = new System.Windows.Forms.TextBox();
            this.emptyCache = new System.Windows.Forms.Button();
            this.cacheModeSelector = new System.Windows.Forms.ComboBox();
            this.cacheModeLabel = new System.Windows.Forms.Label();
            this.mapProviderLable = new System.Windows.Forms.Label();
            this.mapProviderSelector = new System.Windows.Forms.ComboBox();
            this.mainLayout.SuspendLayout();
            this.confirmPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.confirmPanel, 0, 2);
            this.mainLayout.Controls.Add(this.confirmSeparator, 0, 1);
            this.mainLayout.Controls.Add(this.panel1, 0, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.Size = new System.Drawing.Size(348, 231);
            this.mainLayout.TabIndex = 1;
            // 
            // confirmPanel
            // 
            this.confirmPanel.AutoSize = true;
            this.confirmPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.confirmPanel.Controls.Add(this.confirmCancel);
            this.confirmPanel.Controls.Add(this.confirmOk);
            this.confirmPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.confirmPanel.Location = new System.Drawing.Point(3, 199);
            this.confirmPanel.Name = "confirmPanel";
            this.confirmPanel.Size = new System.Drawing.Size(342, 29);
            this.confirmPanel.TabIndex = 1;
            // 
            // confirmCancel
            // 
            this.confirmCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmCancel.Location = new System.Drawing.Point(264, 3);
            this.confirmCancel.Name = "confirmCancel";
            this.confirmCancel.Size = new System.Drawing.Size(75, 23);
            this.confirmCancel.TabIndex = 1;
            this.confirmCancel.Text = "Cancel";
            this.confirmCancel.UseVisualStyleBackColor = true;
            this.confirmCancel.Click += new System.EventHandler(this.confirmCancel_Click);
            // 
            // confirmOk
            // 
            this.confirmOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmOk.Location = new System.Drawing.Point(183, 3);
            this.confirmOk.Name = "confirmOk";
            this.confirmOk.Size = new System.Drawing.Size(75, 23);
            this.confirmOk.TabIndex = 0;
            this.confirmOk.Text = "Ok";
            this.confirmOk.UseVisualStyleBackColor = true;
            this.confirmOk.Click += new System.EventHandler(this.confirmOk_Click);
            // 
            // confirmSeparator
            // 
            this.confirmSeparator.AutoSize = true;
            this.confirmSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.confirmSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.confirmSeparator.Location = new System.Drawing.Point(3, 194);
            this.confirmSeparator.MaximumSize = new System.Drawing.Size(0, 2);
            this.confirmSeparator.MinimumSize = new System.Drawing.Size(0, 2);
            this.confirmSeparator.Name = "confirmSeparator";
            this.confirmSeparator.Size = new System.Drawing.Size(342, 2);
            this.confirmSeparator.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.browseCacheLocation);
            this.panel1.Controls.Add(this.cacheLocationLabel);
            this.panel1.Controls.Add(this.currentCacheLocation);
            this.panel1.Controls.Add(this.emptyCache);
            this.panel1.Controls.Add(this.cacheModeSelector);
            this.panel1.Controls.Add(this.cacheModeLabel);
            this.panel1.Controls.Add(this.mapProviderLable);
            this.panel1.Controls.Add(this.mapProviderSelector);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 188);
            this.panel1.TabIndex = 3;
            // 
            // browseCacheLocation
            // 
            this.browseCacheLocation.Location = new System.Drawing.Point(251, 91);
            this.browseCacheLocation.Name = "browseCacheLocation";
            this.browseCacheLocation.Size = new System.Drawing.Size(29, 20);
            this.browseCacheLocation.TabIndex = 7;
            this.browseCacheLocation.Text = "...";
            this.browseCacheLocation.UseVisualStyleBackColor = true;
            // 
            // cacheLocationLabel
            // 
            this.cacheLocationLabel.AutoSize = true;
            this.cacheLocationLabel.Location = new System.Drawing.Point(10, 95);
            this.cacheLocationLabel.Name = "cacheLocationLabel";
            this.cacheLocationLabel.Size = new System.Drawing.Size(81, 13);
            this.cacheLocationLabel.TabIndex = 6;
            this.cacheLocationLabel.Text = "Cache location:";
            // 
            // currentCacheLocation
            // 
            this.currentCacheLocation.Location = new System.Drawing.Point(97, 91);
            this.currentCacheLocation.Name = "currentCacheLocation";
            this.currentCacheLocation.Size = new System.Drawing.Size(147, 20);
            this.currentCacheLocation.TabIndex = 5;
            this.currentCacheLocation.Text = "invalid";
            // 
            // emptyCache
            // 
            this.emptyCache.Location = new System.Drawing.Point(13, 62);
            this.emptyCache.Name = "emptyCache";
            this.emptyCache.Size = new System.Drawing.Size(267, 23);
            this.emptyCache.TabIndex = 4;
            this.emptyCache.Text = "Empty Cache";
            this.emptyCache.UseVisualStyleBackColor = true;
            this.emptyCache.Click += new System.EventHandler(this.emptyCache_Click);
            // 
            // cacheModeSelector
            // 
            this.cacheModeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cacheModeSelector.FormattingEnabled = true;
            this.cacheModeSelector.Items.AddRange(new object[] {
            "Cache only",
            "Network Only",
            "Both (fastest)"});
            this.cacheModeSelector.Location = new System.Drawing.Point(88, 35);
            this.cacheModeSelector.Name = "cacheModeSelector";
            this.cacheModeSelector.Size = new System.Drawing.Size(192, 21);
            this.cacheModeSelector.TabIndex = 3;
            // 
            // cacheModeLabel
            // 
            this.cacheModeLabel.AutoSize = true;
            this.cacheModeLabel.Location = new System.Drawing.Point(10, 38);
            this.cacheModeLabel.Name = "cacheModeLabel";
            this.cacheModeLabel.Size = new System.Drawing.Size(70, 13);
            this.cacheModeLabel.TabIndex = 2;
            this.cacheModeLabel.Text = "Cache mode:";
            // 
            // mapProviderLable
            // 
            this.mapProviderLable.AutoSize = true;
            this.mapProviderLable.Location = new System.Drawing.Point(10, 10);
            this.mapProviderLable.Name = "mapProviderLable";
            this.mapProviderLable.Size = new System.Drawing.Size(72, 13);
            this.mapProviderLable.TabIndex = 1;
            this.mapProviderLable.Text = "Map provider:";
            // 
            // mapProviderSelector
            // 
            this.mapProviderSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapProviderSelector.FormattingEnabled = true;
            this.mapProviderSelector.Location = new System.Drawing.Point(88, 7);
            this.mapProviderSelector.Name = "mapProviderSelector";
            this.mapProviderSelector.Size = new System.Drawing.Size(192, 21);
            this.mapProviderSelector.Sorted = true;
            this.mapProviderSelector.TabIndex = 0;
            // 
            // Form_MapOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 231);
            this.Controls.Add(this.mainLayout);
            this.Name = "Form_MapOptions";
            this.Text = "Map View Options";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.confirmPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel confirmPanel;
        private System.Windows.Forms.Button confirmCancel;
        private System.Windows.Forms.Button confirmOk;
        private System.Windows.Forms.Label confirmSeparator;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cacheModeSelector;
        private System.Windows.Forms.Label cacheModeLabel;
        private System.Windows.Forms.Label mapProviderLable;
        private System.Windows.Forms.ComboBox mapProviderSelector;
        private System.Windows.Forms.Button emptyCache;
        private System.Windows.Forms.Button browseCacheLocation;
        private System.Windows.Forms.Label cacheLocationLabel;
        private System.Windows.Forms.TextBox currentCacheLocation;
    }
}