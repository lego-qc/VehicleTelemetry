using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    public delegate void MessageHandler(Message message);
    public delegate void ListenCallback(bool result);

    /// <summary>
    /// Message providers establish connections from where they receive messages.
    /// </summary>
    /// <remarks>
    /// A message provider represents a connection to the observed object (e.g. quadcopter or r/c car), 
    /// and collect telemetry data in the form of messages. Messages are later processed and displayed.
    /// <see cref="Message"/> for more.
    /// </remarks>
    public interface IMessageProvider : IDisposable {
        /// <summary>
        /// Fired when a message is received over network.
        /// </summary>
        event MessageHandler OnMessage;

        /// <summary>
        /// True if connection is alive.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// True if listening is in progress.
        /// </summary>
        bool IsListening { get; }

        /// <summary>
        /// Listen for incoming connections.
        /// </summary>
        void Listen();

        /// <summary>
        /// Listen for incoming connections asynchronously
        /// </summary>
        /// <param name="callback">Called when there's a connection or an error occured.</param>
        void ListenAsync(ListenCallback callback);

        /// <summary>
        /// Cancels listening.
        /// </summary>
        void Cancel();

        /// <summary>
        /// Closes connection.
        /// </summary>
        void Disconnect();
    }
}
