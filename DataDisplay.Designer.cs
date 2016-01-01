namespace QCTracker {
    partial class DataDisplay {
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
            this.mainTable = new System.Windows.Forms.TableLayoutPanel();
            this.titleGroup = new System.Windows.Forms.GroupBox();
            this.titleGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTable
            // 
            this.mainTable.ColumnCount = 3;
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainTable.Location = new System.Drawing.Point(3, 16);
            this.mainTable.Name = "mainTable";
            this.mainTable.RowCount = 1;
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.mainTable.Size = new System.Drawing.Size(248, 26);
            this.mainTable.TabIndex = 0;
            // 
            // titleGroup
            // 
            this.titleGroup.Controls.Add(this.mainTable);
            this.titleGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleGroup.Location = new System.Drawing.Point(0, 0);
            this.titleGroup.Name = "titleGroup";
            this.titleGroup.Size = new System.Drawing.Size(254, 100);
            this.titleGroup.TabIndex = 1;
            this.titleGroup.TabStop = false;
            this.titleGroup.Text = "groupBox1";
            // 
            // DataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleGroup);
            this.Name = "DataDisplay";
            this.Size = new System.Drawing.Size(254, 169);
            this.titleGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTable;
        private System.Windows.Forms.GroupBox titleGroup;
    }
}
