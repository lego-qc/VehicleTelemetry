using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleTelemetry {
    partial class TelemetryControl {


        /// <summary>
        /// Smart toolstrip item for toggling and tracking panel vsibility.
        /// </summary>
        class PanelToolStripItem : ToolStripMenuItem {
            private Panel panel;
            private WeifenLuo.WinFormsUI.Docking.DockState lastState;
            private TelemetryControl owner;

            public PanelToolStripItem(TelemetryControl owner, Panel panel = null) {
                this.owner = owner;
                this.Click += OnClicked;
                this.Panel = panel;
            }

            protected override void Dispose(bool v) {
                if (v) {
                    this.Click -= OnClicked;
                    if (panel != null) {
                        panel.VisibleChanged -= OnVisibilityChanged;
                    }
                }
                base.Dispose(v);
            }


            public Panel Panel {
                get {
                    return panel;
                }
                set {
                    if (panel != null) {
                        panel.VisibleChanged -= OnVisibilityChanged;
                        panel.FormClosing -= OnClosed;
                    }
                    panel = value;
                    if (panel != null) {
                        panel.VisibleChanged += OnVisibilityChanged;
                        OnVisibilityChanged(null, null);
                        base.Text = panel.Text;
                        panel.FormClosing += OnClosed;
                    }
                }
            }

            void OnClicked(object sender, EventArgs e) {
                if (panel.Visible) {
                    panel.Hide();
                }
                else {
                    panel.Show();
                }
            }

            void OnVisibilityChanged(object sender, EventArgs e) {
                if (panel.Visible) {
                    // change state of checkbox
                    base.Checked = true;
                }
                else {
                    // change state of checkbox
                    base.Checked = false;

                    // remember last dock state
                    lastState = panel.DockState;
                }
            }

            void OnClosed(object sender, EventArgs e) {
                owner.RemovePanel(panel);
            }
        }


    }
}
