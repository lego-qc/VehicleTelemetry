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
        private Pen color = Pens.Red;

        /// <summary>
        /// Color of the path on the map.
        /// </summary>
        public Pen Color {
            get {
                return color;
            }
            set {
                color = value;
            }
        }
    }
}
