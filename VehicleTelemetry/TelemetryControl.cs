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
            panels = new PanelCollection(this);

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
        protected GMapPanel mapView = new GMapPanel();
        private bool trackingEnabled = true;
        private GeoPoint currentPosition;
        private List<Path> paths = new List<Path>();
        private PanelCollection panels;

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



        ////////////////////////////////////////////////////////////////////////
        public PanelCollection Panels {
            get {
                return panels;
            }
        }
    }
}
