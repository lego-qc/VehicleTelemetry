using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleTelemetry {
	public partial class ConnectionForm : Form {
		private int minSizeWithName = 400;
		private IMessageProvider currentProvider;
		private TelemetryControl telemetryControl;
		private UserControl currentConfigurator;


		public ConnectionForm() {
			InitializeComponent();

			// enumerate all providers and add them to selection
			int maxNameLen = 0;
			for (int i = 0; i < MessageProviderFactory.Enumerator.Count; i++) {
				providerSelector.Items.Add(new ProviderSelectorItem(MessageProviderFactory.Enumerator[i]));
				maxNameLen = Math.Max(maxNameLen, MessageProviderFactory.Enumerator[i].name.Length);
			}

			// adjust window size according to the length of provider names
			minSizeWithName = (int)(providerSelector.Font.SizeInPoints * maxNameLen + 200);
			this.MinimumSize = new Size(minSizeWithName, this.MinimumSize.Height);

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
			telemetryControl.MessageProvider = currentProvider;

			// create a configurator for the new provider
			mainSplitter.Panel2.Controls.Clear();
			currentConfigurator = currentProvider.GetConfigurator();
			if (currentConfigurator != null) {
				mainSplitter.Panel2.Controls.Add(currentConfigurator);
				currentConfigurator.Dock = DockStyle.Fill;
				this.MinimumSize = new Size(Math.Max(minSizeWithName, currentConfigurator.MinimumSize.Width), 72 + currentConfigurator.MinimumSize.Height);
				this.Size = new Size(Width, this.MinimumSize.Height);
			}
			else {
				this.MinimumSize = new Size(minSizeWithName, 72);
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

		public TelemetryControl TelemetryControl {
			get {
				return telemetryControl;
			}
			set {
				telemetryControl = value;
				if (telemetryControl == null) {
					currentProvider = null;
					UpdateControlState();
					return;
				}
				currentProvider = telemetryControl.MessageProvider;
				if (currentProvider == null) {
					UpdateControlState();
					return;
				}

				// set value as currently selected item
				Guid id = currentProvider.GetType().GUID;
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

				// set state of UI controls according to current state
				UpdateControlState();
			}
		}

		private void UpdateControlState() {
			if (currentProvider == null) {
				// allow select only
				actionButton.Enabled = false;
				providerSelector.Enabled = true;

				stateIndicator.Image = Properties.Resources.ConnectionForm_Disconnected;
			}
			else if (currentProvider.IsConnected) {
				// allow disconnect only
				actionButton.Enabled = true;
				providerSelector.Enabled = false;

				actionButton.Text = "Disconnect";

				stateIndicator.Image = Properties.Resources.ConnectionForm_Connected;
			}
			else if (currentProvider.IsListening) {
				actionButton.Text = "Cancel";
				actionButton.Enabled = true;
				providerSelector.Enabled = false;

				stateIndicator.Image = Properties.Resources.ConnectionForm_Waiting;
			}
			else {
				actionButton.Text = "Listen";
				actionButton.Enabled = true;
				providerSelector.Enabled = true;

				stateIndicator.Image = Properties.Resources.ConnectionForm_Disconnected;
			}
		}

		private void ListenAsyncCallback(bool result) {
			// this crashes the app if attempting to connect while form is closed
			// would adding a try/catch be ugly?
			try {
				Invoke(new Action(() => { UpdateControlState(); }));
			}
			catch (Exception ex) {
				// don't care
			}
		}
	}
}
