using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleTelemetry;

namespace VehicleTelemetryApp {
    public partial class AppMainForm : TelemetryControl {
        private DataPanel dataPanel;
        private MapPanel mapPanel;
        private VideoPanel videoPanel;
        private QuickTools quickTools;

        public AppMainForm() {
            InitializeComponent();

            // merge menu strips
            foreach (ToolStripMenuItem menuItem in menuStrip1.Items) {
                menuItem.MergeAction = MergeAction.Append;
            }
            toolsToolStripMenuItem.MergeAction = MergeAction.MatchOnly;
            ToolStripManager.Merge(menuStrip1, base.MenuStrip);
            menuStrip1.Visible = false;

            // create panels
            dataPanel = new DataPanel();
            mapPanel = new GMapPanel();
            videoPanel = new DummyVideoPanel();
            quickTools = new QuickTools();
            dataPanel.Text = "Telemetry Data";
            mapPanel.Text = "Map";
            videoPanel.Text = "Dummy Video (not working)";
            quickTools.Text = "Quick Tools";
            Panels.Add(dataPanel, DockState.DockRight);
            Panels.Add(mapPanel, DockState.Document);
            Panels.Add(videoPanel, DockState.Document);
            Panels.Add(quickTools, DockState.DockLeft);

            // create message processors
            messageProcessorData = new MessageProcessor_Data();
            messageProcessorPath = new MessageProcessor_Path();
            messageProcessorMap = new MessageProcessor_Map();
            messageProcessorData.Target = dataPanel;
            messageProcessorPath.Target = this;
            messageProcessorMap.Target = mapPanel;

            // register handlers
            Paths.CollectionChanged += OnPathsChanged;

            // path test stuff
            //Path testpath = new Path();
            //testpath.Name = "Path 1";
            //testpath.Add(new GeoPoint(47, 19));
            //testpath.Add(new GeoPoint(47, 20));
            //Path testpath2 = new Path();
            //testpath2.Name = "Path 2";
            //testpath2.Add(new GeoPoint(47, 19));
            //testpath2.Add(new GeoPoint(48, 19));
            //quickTools.AddPath(testpath);
            //quickTools.AddPath(testpath2);
            //mapPanel.Paths.Add(testpath2);

            // init quick tools
            quickTools.AddMap(mapPanel);
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e) {
            var connectionForm = new ConnectionForm();
            connectionForm.StartPosition = FormStartPosition.CenterParent;
            connectionForm.Processors = new IMessageProcessor[] { messageProcessorPath, messageProcessorData, messageProcessorMap };
            connectionForm.Provider = messageProvider;
            connectionForm.ShowDialog();
            messageProvider = connectionForm.Provider;
        }

        private void appSettingsToolStripMenuItem_Click(object sender, EventArgs e) {
            var preferencesForm = new PreferencesForm();
            preferencesForm.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = preferencesForm.ShowDialog();
        }


        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e) {
            if (messageProvider != null) {
                messageProvider.Disconnect();
            }
        }

        private void OnPathsChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs args) {
            switch (args.Action) {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (var newPath in args.NewItems) {
                        quickTools.AddPath((Path)newPath);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (var removedPath in args.OldItems) {
                        quickTools.RemovePath((Path)removedPath);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    foreach (var replacedPath in args.OldItems) {
                        quickTools.RemovePath((Path)replacedPath);
                    }
                    foreach (var newPath in args.NewItems) {
                        quickTools.AddPath((Path)newPath);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    quickTools.ClearPaths();
                    foreach (var path in Paths) {
                        quickTools.AddPath(path);
                    }
                    break;
                default:
                    break;
            }
        }


        private IMessageProvider messageProvider;
        private MessageProcessor_Path messageProcessorPath;
        private MessageProcessor_Data messageProcessorData;
        private MessageProcessor_Map messageProcessorMap;
    }
}
