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
    public partial class TelemetryControl : Form {
        private bool trackingEnabled = true;
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
            ConfigMap();
            
            dockPanel.DocumentStyle = DocumentStyle.DockingMdi;
        }

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


        public void SetCurrentPosition(GeoPoint point) {
            currentPosition = point;
            if (trackingEnabled) {
                //mapView.Position = point;
            }
        }

        public MapPanel[] GetMapPanels() {
            return mapPanels.ToArray();
        }

        public DataPanel[] GetDataPanels() {
            return dataPanels.ToArray();
        }


        public void PathsUpdated() {
            foreach (MapPanel panel in mapPanels) {
                panel.Refresh();
            }
        }

        private void ConfigMap() {
            currentPosition = new GeoPoint(47.5, 19);
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


        class PanelToolStripItem : ToolStripMenuItem {
            private Panel panel;
            private WeifenLuo.WinFormsUI.Docking.DockState lastState;
            private TelemetryControl owner;

            public PanelToolStripItem(TelemetryControl owner, Panel panel = null) {
                this.owner = owner;
                this.Click += OnClicked;
                this.Panel = panel;
            }

            protected override void Dispose(bool v) {
                if (v) {
                    this.Click -= OnClicked;
                    if (panel != null) {
                        panel.VisibleChanged -= OnVisibilityChanged;
                    }
                }
                base.Dispose(v);
            }


            public Panel Panel {
                get {
                    return panel;
                }
                set {
                    if (panel != null) {
                        panel.VisibleChanged -= OnVisibilityChanged;
                        panel.FormClosing -= OnClosed;
                    }
                    panel = value;
                    if (panel != null) {
                        panel.VisibleChanged += OnVisibilityChanged;
                        OnVisibilityChanged(null, null);
                        base.Text = panel.Text;
                        panel.FormClosing += OnClosed;
                    }
                }
            }

            void OnClicked(object sender, EventArgs e) {
                if (panel.Visible) {
                    panel.Hide();
                }
                else {
                    panel.Show();
                }
            }

            void OnVisibilityChanged(object sender, EventArgs e) {
                if (panel.Visible) {
                    // change state of checkbox
                    base.Checked = true;
                }
                else {
                    // change state of checkbox
                    base.Checked = false;

                    // remember last dock state
                    lastState = panel.DockState;
                }
            }

            void OnClosed(object sender, EventArgs e) {
                owner.RemovePanel(panel);
            }
        }
    }
}
