using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    public abstract class MapPanel : Panel {
        public virtual GeoPoint Position {
            get; set;
        }
        public virtual List<Path> Paths {
            get; set;
        }
    }
}
