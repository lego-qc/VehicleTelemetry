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
using GMap.NET.WindowsForms.ToolTips;


namespace VehicleTelemetry {
    /// <summary>
    /// Configuration panel for GMapPanels.
    /// </summary>
    /// <remarks><see cref="GMapPanel"/> for more.</remarks>
    public partial class MapOptions : Form {
        private AccessMode cacheMode;
        private GMapProvider provider;
        private GMapControl gmap;

        public MapOptions() {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
            foreach (var provider in GMapProviders.List) {
                mapProviderSelector.Items.Add(new ProviderItem(provider));
            }
        }

        /// <summary>
        /// Configure cache mode. Three modes are available:
        /// network only, local cache only and hybrid.
        /// </summary>
        public AccessMode CacheMode {
            get {
                return cacheMode;
            }
            set {
                cacheMode = value;
                switch (cacheMode) {
                    case AccessMode.ServerOnly:
                        cacheModeSelector.SelectedIndex = 1;
                        break;
                    case AccessMode.ServerAndCache:
                        cacheModeSelector.SelectedIndex = 2;
                        break;
                    case AccessMode.CacheOnly:
                        cacheModeSelector.SelectedIndex = 0;
                        break;
                }
            }
        }

        /// <summary>
        /// Set the currently used provider service. This may be null.
        /// After closing the dialog, this property contains the
        /// newly chosen provider.
        /// </summary>
        public GMapProvider Provider {
            get {
                return provider;
            }
            set {
                provider = value;
                int index = -1;
                for (int i=0; i<mapProviderSelector.Items.Count; i++) {
                    if (((ProviderItem)mapProviderSelector.Items[i]).provider.Id == provider.Id) {
                        index = i;
                    }
                }
                if (index < 0) {
                    var newItem = new ProviderItem(provider);
                    mapProviderSelector.Items.Add(newItem);
                    index = mapProviderSelector.Items.IndexOf(newItem);
                }
                mapProviderSelector.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Set the GMap control itself. This refernce is not changed, but
        /// the control is configured.
        /// </summary>
        public GMapControl GMap {
            get {
                return gmap;
            }
            set {
                gmap = value;
            }
        }

        /// <summary>
        /// Set properties according to stuff selected on the GUI.
        /// </summary>
        private void ProcessResults() {
            provider = ((ProviderItem)mapProviderSelector.SelectedItem).provider;
            int cacheIndex = cacheModeSelector.SelectedIndex;
            switch (cacheIndex) {
                case 0:
                    cacheMode = AccessMode.CacheOnly;
                    break;
                case 1:
                    cacheMode = AccessMode.ServerOnly;
                    break;
                case 2:
                    cacheMode = AccessMode.ServerAndCache;
                    break;
                default:
                    cacheMode = AccessMode.CacheOnly;
                    break;
            }
        }

        /// <summary>
        /// Runs when you click OK. Closes the dialog and reads changes from GUI.
        /// </summary>
        private void confirmOk_Click(object sender, EventArgs e) {
            ProcessResults();
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Runs when you click cancel. Closes the dialog and reads changes from GUI, but returns cancel.
        /// </summary>
        private void confirmCancel_Click(object sender, EventArgs e) {
            ProcessResults();
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Empties the cache of GMap.
        /// </summary>
        private void emptyCache_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("This will delete all your tile cache data.\nAre you sure?", "Delete Cache", MessageBoxButtons.YesNo);
            if (gmap != null && result == DialogResult.Yes) {
                gmap.Manager.PrimaryCache.DeleteOlderThan(DateTime.Now, null);
            }
        }

        /// <summary>
        /// Just a little shit that stores a GMapProvider and can be thrown into a combobox.
        /// </summary>
        protected class ProviderItem {
            public GMapProvider provider;
            public ProviderItem(GMapProvider provider) {
                this.provider = provider;
            }
            public override string ToString() {
                return provider.Name;
            }
        }
    }
}
