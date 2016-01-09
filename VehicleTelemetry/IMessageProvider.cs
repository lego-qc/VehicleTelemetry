using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    public delegate void MessageHandler(Message message);
    public delegate void ListenCallback(bool result);

    public interface IMessageProvider : IDisposable {
        event MessageHandler OnMessage;

        void Listen();

        void ListenAsync(ListenCallback callback);
        void Cancel();

        void Disconnect();

        bool IsConnected { get; }
        bool IsListening { get; }
    }
}
