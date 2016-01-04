﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    public delegate void MessageHandler(Message message);

    interface IMessageProvider {
        event MessageHandler OnMessage;
    }
}
