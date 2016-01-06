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
    public partial class ConnectionForm : Form {
        public ConnectionForm() {
            InitializeComponent();

            for (int i=0; i< MessageProviderFactory.Enumerator.Count; i++) {
                providerSelector.Items.Add(MessageProviderFactory.Enumerator[i].name);
            }
        }
    }
}
