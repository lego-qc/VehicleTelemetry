using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VehicleTelemetry {
    public class MessageProviderSerial : IMessageProvider {
        private SerialPort port;


        /// <summary>
        /// Initialize with default serial port parameters.
        /// </summary>
        public MessageProviderSerial() {
            port = new SerialPort();
        }


        /// <summary>
        /// True is the provider is connected to remote peer.
        /// </summary>
        public bool IsConnected {
            get {
                return port.IsOpen;
            }
        }

        /// <summary>
        /// Always false. This implementation omits the listening stage and connects instantaneously.
        /// </summary>
        public bool IsListening {
            get {
                return false; // this provider never actually listens, it always just connects
            }
        }

        /// <summary>
        /// Get or set assigned serial port's name.
        /// </summary>
        /// <exception cref="InvalidOperationException">Port is already open.</exception>
        /// <exception cref="ArgumentNullException">Port name must not be null.</exception>
        /// <exception cref="ArgumentException">Invalid port name.</exception>
        public string PortName {
            get {
                return port.PortName;
            }
            set {
                port.PortName = value;
            }
        }

        /// <summary>
        /// Get or set serial baud rate.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The baud rate is zero or too high for that device.</exception>
        /// <exception cref="IOException">The port is in an invalid state.</exception>
        public int BaudRate {
            get {
                return port.BaudRate;
            }
            set {
                port.BaudRate = value;
            }
        }

        /// <summary>
        /// Get or set the number of data bits. Must be between 5 and 8 (both inclusive).
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Must be between 5 and 8 (both inclusive).</exception>
        /// <exception cref="IOException">The port is in an invalid state.</exception>
        public int DataBits {
            get {
                return port.DataBits;
            }
            set {
                port.DataBits = value;
            }
        }

        /// <summary>
        /// Get or set stop bit style. StopBits.None is not supported.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">StopBits.None is not supported.</exception>
        /// <exception cref="IOException">The port is in an invalid state.</exception>
        public StopBits StopBits {
            get {
                return port.StopBits;
            }
            set {
                port.StopBits = value;
            }
        }

        /// <summary>
        /// Get or set parity bit style.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">This is C# and you managed to fuck up... Idiot.</exception>
        /// <exception cref="IOException">The port is in an invalid state.</exception>
        public Parity Parity {
            get {
                return port.Parity;
            }
            set {
                port.Parity = value;
            }
        }


        /// <summary>
        /// Register
        /// </summary>
        public event MessageHandler OnMessage;

        /// <summary>
        /// Unused. There's no listening stage with serial ports.
        /// </summary>
        public void Cancel() {
            return;
        }

        /// <summary>
        /// Closes the serial port connection, no more messages are collected.
        /// </summary>
        public void Disconnect() {
            try {
                port.Close();
            }
            catch (Exception ex) {
                // swallow
            }
        }

        /// <summary>
        /// Releases all internal resources. Cannot be reused after calling Dispose.
        /// </summary>
        public void Dispose() {
            port.Dispose();
        }

        /// <summary>
        /// Get a configurator GUI panel the user can use to set parameters of this object.
        /// </summary>
        /// <returns>A configurator initialized with this instance.</returns>
        public UserControl GetConfigurator() {
            return new MessageProviderSerial_Config(this);
        }

        /// <summary>
        /// Deprecated.
        /// </summary>
        public void Listen() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Listens for incoming connections. Listening state practically does not exist, so it
        /// instantly goes into connected state.
        /// </summary>
        /// <exception cref="UnauthorizedAccessException">Access is denied or port is already open by another process.</exception>
        /// <exception cref="ArgumentOutOfRangeException">One or more properties of the instance are invalid.</exception>
        /// <exception cref="ArgumentException">name does not begin with "COM" or file type of port is not supported.</exception>
        /// <exception cref="IOException">The port is in an invalid state.</exception>
        /// <exception cref="InvalidOperationException">The port is already open by this instance.</exception>
        public void ListenAsync(ListenCallback callback) {
            port.Open();            
        }
    }
}
