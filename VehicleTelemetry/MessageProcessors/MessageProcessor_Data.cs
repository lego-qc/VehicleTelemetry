using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    /// <summary>
    /// Processes messages that are important for a DataPanel.
    /// </summary>
    public class MessageProcessor_Data : IMessageProcessor {
        /// <summary>
        /// The message source.
        /// </summary>
        private IMessageProvider messageProvider;
        /// <summary>
        /// Which panel to display messages on.
        /// </summary>
        private DataPanel target;
        /// <summary>
        /// Links message IDs to the index of snippets on the data panel.
        /// </summary>
        private Dictionary<int, int> idToIndexMapping;
        /// <summary>
        /// Lock this to protect internal resources. Invokes and async providers create a threading mess, better be safe.
        /// </summary>
        private object lockObject = new object();


        public MessageProcessor_Data(IMessageProvider provider = null, DataPanel target = null) {
            MessageProvider = provider;
            Target = target;

            idToIndexMapping = new Dictionary<int, int>();
        }

        /// <summary>
        /// Assign a message source.
        /// </summary>
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

        /// <summary>
        /// Which panel to display stuff on.
        /// </summary>
        public DataPanel Target {
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
        /// Handle message events. Demuxes by message type, and forwards messages.
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
        /// Set layouts to data panel.
        /// </summary>
        private void ProcessMessage(LayoutMessage msg) {
            lock (lockObject) {
                if (target != null) {
                    target.Invoke(new Action(() => {
                        target.Count = msg.Count;
                        idToIndexMapping.Clear();
                        for (int i = 0; i < msg.Count; i++) {
                            target[i].Title = msg[i].Name;
                            target[i].Count = msg[i].Dimension;
                            for (int j = 0; j < msg[i].Dimension; j++) {
                                target[i].Labels[j] = msg[i][j];
                            }
                            idToIndexMapping.Add(msg[i].Id, i);
                        }
                    }));
                }
            }
        }

        /// <summary>
        /// Set values to data panel.
        /// </summary>
        private void ProcessMessage(DataMessage msg) {
            string error = null;
            try {
                lock (lockObject) {
                    if (target != null) {
                        int index = idToIndexMapping[msg.Id];
                        target.Invoke(new Action(() => {
                            int mindex = Math.Min(msg.Dimension, target[index].Count);
                            for (int i = 0; i < mindex; i++) {
                                target[index].Values[i] = msg[i].ToString();
                            }
                        }));
                    }
                }
            }
            catch (KeyNotFoundException e) {
                error = "Message ID was not specified in previous layout message.";
            }
            catch (Exception e) {

            }
        }
    }
}
