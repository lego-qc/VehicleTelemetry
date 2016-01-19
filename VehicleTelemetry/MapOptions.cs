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

        public GMapControl GMap {
            get {
                return gmap;
            }
            set {
                gmap = value;
            }
        }

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

        private void confirmOk_Click(object sender, EventArgs e) {
            ProcessResults();
            DialogResult = DialogResult.OK;
        }

        private void confirmCancel_Click(object sender, EventArgs e) {
            ProcessResults();
            DialogResult = DialogResult.Cancel;
        }

        private void emptyCache_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("This will delete all your tile cache data.\nAre you sure?", "Delete Cache", MessageBoxButtons.YesNo);
            if (gmap != null && result == DialogResult.Yes) {
                gmap.Manager.PrimaryCache.DeleteOlderThan(DateTime.Now, null);
            }
        }

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
