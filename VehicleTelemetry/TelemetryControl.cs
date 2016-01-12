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

namespace VehicleTelemetry {
    public partial class TelemetryControl : UserControl {
        ////////////////////////////////////////////////////////////////////////
        // Cunstruction
        public TelemetryControl() {
            InitializeComponent();
            ConfigMap();

            mapGroup.Controls.Add(mapView);
            mapView.Dock = DockStyle.Fill;
            mapView.Paths = paths;
        } 

        private void ConfigMap() {
            currentPosition = new GeoPoint(47.5, 19);
        }
        
        ////////////////////////////////////////////////////////////////////////
        // Methods

        public void SetCurrentPosition(GeoPoint point) {
            currentPosition = point;
            if (trackingEnabled) {
                mapView.Position = point;
            }
        }


        ////////////////////////////////////////////////////////////////////////
        // Vars
        protected MapView mapView = new MapView();
        private bool trackingEnabled = true;
        private GeoPoint currentPosition;
        private List<Path> paths = new List<Path>();

        ////////////////////////////////////////////////////////////////////////
        // Properties
        public DataPanel DataSnippets {
            get {
                return dataPanel;
            }
        }

        public List<Path> Paths {
            get {
                return paths;
            }
        }

        ////////////////////////////////////////////////////////////////////////
        // Event handlers
        //private void menuItemMapOptions_Click(object sender, EventArgs e) {
        //    mapView.ShowOptions();
        //}

        //private void menuItemExit_Click(object sender, EventArgs e) {
        //    Close();
        //}
    }
}
