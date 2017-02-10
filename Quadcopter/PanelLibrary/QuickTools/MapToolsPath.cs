using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleTelemetry;

namespace VehicleTelemetryApp {
    public partial class MapToolsPath : UserControl {
        private Path path;

        public MapToolsPath(Path path = null) {
            InitializeComponent();

            this.Path = path;
        }

        public Path Path {
            get {
                return path;
            }
            set {
                path = value;

                if (path == null) {
                    colorSelector.BackColor = Color.White;
                    colorSelector.ForeColor = Color.Black;
                    return;
                }

                pathName.Text = path.Name;
				visibilityToggle.Checked = path.Visible;

                colorSelector.BackColor = path.Color;
                if (colorSelector.BackColor.GetBrightness() < 0.5) {
                    colorSelector.ForeColor = Color.White;
                }
                else {
                    colorSelector.ForeColor = Color.Black;
                }
            }
        }

        private void colorSelector_Click(object sender, EventArgs e) {
            var dlg = new ColorDialog();
            var result = dlg.ShowDialog();
            if (result== DialogResult.OK) {
                colorSelector.BackColor = dlg.Color;
                if (path != null) {
                    path.Color = dlg.Color;
                }
            }
        }

        private void clearPoints_Click(object sender, EventArgs e) {
            path.Clear();
        }

		private void visibilityToggle_CheckedChanged(object sender, EventArgs e) {
			path.Visible = visibilityToggle.Checked;
		}
	}
}
