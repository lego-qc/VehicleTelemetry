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

            mapDisplayPanel.Controls.Add(mapView);
            mapView.Dock = DockStyle.Fill;
        } 

        private void ConfigMap() {
            mapView.MapProvider = GMapProviders.OpenStreetMap;
            mapView.Position = new PointLatLng(47.5, 19);
            mapView.MinZoom = 0;
            mapView.MaxZoom = 24;
            mapView.Zoom = 8;
            mapView.Manager.Mode = AccessMode.ServerOnly;

            mapView.OnPositionChanged += this.mapControl_PositionChanged;
            mapView.OnMapZoomChanged += this.mapControl_ZoomChanged;

            mapView.Paths = paths;

            mapParamsLat.Text = mapView.Position.Lat.ToString();
            mapParamsLong.Text = mapView.Position.Lng.ToString();

            mapParamsLat.KeyDown += mapParamsLat_Enter;
            mapParamsLong.KeyDown += mapParamsLong_Enter;

            trackingEnabled = dataPanelPositionLock.Checked;

            currentPosition = new GeoPoint(47.5, 19);
        }
        
        ////////////////////////////////////////////////////////////////////////
        // Methods

        public int AddPath() {
            paths.Add(new Path());
            return paths.Count - 1;
        }

        public void RemovePath(int index) {
            paths.RemoveAt(index);
        }

        public int GetNumPaths() {
            return paths.Count;
        }

        public Path GetPath(int index) {
            return paths[index];
        }

        void SetCurrentPosition(GeoPoint point) {
            currentPosition = point;
            if (trackingEnabled) {
                mapView.Position = new PointLatLng(currentPosition.Lat, currentPosition.Lng);
            }

            dataPanelLat.Text = currentPosition.Lat.ToString();
            dataPanelLong.Text = currentPosition.Lng.ToString();
            dataPanelAlt.Text = currentPosition.Alt.ToString();
        }


        ////////////////////////////////////////////////////////////////////////
        // Vars

        protected Map mapView = new Map();
        private bool trackingEnabled;
        private GeoPoint currentPosition;
        private List<Path> paths = new List<Path>();


        ////////////////////////////////////////////////////////////////////////
        // Event handlers

        private void mapParamsOptions_Click(object sender, EventArgs e) {
            var optionsForm = new Form_MapOptions();
            optionsForm.Provider = mapView.MapProvider;
            optionsForm.CacheMode = mapView.Manager.Mode;
            optionsForm.GMap = mapView;
            DialogResult result = optionsForm.ShowDialog(this);
            if (result == DialogResult.OK) {
                mapView.Manager.Mode = optionsForm.CacheMode;
                mapView.MapProvider = optionsForm.Provider;
            }
            optionsForm.Dispose();
        }

        private void mapControl_PositionChanged(PointLatLng position) {
            mapParamsLat.Text = position.Lat.ToString();
            mapParamsLong.Text = position.Lng.ToString();
        }

        private void mapControl_ZoomChanged() {
            mapParamsLat.Text = mapView.Position.Lat.ToString();
            mapParamsLong.Text = mapView.Position.Lng.ToString();
        }

        private void mapParamsLat_Enter(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return) {
                e.SuppressKeyPress = true;
                mapParamsLat_TextChanged();
            }
        }
        private void mapParamsLong_Enter(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return) {
                e.SuppressKeyPress = true;
                mapParamsLong_TextChanged();
            }
        }

        private void mapParamsLat_TextChanged() {
            var currentPos = mapView.Position;
            try {
                currentPos.Lat = Double.Parse(mapParamsLat.Text);
                mapView.Position = currentPos;
            }
            catch (Exception ex) {
                mapParamsLat.Text = mapView.Position.Lat.ToString();
                mapParamsLat.SelectionStart = 0;
                mapParamsLat.SelectionLength = mapParamsLat.Text.Length;
            }
        }

        private void mapParamsLong_TextChanged() {
            var currentPos = mapView.Position;
            try {
                currentPos.Lng = Double.Parse(mapParamsLong.Text);
                mapView.Position = currentPos;
            }
            catch (Exception ex) {
                mapParamsLong.Text = mapView.Position.Lng.ToString();
                mapParamsLong.SelectionStart = 0;
                mapParamsLong.SelectionLength = mapParamsLong.Text.Length;
            }
        }

        private void mapParamsZoomIn_Click(object sender, EventArgs e) {
            mapView.Zoom++;
        }

        private void mapParamZoomOut_Click(object sender, EventArgs e) {
            mapView.Zoom--;
        }

        private void dataPanelPositionLock_CheckedChanged(object sender, EventArgs e) {
            trackingEnabled = dataPanelPositionLock.Checked;
            if (trackingEnabled) {
                mapView.Position = new PointLatLng(currentPosition.Lat, currentPosition.Lng);
            }
        }

        private void dataPanelLocate_Click(object sender, EventArgs e) {
            mapView.Position = new PointLatLng(currentPosition.Lat, currentPosition.Lng);
        }

        long debugPushCounter = 0;
        private void debugPushWaypoint_Click(object sender, EventArgs e) {
            double x = Math.Sin(debugPushCounter / 6.0);
            double y = Math.Cos(debugPushCounter / 6.0);
            SetCurrentPosition(new GeoPoint(47.5 + x * debugPushCounter * 0.001, 19 + y * debugPushCounter * 0.001));
            if (GetNumPaths() == 0) {
                AddPath();
                GetPath(0).Color = Pens.Blue;
            }
            GetPath(0).Add(currentPosition);
            mapView.Refresh();
            debugPushCounter++;
        }

        private void menuItemMapOptions_Click(object sender, EventArgs e) {
            mapParamsOptions_Click(sender, e);
        }

        private void menuItemExit_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
