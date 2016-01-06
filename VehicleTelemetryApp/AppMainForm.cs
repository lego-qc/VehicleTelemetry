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
    public partial class AppMainForm : Form {
        public AppMainForm() {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e) {
            var connectionForm = new ConnectionForm();
            connectionForm.ShowDialog();
        }

        private void preferenciesToolStripMenuItem_Click(object sender, EventArgs e) {
            var preferencesForm = new PreferencesForm();
            DialogResult result = preferencesForm.ShowDialog();
        }
    }
}
