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
    public partial class AppMainForm : TelemetryControl {
        public AppMainForm() {
            InitializeComponent();

            // merge menu strips
            foreach (ToolStripMenuItem menuItem in menuStrip1.Items) {
                menuItem.MergeAction = MergeAction.Append;
            }
            toolsToolStripMenuItem.MergeAction = MergeAction.MatchOnly;
            ToolStripManager.Merge(menuStrip1, base.MenuStrip);
            menuStrip1.Visible = false;

            // create panels
            DataPanel dataPanel = new DataPanel();
            MapPanel mapPanel = new GMapPanel();
            VideoPanel videoPanel = new DummyVideoPanel();
            QuickTools quickTools = new QuickTools();
            dataPanel.Text = "Telemetry Data";
            mapPanel.Text = "Map";
            videoPanel.Text = "Dummy Video (not working)";
            quickTools.Text = "Quick Tools";
            Panels.Add(dataPanel, DockState.DockRight);
            Panels.Add(mapPanel, DockState.Document);
            Panels.Add(videoPanel, DockState.Document);
            Panels.Add(quickTools, DockState.DockLeft);

            // Set up panels
            mapPanel.Paths = Paths;

            // create message processors
            messageProcessorData = new MessageProcessor_Data();
            messageProcessorPath = new MessageProcessor_Path();
            messageProcessorMap = new MessageProcessor_Map();
            messageProcessorData.Target = dataPanel;
            messageProcessorPath.Target = this;
            messageProcessorMap.Target = mapPanel;
        }

        private void InitializeExtendedMenuStrip() {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e) {
            var connectionForm = new ConnectionForm();
            connectionForm.Processors = new IMessageProcessor[] { messageProcessorPath, messageProcessorData, messageProcessorMap };
            connectionForm.Provider = messageProvider;
            connectionForm.ShowDialog();
            messageProvider = connectionForm.Provider;
        }

        private void appSettingsToolStripMenuItem_Click(object sender, EventArgs e) {
            var preferencesForm = new PreferencesForm();
            DialogResult result = preferencesForm.ShowDialog();
        }


        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e) {
            if (messageProvider != null) {
                messageProvider.Disconnect();
            }
        }


        private IMessageProvider messageProvider;
        private MessageProcessor_Path messageProcessorPath;
        private MessageProcessor_Data messageProcessorData;
        private MessageProcessor_Map messageProcessorMap;
    }
}
