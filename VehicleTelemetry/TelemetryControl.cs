using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using WeifenLuo.WinFormsUI.Docking;


namespace VehicleTelemetry {
	/// <summary>
	/// This interface will probably change, and I'm fucking tired of commenting.
	/// </summary>
	public partial class TelemetryControl : Form {
		private GeoPoint currentPosition;
		private PanelCollection panels;
		private List<IMessageProcessor> messageProcessors;
		private IMessageProvider messageProvider;


		public TelemetryControl() {
			panels = new PanelCollection(this);

			InitializeComponent();

			currentPosition = new GeoPoint(47.5, 19);
			dockPanel.DocumentStyle = DocumentStyle.DockingMdi;
			messageProcessors = new List<IMessageProcessor>();
		}

		public PanelCollection Panels {
			get {
				return panels;
			}
		}

		protected MenuStrip MenuStrip {
			get {
				return menuStrip;
			}
		}

		public IMessageProvider MessageProvider {
			get {
				return messageProvider;
			}
			set {
				// unhook all message processors from message provider
				if (messageProvider != null) {
					foreach (var processor in messageProcessors) {
						messageProvider.OnMessage -= processor.OnMessage;
					}
				}
				// hook all message processors on new provider
				messageProvider = value;
				if (messageProvider != null) {
					foreach (var processor in messageProcessors) {
						messageProvider.OnMessage += processor.OnMessage;
					}
				}
			}
		}

		private void AddPanel(Panel panel, DockState dockState) {
			panel.Show(dockPanel, (WeifenLuo.WinFormsUI.Docking.DockState)dockState);

			// register on view menu
			panelsToolStripMenuItem.DropDownItems.Add(new PanelToolStripItem(this, panel));
			menuStrip.PerformLayout();
		}

		private void RemovePanel(Panel panel) {
			panel.DockPanel = null;

			// unregister on view menu
			foreach (PanelToolStripItem item in panelsToolStripMenuItem.DropDownItems) {
				if (item.Panel == panel) {
					panelsToolStripMenuItem.DropDownItems.Remove(item);
					item.Dispose();
					break;
				}
			}
		}

		public void AddMessageProcessor(IMessageProcessor processor) {
			messageProcessors.Add(processor);

			if (messageProvider != null) {
				messageProvider.OnMessage += processor.OnMessage;
			}
		}

		public void RemoveMessageProcessor(IMessageProcessor processor) {
			bool wasFound = messageProcessors.Remove(processor);

			if (wasFound && messageProvider != null) {
				messageProvider.OnMessage -= processor.OnMessage;
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
