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

        private void ResizeContents(object sender, EventArgs e) {
            mapsBox.Size = new Size(this.Size.Width - mapsBox.Margin.Left - mapsBox.Margin.Right, mapsBox.Height);
        }
    }
}
