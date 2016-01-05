using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VehicleTelemetry {
    public class Path : List<GeoPoint> {
        private Pen color = Pens.Red;

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
