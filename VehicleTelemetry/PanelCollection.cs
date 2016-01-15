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


            public void Add(Panel panel) {
                if (panel != null) {
                    throw new ArgumentNullException("You cannot pass null for a panel.");
                }

                // add to internal collection
                collection.Add(panel);

                // set panel to parent

            }

            public void Add(Panel panel, DockStyle dockStyle) {

            }

            public void AddRange(Panel[] panels) {
                foreach (var panel in panels) {
                    Add(panel);
                }
            }

            public void Clear() {
                collection.Clear();

                // remove all panel from parent
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
                }
                return isRemoved;
            }

            public void RemoveAt(int index) {
                var panel = collection[index];
                collection.RemoveAt(index);

                // remove from parent as well
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
    }
}
