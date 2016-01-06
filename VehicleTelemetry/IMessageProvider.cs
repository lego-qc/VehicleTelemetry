using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    public delegate void MessageHandler(Message message);

    public interface IMessageProvider {
        event MessageHandler OnMessage;
    }

}
