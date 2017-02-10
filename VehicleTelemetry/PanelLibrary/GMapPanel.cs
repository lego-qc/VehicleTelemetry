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

namespace VehicleTelemetry {
    /// <summary>
    /// A two-dimensional map panel based on GMap.Net.
    /// </summary>
    /// <remarks>
    /// <see cref="Panel"/> for more about what a panel is.
    /// <see cref="TelemetryControl"/> for more about how panels are used.
    /// </remarks>
    public partial class GMapPanel : MapPanel {
        private GeoPoint position;
        protected GMapExtended map = new GMapExtended();

        public GMapPanel() {
            InitializeComponent();

            map.MapProvider = GMapProviders.OpenStreetMap;
            map.Position = new PointLatLng(47.5, 19);
            map.MinZoom = 0;
            map.MaxZoom = 24;
            map.Zoom = 8;
            map.Manager.Mode = AccessMode.ServerOnly;

            map.OnPositionChanged += this.mapControl_PositionChanged;
            map.OnMapZoomChanged += this.mapControl_ZoomChanged;

            map.Paths = Paths;

            mapParamsLat.Text = map.Position.Lat.ToString();
            mapParamsLong.Text = map.Position.Lng.ToString();

            mapParamsLat.KeyDown += mapParamsLat_Enter;
            mapParamsLong.KeyDown += mapParamsLong_Enter;

            mapDisplayPanel.Controls.Add(map);
            map.Dock = DockStyle.Fill;

            map.DisableFocusOnMouseEnter = true;

            position = new GeoPoint(47.5, 19);
        }

        /// <summary>
        /// Geographical position currently shown on the map.
        /// </summary>
        public override GeoPoint Position {
            get {
                return position;
            }
            set {
                position = value;
                map.Position = new PointLatLng(position.Lat, position.Lng);
            }
        }

        /// <summary>
        /// Shows the configuration panel for the map panel.
        /// </summary>
        public override void ShowConfig() {
            mapParamsOptions_Click(null, null);
        }


        /// <summary>
        /// Handler for when the underlying GMap.Net form's position changes.
        /// </summary>
        /// <param name="position">Current position given by the GMap.Net form.</param>
        private void mapControl_PositionChanged(PointLatLng position) {
            mapParamsLat.Text = position.Lat.ToString();
            mapParamsLong.Text = position.Lng.ToString();
        }

        /// <summary>
        /// Handler for when the underlying GMap.Net form's zoom changes.
        /// </summary>
        private void mapControl_ZoomChanged() {
            mapParamsLat.Text = map.Position.Lat.ToString();
            mapParamsLong.Text = map.Position.Lng.ToString();
        }

        /// <summary>
        /// Handler for the button to show config panel.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Unused.</param>
        private void mapParamsOptions_Click(object sender, EventArgs e) {
            var optionsForm = new MapOptions();
            optionsForm.StartPosition = FormStartPosition.CenterParent;
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

        /// <summary>
        /// Handler for the Zoom In button.
        /// </summary>
        private void mapParamsZoomIn_Click(object sender, EventArgs e) {
            map.Zoom++;
        }

        /// <summary>
        /// Handler for the Zoom Out button.
        /// </summary>
        private void mapParamZoomOut_Click(object sender, EventArgs e) {
            map.Zoom--;
        }

        /// <summary>
        /// Handler for the position edit boxes. Commits the typed text.
        /// </summary>
        private void mapParamsLat_Enter(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return) {
                e.SuppressKeyPress = true;
                mapParamsLat_TextChanged();
            }
        }

        /// <summary>
        /// Handler for the position edit boxes. Commits the typed text.
        /// </summary>
        private void mapParamsLong_Enter(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return) {
                e.SuppressKeyPress = true;
                mapParamsLong_TextChanged();
            }
        }

        /// <summary>
        /// Processes the position edit boxes' text.
        /// </summary>
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

        /// <summary>
        /// Processes the position edit boxes' text.
        /// </summary>
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
