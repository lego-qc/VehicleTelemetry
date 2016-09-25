using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace VehicleTelemetry {
    public partial class MessageProviderSerial_Config : UserControl {
        private MessageProviderSerial provider;


        /// <summary>
        /// Initialize a configurator for an instance of provider.
        /// </summary>
        /// <exception cref="ArgumentNullException">Provider must not be null.</exception>
        public MessageProviderSerial_Config(MessageProviderSerial provider) {
            if (provider == null) {
                throw new ArgumentNullException("Provider cannot be null.");
            }
            InitializeComponent();
            this.provider = provider;

            LoadOptions();
            FetchParameters();
        }

        protected void LoadOptions() {
            // find all available ports
            portSelector.Items.Clear();
            foreach (var portName in SerialPort.GetPortNames()) {
                portSelector.Items.Add(portName);
            }

            // load baud rate history
            // TODO
        }

        protected void SaveOptions() {
            // save user specified baud rates
            // TODO
        }

        protected void FetchParameters() {
            // select current parameters
            bool isPortFound = false;
            foreach (string item in portSelector.Items) {
                if (item.Equals(provider.PortName)) {
                    portSelector.SelectedItem = item;
                    isPortFound = true;
                }
            }
            if (!isPortFound) {
                portSelector.SelectedIndex = -1;
                portSelector.ResetText();
            }

            baudSelector.Text = provider.BaudRate.ToString();

            // 0: None / 1: Even / 2: Odd / 3: Space / 4: Mark
            switch (provider.Parity) {
                case Parity.None:
                    paritySelector.SelectedIndex = 0;
                    break;
                case Parity.Odd:
                    paritySelector.SelectedIndex = 2;
                    break;
                case Parity.Even:
                    paritySelector.SelectedIndex = 1;
                    break;
                case Parity.Mark:
                    paritySelector.SelectedIndex = 4;
                    break;
                case Parity.Space:
                    paritySelector.SelectedIndex = 3;
                    break;
            }

            dataBitsSelector.Text = provider.DataBits.ToString();

            // 1 / 1.5 / 2
            switch (provider.StopBits) {
                case StopBits.None:
                    stopBitsSelector.SelectedIndex = 0; // none is invalid, just use one instead
                    provider.StopBits = StopBits.One;
                    break;
                case StopBits.One:
                    stopBitsSelector.SelectedIndex = 0;
                    break;
                case StopBits.Two:
                    stopBitsSelector.SelectedIndex = 2;
                    break;
                case StopBits.OnePointFive:
                    stopBitsSelector.SelectedIndex = 1;
                    break;
            }
        }

        protected void CommitParameters() {
            try {
                provider.PortName = portSelector.Text;
                provider.BaudRate = int.Parse(baudSelector.Text);
                // 0: None / 1: Even / 2: Odd / 3: Space / 4: Mark
                switch (paritySelector.SelectedIndex) {
                    case 0: provider.Parity = Parity.None; break;
                    case 1: provider.Parity = Parity.Even; break;
                    case 2: provider.Parity = Parity.Odd; break;
                    case 3: provider.Parity = Parity.Space; break;
                    case 4: provider.Parity = Parity.Mark; break;
                    default: provider.Parity = Parity.None; break;
                }
                provider.DataBits = int.Parse(dataBitsSelector.Text);
                // 1 / 1.5 / 2
                switch (stopBitsSelector.SelectedIndex) {
                    case 0: provider.StopBits = StopBits.One; break;
                    case 1: provider.StopBits = StopBits.OnePointFive; break;
                    case 2: provider.StopBits = StopBits.Two; break;
                    default: provider.StopBits = StopBits.One; break;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "One or more arguments are invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void applyButton_Click(object sender, EventArgs e) {
            CommitParameters();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            FetchParameters();
        }
    }
}
