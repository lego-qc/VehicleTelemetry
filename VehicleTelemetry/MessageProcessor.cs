using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    public class MessageProcessor {
        public MessageProcessor(IMessageProvider provider = null, TelemetryControl targetForm = null) {
            idToIndexMapping = new Dictionary<int, int>();
            pathToIndexMapping = new Dictionary<int, int>();
            targetFormCollection = new HashSet<TelemetryControl>();
            mapBoundIds = new HashSet<int>();
            pathBoundIds = new Dictionary<int, int>();
            MessageProvider = provider;
            TargetForm = targetForm;
        }

        private IMessageProvider provider;
        private TelemetryControl targetForm;
        private HashSet<TelemetryControl> targetFormCollection;
        private Dictionary<int, int> idToIndexMapping;
        private Dictionary<int, int> pathToIndexMapping;
        private HashSet<int> mapBoundIds;
        private Dictionary<int, int> pathBoundIds;

        public IMessageProvider MessageProvider {
            get {
                return provider;
            }
            set {
                if (provider != null) {
                    provider.OnMessage -= OnMessage;
                }
                provider = value;
                if (provider != null) {
                    provider.OnMessage += OnMessage;
                }
            }
        }

        public TelemetryControl TargetForm {
            get {
                return targetForm;
            }
            set {
                if (value == null) {
                    if (targetFormCollection.Contains(targetForm)) {
                        targetFormCollection.Remove(targetForm);
                    }
                    targetForm = value;
                    return;
                }
                if (value == targetForm) {
                    return;
                }
                if (targetFormCollection.Contains(value)) {
                    throw new ArgumentException("You cannot bind multiple message processors to one form.");
                }

                targetForm = value;
                targetFormCollection.Add(targetForm);
            }
        }

        private void OnMessage(Message msg) {
            if (targetForm != null) {
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
                }
            }
        }


        private void ProcessMessage(LayoutMessage msg) {
            try {
                // create and verify id to index mappings
                var newMapping = new Dictionary<int, int>();
                for (int i = 0; i < msg.Count; i++) {
                    newMapping.Add(msg[i].Id, i);
                }
                idToIndexMapping = newMapping;

                // add record if it needs to be set to a map
                mapBoundIds.Clear();
                for (int i=0; i<msg.Count; i++) {
                    if (msg[i].UpdateMap) {
                        mapBoundIds.Add(msg[i].Id);
                    }
                }

                // add record if it needs to appended to a path
                pathBoundIds.Clear();
                for (int i=0; i<msg.Count; i++) {
                    if (msg[i].AppendPathEnabled) {
                        pathBoundIds.Add(msg[i].Id, msg[i].AppendPathId);
                    }
                }

                // set layout to form's data panel
                targetForm.Invoke(new Action(() => {
                    targetForm.DataSnippets.Count = msg.Count;
                    for (int i = 0; i < msg.Count; i++) {
                        targetForm.DataSnippets[i].Count = msg[i].Dimension;
                        targetForm.DataSnippets[i].Title = msg[i].Name;
                        for (int j = 0; j < msg[i].Dimension; j++) {
                            targetForm.DataSnippets[i].Labels[j] = msg[i][j];
                        }
                    }
                }));
            }
            catch (AggregateException ex) {
                // duplicate IDs, no action to perform
                return;
            }
        }

        private void ProcessMessage(DataMessage msg) {
            // find index by the ID
            if (!idToIndexMapping.ContainsKey(msg.Id)) {
                return;
            }
            int index = idToIndexMapping[msg.Id];

            // set values to the corresponding snippet
            targetForm.Invoke(new Action(() => {
                int minDim = Math.Min(msg.Dimension, targetForm.DataSnippets[index].Count);
                for (int i = 0; i < minDim; i++) {
                    targetForm.DataSnippets[index].Values[i] = msg[i].ToString();
                }
            }));

            // check if need to be set on map
            if (mapBoundIds.Contains(msg.Id)) {
                if (msg.Dimension >= 3) {
                    targetForm.Invoke(new Action(() => { targetForm.SetCurrentPosition(new GeoPoint(msg[0], msg[1], msg[2])); }));
                }
                else if (msg.Dimension == 2) {
                    targetForm.Invoke(new Action(() => { targetForm.SetCurrentPosition(new GeoPoint(msg[0], msg[1])); }));
                }
            }

            // check if neeed to be added to a path
            if (pathBoundIds.ContainsKey(msg.Id)) {
                int path = pathBoundIds[msg.Id];
                if (pathToIndexMapping.ContainsKey(path)) {
                    int pathIndex = pathToIndexMapping[path];
                    if (msg.Dimension >= 3) {
                        targetForm.Invoke(new Action(() => { targetForm.Paths[pathIndex].Add(new GeoPoint(msg[0], msg[1], msg[2])); }));
                    }
                    else if (msg.Dimension == 2) {
                        targetForm.Invoke(new Action(() => { targetForm.Paths[pathIndex].Add(new GeoPoint(msg[0], msg[1])); }));
                    }
                }
            }
        }

        private void ProcessMessage(PathMessage msg) {
            // TODO: move this to invoke!
            // *TODID
            targetForm.Invoke(new Action(() => {
                try {
                    int index;
                    switch (msg.action) {
                        case PathMessage.eAction.ADD_POINT:
                            index = pathToIndexMapping[msg.path];
                            targetForm.Paths[index].Add(msg.point);
                            break;
                        case PathMessage.eAction.UPDATE_POINT:
                            index = pathToIndexMapping[msg.path];
                            targetForm.Paths[index][(int)msg.index] = msg.point;
                            break;
                        case PathMessage.eAction.CLEAR_PATH:
                            index = pathToIndexMapping[msg.path];
                            targetForm.Paths[index].Clear();
                            break;
                        case PathMessage.eAction.ADD_PATH:
                            if (!pathToIndexMapping.ContainsKey(msg.path)) {
                                targetForm.Paths.Add(new Path());
                                index = targetForm.Paths.Count - 1;
                                pathToIndexMapping.Add(msg.path, index);
                            }
                            break;
                        case PathMessage.eAction.REMOVE_PATH:
                            index = pathToIndexMapping[msg.path];
                            targetForm.Paths.RemoveAt(index);
                            pathToIndexMapping.Remove(msg.path);
                            foreach (var key in pathToIndexMapping.Keys.ToArray()) {
                                if (pathToIndexMapping[key] > index) {
                                    pathToIndexMapping[key]--;
                                }
                            }
                            break;
                        case PathMessage.eAction.CLEAR_MAP:
                            targetForm.Paths.Clear();
                            pathToIndexMapping.Clear();
                            break;
                        default:
                            break;
                    }
                }
                catch (IndexOutOfRangeException e) {

                }
            }));
        }
    }
}
