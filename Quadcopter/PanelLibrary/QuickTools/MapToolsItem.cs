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
using System.Collections.Specialized;

namespace VehicleTelemetryApp {
    public partial class MapToolsItem : UserControl {
        private MapPanel map;
        private bool expanded;

        public MapToolsItem() {
            InitializeComponent();

            expanded = false;
            AutoSize = true;
            pathContainer.Visible = false;            
            showPathsButton.Text = "Paths \u2193";
        }

        public MapToolsItem(MapPanel panel) : this() {
            this.Map = panel;
        }

        public MapPanel Map {
            get {
                return map;
            }
            set {
                map = value;

                if (map != null) {
                    mapName.Text = map.Text;

                    //RefreshPaths(null, null);

					map.Paths.CollectionChanged += RefreshPaths;
                }
            }
        }

        private void showPathsButton_Click(object sender, EventArgs e) {
            if (expanded) {
				pathContainer.Visible = false;
                showPathsButton.Text = "Paths \u2193";
            }
            else {
				pathContainer.Visible = true;
				foreach (Control control in pathContainer.Controls) {
					control.Visible = true;
				}
                showPathsButton.Text = "Paths \u2191";
            }
            expanded = !expanded;
        }

        private void showConfigureButton_Click(object sender, EventArgs e) {
            if (map != null) {
                map.ShowConfig();
            }
        }

        private void follow_CheckedChanged(object sender, EventArgs e) {
            map.Follow = follow.Checked;
        }

		private void RefreshPaths(object sender, NotifyCollectionChangedEventArgs e) {
			pathContainer.Controls.Clear();
			foreach (var path in map.Paths) {
				pathContainer.Controls.Add(new MapToolsPath(path));
			}
		}
    }
}
