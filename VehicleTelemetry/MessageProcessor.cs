using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    public abstract class MessageProcessor {
        public virtual IMessageProvider MessageProvider {
            get; set;
        }
    }
}
