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
    /// <summary>
    /// DataPanels are used to show textual telemetry information.
    /// </summary>
    /// <remarks>
    /// Information is grouped into snippets. Each snippet has its title
    /// and multiple key-value pairs. Each pair represents the measured property
    /// and the value of the measurement, e.g. "velocity" and "42 kph".
    /// </remarks>
    public partial class DataPanel : Panel {
        /// <summary>
        /// Number of snippets.
        /// </summary>
        private int count;

        /// <summary>
        /// Create an empty panel.
        /// </summary>
        public DataPanel() {
            InitializeComponent();
        }

        /// <summary>
        /// The number of snippets on the panel.
        /// </summary>
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

        /// <summary>
        /// Access and possibly modify the i-th snippet.
        /// </summary>
        public DataSnippet this[int index] {
            get {
                return (DataSnippet)flowLayout.Controls[index];
            }
        }

        /// <summary>
        /// Recomputes the size of the snippet controls.
        /// </summary>
        /// <remarks>Call each time the panel is resized.</remarks>
        private void UpdateControlSize() {
            int parentWidth = flowLayout.ClientRectangle.Width;
            foreach (Control control in flowLayout.Controls) {
                control.Size = new Size(parentWidth - control.Margin.Right - control.Margin.Left, control.Size.Height);
            }
        }

        /// <summary>
        /// Handler for resize events of the internal flow layout.
        /// </summary>
        private void flowLayout_Resize(object sender, EventArgs e) {
            UpdateControlSize();
        }
    }
}
