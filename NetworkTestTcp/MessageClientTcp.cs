using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTelemetry;
using System.Net;
using System.Net.Sockets;

namespace NetworkTestTcp {
    class MessageClientTcp : IDisposable {
        public MessageClientTcp() {
            socket = new Socket(SocketType.Stream, ProtocolType.IP);
            socket.NoDelay = true;
        }

        private Socket socket;


        public void Connect(string address, int port) {
            try {
                IPHostEntry entry = Dns.GetHostEntry(address);
                if (entry.AddressList.Length == 0) {
                    throw new ArgumentException("Host name could not be resolved.");
                }
                socket.Connect(new IPEndPoint(entry.AddressList[0], port));                                
            }
            catch (Exception ex) {
                throw;
            }
        }


        public void Disconnect() {
            socket.Disconnect(true);
        }

        public void Send(Message msg) {
            if (!socket.Connected) {
                throw new InvalidOperationException("Must be connected first.");
            }

            byte[] size = new byte[2];
            byte[] data = null;
            byte[] checksum = new byte[4];

            data = msg.Serialize();
            size[0] = (byte)(data.Length << 8);
            size[1] = (byte)(data.Length);
            for (int i = 0; i < checksum.Length; i++) {
                checksum[i] = 0;
            }

            socket.Send(size);
            socket.Send(data);
            socket.Send(checksum);
        }

        public void Dispose() {
            socket.Dispose();
        }
    }
}
