using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    public class MessageProcessor_Map : IMessageProcessor {
        private IMessageProvider messageProvider;
        private MapPanel target;
        private HashSet<int> activeIds; /// <summary> These data message IDs should be set on map. </summary>
        private object lockObject;


        public MessageProcessor_Map() {
            lockObject = new object();
            activeIds = new HashSet<int>();
            target = null;
            messageProvider = null;
        }


        public IMessageProvider MessageProvider {
            get {
                return messageProvider;
            }
            set {
                if (messageProvider != null) {
                    messageProvider.OnMessage -= OnMessage;
                }
                messageProvider = value;
                if (messageProvider != null) {
                    messageProvider.OnMessage += OnMessage;
                }
            }
        }


        public MapPanel Target {
            get {
                return target;
            }
            set {
                lock (lockObject) {
                    target = value;
                }
            }
        }


        /// <summary>
        /// Handler for incoming messages. Demuxes them and passes them to specific handlers.
        /// </summary>
        private void OnMessage(Message msg) {
            if (target == null) {
                return;
            }
            switch (msg.Type) {
                case eMessageType.LAYOUT:
                    ProcessMessage((LayoutMessage)msg);
                    break;
                case eMessageType.DATA:
                    ProcessMessage((DataMessage)msg);
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Select which message IDs are to be set to the map.
        /// </summary>
        void ProcessMessage(LayoutMessage msg) {
            lock (lockObject) {
                activeIds.Clear();
                for (int i = 0; i < msg.Count; i++) {
                    if (msg[i].UpdateMap && msg[i].Dimension >= 2) {
                        activeIds.Add(msg[i].Id);
                    }
                }
            }
        }

        /// <summary>
        /// Set matching IDs to target map.
        /// </summary>
        void ProcessMessage(DataMessage msg) {
            lock (lockObject) {
                if (target != null && activeIds.Contains(msg.Id) && msg.Dimension >= 2) {
                    target.Invoke(new Action(() => {
                        if (msg.Dimension == 2) {
                            target.Position = new GeoPoint(msg[0], msg[1], 0);
                        }
                        else {
                            target.Position = new GeoPoint(msg[0], msg[1], msg[2]);
                        }
                    }));
                }
            }
        }
    }

}
