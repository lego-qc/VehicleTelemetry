using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VehicleTelemetry {
    /// <summary>
    /// A list of coordinates that represent a path.
    /// </summary>
    public class Path : List<GeoPoint> {
        private Color color = Color.FromArgb(255, 0, 0, 0);
        private string name = "";
		private bool visible = true;

        /// <summary>
        /// Color of the path on the map.
        /// </summary>
        public Color Color {
            get {
                return color;
            }
            set {
                color = value;
            }
        }

        /// <summary>
        /// Get or set the name of the path.
        /// </summary>
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }

		/// <summary>
		/// Set is path should be drawn on the map.
		/// </summary>
		public bool Visible {
			get {
				return visible;
			}
			set {
				visible = value;
			}
		}
    }
}
