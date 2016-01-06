using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace VehicleTelemetry {
    public class MessageProviderTcp : IMessageProvider {
        static MessageProviderTcp() {
            MessageProviderFactory.RegisterClass<MessageProviderTcp>("Tcp");
        }

        protected class AsyncStateObject {
            public AsyncStateObject(ReadMessagePhase next, int numBytesToRead) {
                this.next = next;
                this.numBytesToRead = numBytesToRead;
            }
            public ReadMessagePhase next;
            public int numBytesToRead;
        }


        public MessageProviderTcp() : this(5640) {
            // empty on purpose
        }

        public MessageProviderTcp(ushort port) {
            listener = TcpListener.Create(port);
            socket = null;
        }

        public void Listen() {
            if (Connected) {
                throw new InvalidOperationException("Already connected.");
            }

            try {
                // accept incoming connection
                listener.Start();
                socket = listener.AcceptSocket();

                StartMessaging();
            }
            catch (Exception ex) {
                throw;
            }
            finally {
                listener.Stop();
            }
        }

        public void Close() {
            StopMessaging();
            if (socket != null) {
                socket.Close();
            }
        }

        private Socket socket;
        private TcpListener listener;
        private object lockObject = new object();
        private volatile bool isMessaging;
        private byte[] sizeBuffer = new byte[2];
        private byte[] checksumBuffer = new byte[4];
        private byte[] dataBuffer = null;
        public event MessageHandler OnMessage;

        protected delegate void ReadMessagePhase();

        public ushort ListenPort {
            get {
                return (ushort)((IPEndPoint)listener.LocalEndpoint).Port;
            }
            set {
                ((IPEndPoint)listener.LocalEndpoint).Port = value;
            }
        }

        public bool Connected {
            get {
                return socket != null && socket.Connected;
            }
        }

        private void StartMessaging() {
            isMessaging = true;
            ReadMessageSize();
        }

        private void StopMessaging() {
            isMessaging = false;
        }

        private void ReadMessageSize() {
            try {
                socket.BeginReceive(sizeBuffer, 0, 2, SocketFlags.None, ReadCallback, new AsyncStateObject(ReadMessage, 2));
            }
            catch (Exception ex) {
                // handle socket error
                // ...
                StopMessaging();
            }
        }

        private void ReadMessage() {
            // decode size
            int size = (sizeBuffer[0] << 8) + sizeBuffer[1];
            dataBuffer = new byte[size];

            try {
                socket.BeginReceive(dataBuffer, 0, size, SocketFlags.None, ReadCallback, new AsyncStateObject(ReadCheckSum, size));
            }
            catch (Exception ex) {
                // handle socket error
                // ...
                StopMessaging();
            }
        }

        private void ReadCheckSum() {
            try {
                socket.BeginReceive(checksumBuffer, 0, 4, SocketFlags.None, ReadCallback, new AsyncStateObject(CommitMessage, 4));
            }
            catch (Exception ex) {
                // handle socket error
                // ...
                StopMessaging();
            }
        }

        private void CommitMessage() {
            // decode values
            uint checksum = ((uint)checksumBuffer[0] << 24) + ((uint)checksumBuffer[1] << 16) + ((uint)checksumBuffer[2] << 8) + (uint)checksumBuffer[3];

            // verify checksum
            bool isChecksumOk;
            if (checksum == 0) {
                isChecksumOk = true;
            }
            else {
                // TODO: compute actual cheksum, including sizeBuffer
                isChecksumOk = true;
            }

            if (!isChecksumOk) {
                // handle checksum error
                // ...
                StopMessaging();
            }

            // decode message
            Message msg = Message.Deserialize(dataBuffer);
            if (msg == null) {
                // handle deserialization error
                // ...
                StopMessaging();
            }

            // fire event
            OnMessage(msg);

            // get next message
            if (isMessaging) {
                ReadMessageSize();
            }
        }

        private void ReadCallback(IAsyncResult result) {
            int read = socket.EndReceive(result);
            AsyncStateObject state = (AsyncStateObject)result.AsyncState;
            if (read != state.numBytesToRead) {
                // handle read error
                // ...
                StopMessaging();
            }
            else if (isMessaging) {
                state.next();
            }
        }
    }
}
