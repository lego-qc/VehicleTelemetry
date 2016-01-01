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

namespace QCTracker {
    public partial class QCTrackerMainForm : Form {
        ////////////////////////////////////////////////////////////////////////
        // Cunstruction
        public QCTrackerMainForm() {
            InitializeComponent();
            ConfigMap();

            mapGroup.Controls.Add(mapView);
            mapView.Dock = DockStyle.Fill;

            dataGroupTest.Count = 3;
            dataGroupTest.Title = "Acceleration";
            dataGroupTest.Labels[0] = "X =";
            dataGroupTest.Labels[1] = "Y =";
            dataGroupTest.Labels[2] = "Z =";
            dataGroupTest.Values[0] = "1";
            dataGroupTest.Values[1] = "2";
            dataGroupTest.Values[2] = "3";
        } 

        private void ConfigMap() {
            trackingEnabled = dataPanelPositionLock.Checked;

            currentPosition = new GeoPoint(47.5, 19);
        }
        
        ////////////////////////////////////////////////////////////////////////
        // Methods

        void SetCurrentPosition(GeoPoint point) {
            currentPosition = point;
            if (trackingEnabled) {
                mapView.Position = point;
            }

            dataPanelLat.Text = currentPosition.Lat.ToString();
            dataPanelLong.Text = currentPosition.Lng.ToString();
            dataPanelAlt.Text = currentPosition.Alt.ToString();
        }


        ////////////////////////////////////////////////////////////////////////
        // Vars

        protected MapView mapView = new MapView();
        private bool trackingEnabled;
        private GeoPoint currentPosition;
        private List<Path> paths = new List<Path>();


        ////////////////////////////////////////////////////////////////////////
        // Event handlers

        private void dataPanelPositionLock_CheckedChanged(object sender, EventArgs e) {
            trackingEnabled = dataPanelPositionLock.Checked;
            if (trackingEnabled) {
                mapView.Position = new GeoPoint(currentPosition.Lat, currentPosition.Lng);
            }
        }

        private void dataPanelLocate_Click(object sender, EventArgs e) {
            mapView.Position = new GeoPoint(currentPosition.Lat, currentPosition.Lng);
        }

        long debugPushCounter = 0;
        private void debugPushWaypoint_Click(object sender, EventArgs e) {
            double x = Math.Sin(debugPushCounter / 6.0);
            double y = Math.Cos(debugPushCounter / 6.0);
            SetCurrentPosition(new GeoPoint(47.5 + x * debugPushCounter * 0.001, 19 + y * debugPushCounter * 0.001));
            if (mapView.GetNumPaths() == 0) {
                mapView.AddPath();
                mapView.GetPath(0).Color = Pens.Blue;
            }
            mapView.GetPath(0).Add(currentPosition);
            mapView.Refresh();
            debugPushCounter++;
        }

        private void menuItemMapOptions_Click(object sender, EventArgs e) {
            mapView.ShowOptions();
        }

        private void menuItemExit_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
