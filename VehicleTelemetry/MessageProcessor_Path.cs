using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    /// <summary>
    /// Modifies paths according to messages it receives.
    /// </summary>
    public class MessageProcessor_Path : MessageProcessor {
        private IMessageProvider messageProvider;
        private TelemetryControl target;
        /// <summary>
        /// Maps path IDs to indices in target's path list.
        /// </summary>
        private Dictionary<int, int> pathToIndexMapping;
        /// <summary>
        /// Maps data messages with specific ID to paths IDs. Data messages whose ID matches a record in this list
        /// are interpreted as geographic coordinates, and appended to the specified path.
        /// </summary>
        private Dictionary<int, int> appendIdToPathMapping;
        /// <summary>
        /// Lock this to protect internal resources. Invokes and async providers create a threading mess, better be safe.
        /// </summary>
        private object lockObject = new object();


        public MessageProcessor_Path(IMessageProvider provider = null, TelemetryControl target = null) {
            MessageProvider = provider;
            Target = target;

            pathToIndexMapping = new Dictionary<int, int>();
            appendIdToPathMapping = new Dictionary<int, int>();
        }

        /// <summary>
        /// Assign the source of messages.
        /// </summary>
        public override IMessageProvider MessageProvider {
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
        /// Which form to add paths to.
        /// </summary>
        public TelemetryControl Target {
            get {
                return target;
            }
            set {
                target = value;
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
                case eMessageType.PATH:
                    ProcessMessage((PathMessage)msg);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Select which message IDs should be appended, if any.
        /// </summary>
        private void ProcessMessage(LayoutMessage msg) {
            lock (lockObject) {
                appendIdToPathMapping.Clear();

                for (int i = 0; i < msg.Count; i++) {
                    if (msg[i].AppendPathEnabled && !appendIdToPathMapping.ContainsKey(msg[i].Id)) {
                        appendIdToPathMapping.Add(msg[i].Id, msg[i].AppendPathId);
                    }
                }
            }
        }

        /// <summary>
        /// Append message if ID matches any record.
        /// </summary>
        private void ProcessMessage(DataMessage msg) {
            string error = null;
            try {
                int index, path;
                lock (lockObject) {
                    path = appendIdToPathMapping[msg.Id];
                    index = pathToIndexMapping[path];
                }

                if (msg.Dimension >= 3) {
                    target.Invoke(new Action(() => { target.Paths[index].Add(new GeoPoint(msg[0], msg[1], msg[2])); target.PathsUpdated(); }));
                }
                else if (msg.Dimension == 2) {
                    target.Invoke(new Action(() => { target.Paths[index].Add(new GeoPoint(msg[0], msg[1], 0.0)); target.PathsUpdated(); }));
                }
                else {
                    throw new ArgumentException("Message must be at least two-dimensional.");
                }
            }
            catch (KeyNotFoundException e) {
                // if message's id is not registered for path appending - not an error
                // if path corresponding to message's id does not have an assigned index in target - cannot happen
            }
            catch (ArgumentOutOfRangeException e) {
                error = "Invalid path index accessed on target form. Have you assigned multiple MessageProcessors that conflict?";
            }
            catch (Exception e) {
                error = e.Message;
            }
        }

        /// <summary>
        /// Add or remove paths. Also handles explicit path modification messages, not just data appends.
        /// </summary>
        private void ProcessMessage(PathMessage msg) {
            string error = null;
            try {
                int index;
                switch (msg.action) {
                    case PathMessage.eAction.ADD_POINT:
                        lock (lockObject) {
                            index = pathToIndexMapping[msg.path];
                        }
                        target.Invoke(new Action(() => { target.Paths[index].Add(msg.point); target.PathsUpdated(); }));
                        break;
                    case PathMessage.eAction.UPDATE_POINT:
                        lock (lockObject) {
                            index = pathToIndexMapping[msg.path];
                        }
                        target.Invoke(new Action(() => target.Paths[index][(int)msg.index] = msg.point));
                        break;
                    case PathMessage.eAction.CLEAR_PATH:
                        lock (lockObject) {
                            index = pathToIndexMapping[msg.path];
                        }
                        target.Invoke(new Action(() => target.Paths[index].Clear()));
                        break;
                    case PathMessage.eAction.ADD_PATH:
                        bool containsPath;
                        lock (lockObject) {
                            containsPath = pathToIndexMapping.ContainsKey(msg.path);
                        }
                        if (!containsPath) {
                            target.Invoke(new Action(() => {
                                target.Paths.Add(new Path());
                                index = target.Paths.Count - 1;
                                lock (lockObject) {
                                    pathToIndexMapping.Add(msg.path, index);
                                }
                            }));
                        }
                        else {
                            throw new InvalidOperationException("Path already exists, cannot add it.");
                        }
                        break;
                    case PathMessage.eAction.REMOVE_PATH:
                        lock (lockObject) {
                            index = pathToIndexMapping[msg.path];
                        }
                        target.Invoke(new Action(() => {
                            target.Paths.RemoveAt(index);
                            lock (lockObject) {
                                pathToIndexMapping.Remove(msg.path);
                                foreach (var key in pathToIndexMapping.Keys.ToArray()) {
                                    if (pathToIndexMapping[key] > index) {
                                        pathToIndexMapping[key]--;
                                    }
                                }
                            }
                        }));
                        break;
                    case PathMessage.eAction.CLEAR_MAP:
                        target.Invoke(new Action(() => target.Paths.Clear()));
                        lock (lockObject) {
                            pathToIndexMapping.Clear();
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (KeyNotFoundException e) {
                error = "Specified path does not exist. Add it first.";
            }
            catch (InvalidOperationException e) {
                error = e.Message;
            }
            catch (ArgumentOutOfRangeException e) {
                error = "Invalid path index accessed on target form. Have you assigned multiple MessageProcessors that conflict?";
            }
        }
    }
}
