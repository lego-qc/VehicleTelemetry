using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    public class GeoPoint {
        private double lat, lng, alt;

        public GeoPoint(double lat = 0, double lng = 0, double alt = 0) {
            this.lat = lat;
            this.lng = lng;
            this.alt = alt;
        }

        /// <summary>
        /// Latitude of the point. Use negative value for southern hemisphere.
        /// </summary>
        public double Lat {
            get {
                return lat;
            }
            set {
                lat = value;
                if (lat < -90)
                    lat = -90;
                else if (lat > 90)
                    lat = 90;
            }
        }

        /// <summary>
        /// Longitude of the point. Use negative value for western hemisphere.
        /// Out of range values will be mapped to -180:180 with no loss of information.
        /// </summary>
        public double Lng {
            get {
                return lng;
            }
            set {
                lng = value;
                if (lng > 180) {
                    lng /= 360;
                    lng = lng - Math.Truncate(lng);
                    lng *= 360;
                    if (lng > 180)
                        lng -= 360;
                }
                else if (lng < -180) {
                    lng /= 360;
                    lng = lng - Math.Truncate(lng);
                    lng *= 360;
                    if (lng < -180)
                        lng -= 360;
                }
            }
        }

        /// <summary>
        /// Altitude of the point in meters. Sea level equals zero.
        /// Altitude cannot be less then -6 378 100m, the earth's radius.
        /// </summary>
        public double Alt {
            get {
                return alt;
            }
            set {
                alt = value;
                if (alt < -6378100.0) {
                    alt = 6378100.0; // radius of earth
                }
            }
        }


        public static double DistanceDirect(GeoPoint p1, GeoPoint p2) {
            double[] p1xyz = p1.ToXYZ();
            double[] p2xyz = p2.ToXYZ();
            double dx = p1xyz[0] - p2xyz[0];
            double dy = p1xyz[1] - p2xyz[1];
            double dz = p1xyz[2] - p2xyz[2];
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public static double DistanceArc(GeoPoint p1, GeoPoint p2) {
            throw new NotImplementedException("not implemented");
        }

        private double[] ToXYZ() {
            double r = 6378100.0 + Alt;
            return new double[] {
                r*Math.Cos(Lat / 180 * Math.PI)*Math.Cos(Lng / 180 * Math.PI),
                r*Math.Cos(Lat / 180 * Math.PI)*Math.Sin(Lng / 180 * Math.PI),
                r*Math.Sin(Lat / 180 * Math.PI)
            };
        }
    }
}
