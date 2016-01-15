using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleTelemetry {
    public partial class TelemetryControl {
        public class PanelCollection {
            public PanelCollection(TelemetryControl owner) {
                collection = new List<Panel>();
                this.owner = owner;
            }

            public int Count {
                get {
                    return collection.Count;
                }
            }

            public Control this[int index] {
                get {
                    return collection[index];
                }
            }

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

            public Control Owner {
                get {
                    return owner;
                }
            }

            public void Add(Panel panel, DockState dockState = DockState.Float) {
                if (panel == null) {
                    throw new ArgumentNullException("You cannot pass null for a panel.");
                }

                // add to internal collection
                collection.Add(panel);

                // set panel to parent
                owner.AddPanel(panel, dockState);
            }

            public void AddRange(Panel[] panels) {
                foreach (var panel in panels) {
                    Add(panel);
                }
            }

            public void Clear() {
                // remove all panel from parent
                foreach (var panel in collection) {
                    owner.RemovePanel(panel);
                }

                collection.Clear();
            }

            public bool Contains(Panel panel) {
                return collection.Contains(panel);
            }

            public bool ContainsKey(string key) {
                foreach (var panel in collection) {
                    if (panel.Name == key) {
                        return true;
                    }
                }
                return false;
            }

            public IEnumerator<Panel> GetEnumerator() {
                return collection.GetEnumerator();
            }

            public int IndexOf(Panel panel) {
                return collection.IndexOf(panel);
            }

            public int IndexOfKey(string key) {
                for (int i = 0; i < collection.Count; i++) {
                    if (collection[i].Name == key) {
                        return i;
                    }
                }
                return -1;
            }

            public bool Remove(Panel panel) {
                bool isRemoved = collection.Remove(panel);
                if (isRemoved) {
                    // remove from parent as well
                    owner.RemovePanel(panel);
                }
                return isRemoved;
            }

            public void RemoveAt(int index) {
                var panel = collection[index];
                collection.RemoveAt(index);

                // remove from parent as well
                owner.RemovePanel(panel);
            }

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

            private List<Panel> collection;
            private TelemetryControl owner;

            
        }


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
