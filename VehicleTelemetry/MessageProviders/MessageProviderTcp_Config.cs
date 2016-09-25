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
            if (provider == null) {
                throw new ArgumentNullException("Provider cannot be null.");
            }
            InitializeComponent();
            this.provider = provider;
            portTextBox.Text = provider.ListenPort.ToString();
        }

        private void connectButton_Click(object sender, EventArgs e) {
            try {
                int port = int.Parse(portTextBox.Text);
                if (0 < port && port <= 65535) {
                    provider.ListenPort = (ushort)port;
                }
            }
            catch (Exception ex) {
                int port = provider.ListenPort;
                portTextBox.Text = port.ToString();
                portTextBox.SelectionStart = 0;
                portTextBox.SelectionLength = portTextBox.Text.Length;
                portTextBox.Focus();
            }
        }
    }
}
