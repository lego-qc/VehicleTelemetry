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
    public partial class PathTools : UserControl {
        private Dictionary<Path, PathToolsItem> paths = new Dictionary<Path, PathToolsItem>();

        public PathTools() {
            InitializeComponent();
        }

        public void AddPath(Path path) {
            if (path == null) {
                return;
            }
            try {
                var control = new PathToolsItem(path);
                paths.Add(path, control);
                flowLayoutPanel1.Controls.Add(control);
            } catch (Exception) {

            }
        }

        public void RemovePath(Path path) {
            var control = paths[path];
            flowLayoutPanel1.Controls.Remove(control);
        }

        public void Clear() {
            paths.Clear();
            flowLayoutPanel1.Controls.Clear();
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e) {
            foreach (Control item in flowLayoutPanel1.Controls) {
                item.Size = new Size(Size.Width - item.Margin.Left - item.Margin.Right, item.Size.Height);
            }
        }
    }
}
