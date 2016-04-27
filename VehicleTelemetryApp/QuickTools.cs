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
    public partial class QuickTools : VehicleTelemetry.Panel {
        public QuickTools() {
            InitializeComponent();

            Resize += ResizeContents;            
        }


        public void AddMap(MapPanel panel) {
            mapTools.AddMap(panel);
        }

        public void RemoveMap(MapPanel panel) {
            mapTools.RemoveMap(panel);
        }

        public void ClearMaps() {
            mapTools.ClearMaps();
        }


        public void AddPath(Path path) {
            mapTools.AddPath(path);
        }

        public void RemovePath(Path path) {
            mapTools.RemovePath(path);
        }

        public void ClearPaths() {
            mapTools.ClearPaths();
        }


        private void ResizeContents(object sender, EventArgs e) {
            pathsBox.Size = new Size(this.Size.Width - pathsBox.Margin.Left - pathsBox.Margin.Right, pathsBox.Height);
            mapsBox.Size = new Size(this.Size.Width - pathsBox.Margin.Left - pathsBox.Margin.Right, pathsBox.Height);
        }
    }
}
