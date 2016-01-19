using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleTelemetry {
    public partial class TelemetryControl {
        /// <summary>
        /// Collection of the panels displayed on a TelemetryControl.
        /// </summary>
        public class PanelCollection {
            private List<Panel> collection;
            private TelemetryControl owner;

            /// <summary>
            /// This should be accessible only to TelemetryControl.
            /// </summary>
            public PanelCollection(TelemetryControl owner) {
                collection = new List<Panel>();
                this.owner = owner;
            }

            /// <summary>
            /// Number of panels currently associated.
            /// </summary>
            public int Count {
                get {
                    return collection.Count;
                }
            }
            
            /// <summary>
            /// Get owner of this collection.
            /// </summary>
            public Control Owner {
                get {
                    return owner;
                }
            }

            /// <summary>
            /// Get panel by index.
            /// </summary>
            public Control this[int index] {
                get {
                    return collection[index];
                }
            }

            /// <summary>
            /// Get panel by its Name property.
            /// </summary>
            public Panel this[string key] {
                get {
                    foreach (var panel in collection) {
                        if (panel.Name == key) {
                            return panel;
                        }
                    }
                    throw new ArgumentOutOfRangeException("Panel with the specified key not found.");
                }
            }

            /// <summary>
            /// Add a new panel.
            /// </summary>
            /// <param name="panel">The panel to add.</param>
            /// <param name="dockState">Where to dock the panel on the owner.</param>
            public void Add(Panel panel, DockState dockState = DockState.Float) {
                if (panel == null) {
                    throw new ArgumentNullException("You cannot pass null for a panel.");
                }

                // add to internal collection
                collection.Add(panel);

                // set panel to parent
                owner.AddPanel(panel, dockState);
            }

            /// <summary>
            /// Add multiple panels at once.
            /// </summary>
            public void AddRange(Panel[] panels) {
                foreach (var panel in panels) {
                    Add(panel);
                }
            }

            /// <summary>
            /// Remove all panels.
            /// </summary>
            public void Clear() {
                // remove all panel from parent
                foreach (var panel in collection) {
                    owner.RemovePanel(panel);
                }

                collection.Clear();
            }

            /// <summary>
            /// Check if collection contains reference to given panel.
            /// </summary>
            public bool Contains(Panel panel) {
                return collection.Contains(panel);
            }

            /// <summary>
            /// Check if collection contains panel with given Name.
            /// </summary>
            public bool ContainsKey(string key) {
                foreach (var panel in collection) {
                    if (panel.Name == key) {
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// Enumerate panels.
            /// </summary>
            public IEnumerator<Panel> GetEnumerator() {
                return collection.GetEnumerator();
            }

            /// <summary>
            /// Get index of panel by reference.
            /// </summary>
            public int IndexOf(Panel panel) {
                return collection.IndexOf(panel);
            }

            /// <summary>
            /// Get index of panel by Name.
            /// </summary>
            public int IndexOfKey(string key) {
                for (int i = 0; i < collection.Count; i++) {
                    if (collection[i].Name == key) {
                        return i;
                    }
                }
                return -1;
            }

            /// <summary>
            /// Remove panel by reference.
            /// </summary>
            public bool Remove(Panel panel) {
                bool isRemoved = collection.Remove(panel);
                if (isRemoved) {
                    // remove from parent as well
                    owner.RemovePanel(panel);
                }
                return isRemoved;
            }

            /// <summary>
            /// Remove panel by index.
            /// </summary>
            public void RemoveAt(int index) {
                var panel = collection[index];
                collection.RemoveAt(index);

                // remove from parent as well
                owner.RemovePanel(panel);
            }

            /// <summary>
            /// Remove all panels with the specified Name.
            /// </summary>
            public void RemoveByKey(string key) {
                List<Panel> toRemove = new List<Panel>();
                foreach (var panel in collection) {
                    if (panel.Name == key) {
                        toRemove.Add(panel);
                    }
                }
                foreach (var panel in toRemove) {
                    Remove(panel);
                }
            }            
        }

        /// <summary>
        /// Where to dock panels on the parent form.
        /// </summary>
        public enum DockState {
            Float = WeifenLuo.WinFormsUI.Docking.DockState.Float,
            Hidden = WeifenLuo.WinFormsUI.Docking.DockState.Hidden,
            Unknown = WeifenLuo.WinFormsUI.Docking.DockState.Unknown,

            DockBottom          = WeifenLuo.WinFormsUI.Docking.DockState.DockBottom,
            DockBottomAutoHide  = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide,
            DockLeft            = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft,
            DockLeftAutoHide    = WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide,
            DockRight           = WeifenLuo.WinFormsUI.Docking.DockState.DockRight,
            DockRightAutoHide   = WeifenLuo.WinFormsUI.Docking.DockState.DockRightAutoHide,
            DockTop             = WeifenLuo.WinFormsUI.Docking.DockState.DockTop,
            DockTopAutoHide     = WeifenLuo.WinFormsUI.Docking.DockState.DockTopAutoHide,
            Document            = WeifenLuo.WinFormsUI.Docking.DockState.Document,
        }
    }
}
