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
        ////////////////////////////////////////////////////////////////////////
        // Cunstruction
        public TelemetryControl() {
            panels = new PanelCollection(this);
            dataPanels = new List<DataPanel>();
            mapPanels = new List<MapPanel>();

            InitializeComponent();
            ConfigMap();

            dockPanel.DocumentStyle = DocumentStyle.DockingMdi;
        }

        private void ConfigMap() {
            currentPosition = new GeoPoint(47.5, 19);
        }
        
        ////////////////////////////////////////////////////////////////////////
        // Methods

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


        private void AddPanel(Panel panel, DockState dockState) {
            panel.Show(dockPanel, (WeifenLuo.WinFormsUI.Docking.DockState)dockState);

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

            // check special panel types
            Type panelType = panel.GetType();
            if (typeof(MapPanel).IsAssignableFrom(panelType)) {
                mapPanels.Remove(panel as MapPanel);
            }
            if (typeof(DataPanel).IsAssignableFrom(panelType)) {
                dataPanels.Remove(panel as DataPanel);
            }
        }


        ////////////////////////////////////////////////////////////////////////
        // Vars
        private bool trackingEnabled = true;
        private GeoPoint currentPosition;
        private List<Path> paths = new List<Path>();
        private PanelCollection panels;
        private List<MapPanel> mapPanels;
        private List<DataPanel> dataPanels;

        ////////////////////////////////////////////////////////////////////////
        // Properties

        public List<Path> Paths {
            get {
                return paths;
            }
        }


        ////////////////////////////////////////////////////////////////////////
        // Event handlers



        ////////////////////////////////////////////////////////////////////////
        public PanelCollection Panels {
            get {
                return panels;
            }
        }
    }
}
