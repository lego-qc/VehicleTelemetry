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
    public partial class MapToolsItem : UserControl {
        private Path[] paths;
        private MapPanel map;
        private bool expanded;

        public MapToolsItem() {
            InitializeComponent();

            expanded = false;
            paths = null;

            AutoSize = true;

            showPathsMap.Visible = false;            
            showPathsButton.Text = "Paths \u2193";
        }

        public MapToolsItem(Path[] paths) : this() {
            this.Paths = paths;
        }

        public MapToolsItem(MapPanel panel) : this() {
            this.Map = panel;
        }

        public MapToolsItem(MapPanel panel, Path[] paths) : this() {
            this.Paths = paths;
            this.Map = panel;
        }


        public Path[] Paths {
            get {
                return paths;
            }
            set {
                paths = value;

                showPathsMap.Items.Clear();
                if (paths != null) {
                    foreach (var path in paths) {
                        int index = showPathsMap.Items.Add(new PathListRecord(path));
                        if (map != null && map.Paths.Contains(path)) {
                            showPathsMap.SetItemChecked(index, true);
                        }
                    }
                }
            }
        }

        public MapPanel Map {
            get {
                return map;
            }
            set {
                map = value;

                if (map != null) {
                    mapName.Text = map.Text;

                    List<PathListRecord> containedItems = new List<PathListRecord>();
                    foreach (PathListRecord item in showPathsMap.Items) {
                        if (map.Paths.Contains(item.path)) {
                            containedItems.Add(item);
                        }
                    }
                    foreach (var item in containedItems) {
                        showPathsMap.SetItemChecked(showPathsMap.Items.IndexOf(item), true);
                    }
                }
            }
        }

        private void showPathsButton_Click(object sender, EventArgs e) {
            if (expanded) {
                showPathsMap.Visible = false;
                showPathsButton.Text = "Paths \u2193";
            }
            else {
                showPathsMap.Visible = true;
                showPathsButton.Text = "Paths \u2191";
            }
            expanded = !expanded;
        }

        private void showConfigureButton_Click(object sender, EventArgs e) {
            if (map != null) {
                map.ShowConfig();
            }
        }


        private void showPathsMap_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (map == null) {
                return;
            }

            if (e.NewValue == CheckState.Checked) {
                if (!map.Paths.Contains((showPathsMap.Items[e.Index] as PathListRecord).path)) {
                    map.Paths.Add((showPathsMap.Items[e.Index] as PathListRecord).path);
                }
            }
            else {
                map.Paths.Remove((showPathsMap.Items[e.Index] as PathListRecord).path);
            }
            map.Refresh();
        }


        class PathListRecord {
            public PathListRecord() { path = null; }
            public PathListRecord(Path path) { this.path = path; }

            public Path path;
            public override string ToString() {
                return path != null ? path.Name : "unnamed";
            }
        }
    }
}
