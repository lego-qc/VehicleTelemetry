using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
    public partial class MapView : UserControl {
        public MapView() {
            InitializeComponent();

            map.MapProvider = GMapProviders.OpenStreetMap;
            map.Position = new PointLatLng(47.5, 19);
            map.MinZoom = 0;
            map.MaxZoom = 24;
            map.Zoom = 8;
            map.Manager.Mode = AccessMode.ServerOnly;

            map.OnPositionChanged += this.mapControl_PositionChanged;
            map.OnMapZoomChanged += this.mapControl_ZoomChanged;

            map.Paths = paths;

            mapParamsLat.Text = map.Position.Lat.ToString();
            mapParamsLong.Text = map.Position.Lng.ToString();

            mapParamsLat.KeyDown += mapParamsLat_Enter;
            mapParamsLong.KeyDown += mapParamsLong_Enter;

            mapDisplayPanel.Controls.Add(map);
            map.Dock = DockStyle.Fill;

            position = new GeoPoint(47.5, 19);
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

        public void ShowOptions() {
            mapParamsOptions_Click(null, null);
        }


        ////////////////////////////////////////////////////////////////////////
        // Vars

        protected Map map = new Map();
        private List<Path> paths = new List<Path>();
        private GeoPoint position;

        public GeoPoint Position {
            get {
                return position;
            }
            set {
                position = value;
                map.Position = new PointLatLng(position.Lat, position.Lng);
            }
        }


        ////////////////////////////////////////////////////////////////////////
        // Event handlers

        private void mapControl_PositionChanged(PointLatLng position) {
            mapParamsLat.Text = position.Lat.ToString();
            mapParamsLong.Text = position.Lng.ToString();
        }

        private void mapControl_ZoomChanged() {
            mapParamsLat.Text = map.Position.Lat.ToString();
            mapParamsLong.Text = map.Position.Lng.ToString();
        }

        private void mapParamsOptions_Click(object sender, EventArgs e) {
            var optionsForm = new Form_MapOptions();
            optionsForm.Provider = map.MapProvider;
            optionsForm.CacheMode = map.Manager.Mode;
            optionsForm.GMap = map;
            DialogResult result = optionsForm.ShowDialog(this);
            if (result == DialogResult.OK) {
                map.Manager.Mode = optionsForm.CacheMode;
                map.MapProvider = optionsForm.Provider;
            }
            optionsForm.Dispose();
        }

        private void mapParamsZoomIn_Click(object sender, EventArgs e) {
            map.Zoom++;
        }

        private void mapParamZoomOut_Click(object sender, EventArgs e) {
            map.Zoom--;
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
            var currentPos = map.Position;
            try {
                currentPos.Lat = Double.Parse(mapParamsLat.Text);
                map.Position = currentPos;
            }
            catch (Exception ex) {
                mapParamsLat.Text = map.Position.Lat.ToString();
                mapParamsLat.SelectionStart = 0;
                mapParamsLat.SelectionLength = mapParamsLat.Text.Length;
            }
        }

        private void mapParamsLong_TextChanged() {
            var currentPos = map.Position;
            try {
                currentPos.Lng = Double.Parse(mapParamsLong.Text);
                map.Position = currentPos;
            }
            catch (Exception ex) {
                mapParamsLong.Text = map.Position.Lng.ToString();
                mapParamsLong.SelectionStart = 0;
                mapParamsLong.SelectionLength = mapParamsLong.Text.Length;
            }
        }
    }
}
