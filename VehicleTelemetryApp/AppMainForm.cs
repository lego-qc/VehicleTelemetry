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

            messageProvider = null;
            messageProcessor = new MessageProcessor(messageProvider, this);

            DataPanel dataPanel = new DataPanel();
            MapPanel mapPanel1 = new GMapPanel();
            MapPanel mapPanel2 = new GMapPanel();
            dataPanel.Text = "Telemetry Data";
            mapPanel1.Text = "Map 1";
            mapPanel2.Text = "Map 2";
            Panels.Add(dataPanel, DockState.DockRight);
            Panels.Add(mapPanel1, DockState.Document);
            Panels.Add(mapPanel2, DockState.Document);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e) {
            var connectionForm = new ConnectionForm();
            connectionForm.Processor = messageProcessor;
            connectionForm.Provider = messageProvider;
            connectionForm.Show();
            messageProvider = connectionForm.Provider;
        }

        private void preferenciesToolStripMenuItem_Click(object sender, EventArgs e) {
            var preferencesForm = new PreferencesForm();
            DialogResult result = preferencesForm.ShowDialog();
        }

        private IMessageProvider messageProvider;
        private MessageProcessor messageProcessor;
    }
}
