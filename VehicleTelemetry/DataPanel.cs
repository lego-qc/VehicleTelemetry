using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleTelemetry {
    public partial class DataPanel : UserControl {
        public DataPanel() {
            InitializeComponent();
        }

        private int count;

        public int Count {
            get {
                return count;
            }
            set {
                if (value <= 0) {
                    flowLayout.Controls.Clear();
                    count = 0;
                }
                else {
                    // trim if needed
                    while (value < count) {
                        flowLayout.Controls.RemoveAt(flowLayout.Controls.Count - 1);
                        count--;
                    }
                    // push if needed
                    while (count < value) {
                        flowLayout.Controls.Add(new DataSnippet());
                        count++;
                    }

                    UpdateControlSize();
                }
            }
        }

        public DataSnippet this[int index] {
            get {
                return (DataSnippet)flowLayout.Controls[index];
            }
        }

        private void UpdateControlSize() {
            int parentWidth = flowLayout.ClientRectangle.Width;
            foreach (Control control in flowLayout.Controls) {
                control.Size = new Size(parentWidth - control.Margin.Right - control.Margin.Left, control.Size.Height);
            }
        }

        private void flowLayout_Resize(object sender, EventArgs e) {
            UpdateControlSize();
        }
    }
}
