using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    public class MessageProcessor {
        public MessageProcessor(IMessageProvider provider = null, TelemetryControl targetForm = null) {
            idToIndexMapping = new Dictionary<int, int>();
            targetFormCollection = new HashSet<TelemetryControl>();
            MessageProvider = provider;
            TargetForm = targetForm;
        }

        private IMessageProvider provider;
        private TelemetryControl targetForm;
        private HashSet<TelemetryControl> targetFormCollection;
        private Dictionary<int, int> idToIndexMapping;

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
            // TODO

            // check if neeed to be added to a path
            // TODO
        }

        private void ProcessMessage(PathMessage msg) {

        }
    }
}
