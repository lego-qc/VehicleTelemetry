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
        /// <summary>
        /// Current position on the map.
        /// </summary>
        public abstract GeoPoint Position {
            get; set;
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
    }
}
