using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace QCTracker {
    public class NetworkInterface {

        public void Listen() {

        }

        public void Close() {

        }
        

        private TcpClient socket;
        private TcpListener listener;
        private ushort listenPort;

        public ushort ListenPort {
            get {
                return listenPort;
            }
            set {
                listenPort = value;
            }
        }
    }
}
