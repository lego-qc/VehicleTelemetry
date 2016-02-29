using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleTelemetry {
    public partial class MessageProviderTcp_Config : UserControl {
        private MessageProviderTcp provider;


        public MessageProviderTcp_Config(MessageProviderTcp provider) {
            InitializeComponent();
            this.provider = provider;
        }

        private void connectButton_Click(object sender, EventArgs e) {
            try {
                int port = int.Parse(portTexBox.Text);
                if (0 < port && port <= 65535) {
                    provider.ListenPort = (ushort)port;
                }
            }
            catch (Exception ex) {
                int port = provider.ListenPort;
                portTexBox.Text = port.ToString();
                portTexBox.SelectionStart = 0;
                portTexBox.SelectionLength = portTexBox.Text.Length;
                portTexBox.Focus();
            }
        }
    }
}
