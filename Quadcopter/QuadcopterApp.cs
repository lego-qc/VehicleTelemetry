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

namespace VehicleTelemetryApp {
    public partial class QuadcopterApp : TelemetryControl {
        private DataPanel dataPanel;
        private MapPanel mapPanel;
        private VideoPanel videoPanel;
        private QuickTools quickTools;
		private MessageProcessor_Path messageProcessorPath;
		private MessageProcessor_Data messageProcessorData;
		private MessageProcessor_Map messageProcessorMap;

		public QuadcopterApp() {
            InitializeComponent();

            // merge menu strips
            foreach (ToolStripMenuItem menuItem in menuStrip1.Items) {
                menuItem.MergeAction = MergeAction.Append;
            }
            toolsToolStripMenuItem.MergeAction = MergeAction.MatchOnly;
            ToolStripManager.Merge(menuStrip1, base.MenuStrip);
            menuStrip1.Visible = false;

            // create panels
            dataPanel = new DataPanel();
            mapPanel = new GMapPanel();
            videoPanel = new DummyVideoPanel();
            quickTools = new QuickTools();
            dataPanel.Text = "Telemetry Data";
            mapPanel.Text = "Map";
            videoPanel.Text = "Dummy Video (not working)";
            quickTools.Text = "Quick Tools";
            Panels.Add(dataPanel, DockState.DockRight);
            Panels.Add(mapPanel, DockState.Document);
            Panels.Add(videoPanel, DockState.Document);
            Panels.Add(quickTools, DockState.DockLeft);

            // create message processors
            messageProcessorData = new MessageProcessor_Data();
            messageProcessorPath = new MessageProcessor_Path();
            messageProcessorMap = new MessageProcessor_Map();
            messageProcessorData.Target = dataPanel;
            messageProcessorPath.Target = mapPanel;
            messageProcessorMap.Target = mapPanel;
			AddMessageProcessor(messageProcessorData);
			AddMessageProcessor(messageProcessorPath);
			AddMessageProcessor(messageProcessorMap);

			// init quick tools
			quickTools.AddMap(mapPanel);
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e) {
            var connectionForm = new ConnectionForm();
            connectionForm.StartPosition = FormStartPosition.CenterParent;
            connectionForm.TelemetryControl = this;
            connectionForm.ShowDialog();
        }

        private void appSettingsToolStripMenuItem_Click(object sender, EventArgs e) {
            var preferencesForm = new PreferencesForm();
            preferencesForm.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = preferencesForm.ShowDialog();
        }


        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e) {
            if (MessageProvider != null) {
				MessageProvider.Disconnect();
            }
        }
    }
}
