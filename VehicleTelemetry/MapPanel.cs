using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    /// <summary>
    /// A special type of Panel which shows maps.
    /// </summary>
    public abstract class MapPanel : Panel {
        private bool follow;

        /// <summary>
        /// Current position on the map.
        /// </summary>
        public abstract GeoPoint Position {
            get; set;
        }

        /// <summary>
        /// Whether to follow new waypoint on map.
        /// </summary>
        public virtual bool Follow {
            get {
                return follow;
            }
            set {
                follow = value;
            }
        }

        /// <summary>
        /// Paths to display on the map.
        /// </summary>
        /// <remarks>
        /// Paths are show as thin lines. One may use them to represent the path of a vehicle
        /// or zones of certain type.
        /// </remarks>
        public abstract List<Path> Paths {
            get; set;
        }

        /// <summary>
        /// Shows a configuration panel to set map options.
        /// </summary>
        public abstract void ShowConfig();

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapPanel));
            this.SuspendLayout();
            // 
            // MapPanel
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MapPanel";
            this.ResumeLayout(false);

        }
    }
}
