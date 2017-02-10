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

	public partial class MapTools : UserControl {
		private List<MapPanel> panels;
		private List<Path> paths;

		public MapTools() {
			InitializeComponent();

			Resize += MapTools_Resize;

			panels = new List<MapPanel>();
			paths = new List<Path>();
		}

		private void MapTools_Resize(object sender, EventArgs e) {
			foreach (Control c in mapFlowContainer.Controls) {
				c.Size = new Size(this.Size.Width - c.Margin.Left - c.Margin.Right, c.Height);
			}
		}

		public void AddMap(MapPanel panel) {
			panels.Add(panel);

			mapFlowContainer.Controls.Add(new MapToolsItem(panel));
		}

		public void RemoveMap(MapPanel panel) {
			panels.Remove(panel);
		}

		public void ClearMaps() {
			panels.Clear();
		}

		public override Size GetPreferredSize(Size proposedSize) {
			int width = 0;
			int height = 0;
			foreach (Control c in mapFlowContainer.Controls) {
				width = Math.Max(c.GetPreferredSize(proposedSize).Width + c.Margin.Left + c.Margin.Right, width);
				height += c.Margin.Top + c.Margin.Bottom + c.GetPreferredSize(proposedSize).Height;
			}
			return new Size(width, height);
		}
	}
}
