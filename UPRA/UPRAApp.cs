using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleTelemetry;

namespace UPRA {
	public partial class UPRAApp : TelemetryControl {
		private DataPanel dataPanel;
		private MapPanel mapPanel;
		private CameraPanel cameraPanel;
		private RadioPanel radioPanel;

		public UPRAApp() {
			InitializeComponent();

			// create panels
			dataPanel = new DataPanel();
			mapPanel = new GMapPanel();
			cameraPanel = new CameraPanel();
			radioPanel = new RadioPanel();
			dataPanel.Text = "Telemetry Data";
			mapPanel.Text = "Map";
			cameraPanel.Text = "Camera";
			radioPanel.Text = "Radio";
			Panels.Add(dataPanel, DockState.DockRight);
			Panels.Add(mapPanel, DockState.Document);
			Panels.Add(cameraPanel, DockState.Document);
			Panels.Add(radioPanel, DockState.DockLeft);
		}
	}
}
