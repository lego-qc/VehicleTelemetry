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

        }
    }
}
