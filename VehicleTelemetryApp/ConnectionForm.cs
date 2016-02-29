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

            // enumerate all providers and add them to selection
            for (int i = 0; i < MessageProviderFactory.Enumerator.Count; i++) {
                providerSelector.Items.Add(new ProviderSelectorItem(MessageProviderFactory.Enumerator[i]));
            }

            UpdateControlState();
        }


        private void actionButton_Click(object sender, EventArgs e) {
            if (currentProvider == null) {
                return;
            }

            if (currentProvider.IsListening) {
                currentProvider.Cancel();
            }
            else if (currentProvider.IsConnected) {
                currentProvider.Disconnect();
            }
            else {
                try {
                    currentProvider.ListenAsync(ListenAsyncCallback);
                }
                catch (Exception ex) {
                    // swallow
                }
            }

            UpdateControlState();
        }


        private void providerSelector_SelectedIndexChanged(object sender, EventArgs e) {
            // the newly selected item
            ProviderSelectorItem item = (ProviderSelectorItem)providerSelector.SelectedItem;

            // create an instance of the new provider
            if (currentProvider != null) {
                currentProvider.Dispose();
            }
            currentProvider = MessageProviderFactory.Create(item.desc.id);
            currentConfigurator = currentProvider.GetConfigurator();
            if (currentConfigurator != null) {
                mainSplitter.Panel2.Controls.Add(currentConfigurator);
                currentConfigurator.Dock = DockStyle.Fill;
            }            

            // assign new provider to the processor
            foreach (var p in currentProcessors) {
                p.MessageProvider = currentProvider;
            }

            UpdateControlState();
        }


        private class ProviderSelectorItem {
            public ProviderSelectorItem(MessageProviderFactory.ProviderDesc desc = null) {
                this.desc = desc;
            }
            public MessageProviderFactory.ProviderDesc desc;
            public override string ToString() {
                return desc.name;
            }
        }


        private IMessageProvider currentProvider;
        private IMessageProcessor[] currentProcessors;
        private UserControl currentConfigurator;

        public IMessageProvider Provider {
            get {
                return currentProvider;
            }
            set {
                if (value == null) {
                    foreach (var p in currentProcessors) {
                        p.MessageProvider = null;
                    }
                    currentProvider = null;
                    UpdateControlState();
                    return;
                }

                // set value as currently selected item
                Guid id = value.GetType().GUID;
                ProviderSelectorItem newSelection = null;
                foreach (ProviderSelectorItem item in providerSelector.Items) {
                    if (item.desc.id == id) {
                        newSelection = item;
                        providerSelector.SelectedItem = newSelection;
                        break;
                    }
                }

                // debug
                if (newSelection == null) {
                    MessageBox.Show(
                        "An unregistered IMessageProvider was set{} on class ConnectionForm. " +
                        "All classes should be registered, so this is unexpected behaviour. " +
                        "Dynamically loaded assemblies?",
                        "Inconsistent state", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // apply changes to the processor
                foreach (var p in currentProcessors) {
                    p.MessageProvider = value;
                }

                // set state of UI controls according to current state
                UpdateControlState();
            }
        }

        public IMessageProcessor[] Processors {
            get {
                return currentProcessors;
            }
            set {
                currentProcessors = value;
            }
        }


        private void UpdateControlState() {
            if (currentProvider == null) {
                // allow select only
                actionButton.Enabled = false;
                providerSelector.Enabled = true;
            }
            else if (currentProvider.IsConnected) {
                // allow disconnect only
                actionButton.Enabled = true;
                providerSelector.Enabled = false;

                actionButton.Text = "Disconnect";
            }
            else if (currentProvider.IsListening) {
                actionButton.Text = "Cancel";
                actionButton.Enabled = true;
                providerSelector.Enabled = false;
            }
            else {
                actionButton.Text = "Listen";
                actionButton.Enabled = true;
                providerSelector.Enabled = true;
            }
        }

        private void ListenAsyncCallback(bool result) {
            Invoke(new Action(() => { UpdateControlState(); }));
        }
    }
}
