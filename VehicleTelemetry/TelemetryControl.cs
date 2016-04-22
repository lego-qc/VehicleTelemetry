using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private List<Path> paths = new List<Path>();
        private PanelCollection panels;
        private List<MapPanel> mapPanels;
        private List<DataPanel> dataPanels;


        public TelemetryControl() {
            panels = new PanelCollection(this);
            dataPanels = new List<DataPanel>();
            mapPanels = new List<MapPanel>();

            InitializeComponent();

            currentPosition = new GeoPoint(47.5, 19);                        
            dockPanel.DocumentStyle = DocumentStyle.DockingMdi;
        }



        public virtual void AddPath(Path path) {
            paths.Add(path);
        }

        public virtual void RemovePath(Path path) {
            paths.Remove(path);
        }

        public int GetNumPaths() {
            return paths.Count;
        }

        public Path GetPathByName(string name) {
            foreach (var path in paths) {
                if (string.Compare(path.Name, name) == 0) {
                    return path;
                }
            }
            return null;
        }

        // DEPRECATED
        public List<Path> Paths {
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


        public void NotifyPathUpdate() {
            foreach (MapPanel panel in mapPanels) {
                panel.Refresh();
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
