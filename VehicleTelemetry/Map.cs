using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace VehicleTelemetry {
    public class Map : GMap.NET.WindowsForms.GMapControl {
        private List<Path> paths = new List<Path>();

        public List<Path> Paths {
            get {
                return paths;
            }
            set {
                paths = value;
            }
        }

        protected override void OnPaintOverlays(Graphics g) {
            base.OnPaintOverlays(g);

            if (paths != null) {
                foreach (Path path in paths) {
                    for (int i = 0; i < path.Count - 1; i++) {
                        PointLatLng p = new PointLatLng();
                        p.Lat = path[i].Lat;
                        p.Lng = path[i].Lng;
                        GPoint gp1 = FromLatLngToLocal(p);
                        p.Lat = path[i + 1].Lat;
                        p.Lng = path[i + 1].Lng;
                        GPoint gp2 = FromLatLngToLocal(p);
                        g.DrawLine(path.Color, gp1.X, gp1.Y, gp2.X, gp2.Y);
                    }
                }
            }
        }
    }
}
