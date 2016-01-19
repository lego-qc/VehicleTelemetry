using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    /// <summary>
    /// Takes messages transmitted from remote site, and
    /// show them on the GUI.
    /// </summary>
    public abstract class MessageProcessor {
        public virtual IMessageProvider MessageProvider {
            get; set;
        }
    }
}
