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
        private List<MapPanel> mapPanels;
        private List<DataPanel> dataPanels;
        private ObservableCollection<Path> paths;


        public TelemetryControl() {
            panels = new PanelCollection(this);
            dataPanels = new List<DataPanel>();
            mapPanels = new List<MapPanel>();

            paths = new ObservableCollection<Path>();

            InitializeComponent();

            currentPosition = new GeoPoint(47.5, 19);                        
            dockPanel.DocumentStyle = DocumentStyle.DockingMdi;

            paths.CollectionChanged += OnPathsChanged;
        }


        public ObservableCollection<Path> Paths {
            get {
                return paths;
            }
        }

        public PanelCollection Panels {
            get {
                return panels;
            }
        }

        protected MenuStrip MenuStrip {
            get {
                return menuStrip1;
            }
        }

        public MapPanel[] GetMapPanels() {
            return mapPanels.ToArray();
        }

        public DataPanel[] GetDataPanels() {
            return dataPanels.ToArray();
        }


        private void OnPathsChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs args) {
            switch (args.Action) {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        private void AddPanel(Panel panel, DockState dockState) {
            panel.Show(dockPanel, (WeifenLuo.WinFormsUI.Docking.DockState)dockState);

            // register on view menu
            panelsToolStripMenuItem.DropDownItems.Add(new PanelToolStripItem(this, panel));
            menuStrip1.PerformLayout();

            // check special panel types
            Type panelType = panel.GetType();
            if (typeof(MapPanel).IsAssignableFrom(panelType)) {
                mapPanels.Add(panel as MapPanel);
            }
            if (typeof(DataPanel).IsAssignableFrom(panelType)) {
                dataPanels.Add(panel as DataPanel);
            }
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

            // check special panel types
            Type panelType = panel.GetType();
            if (typeof(MapPanel).IsAssignableFrom(panelType)) {
                mapPanels.Remove(panel as MapPanel);
            }
            if (typeof(DataPanel).IsAssignableFrom(panelType)) {
                dataPanels.Remove(panel as DataPanel);
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
