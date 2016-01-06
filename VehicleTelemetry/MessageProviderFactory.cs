using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    public class MessageProviderFactory {
        static MessageProviderFactory() {
            registry = new Dictionary<Guid, ProviderCreator>();
            enumeration = new List<ProviderDesc>();
            enumWrapper = new ProviderEnumeration(enumeration);
        }

        public static void RegisterClass<ProviderT>(string name) where ProviderT : IMessageProvider, new() {
            if (registry == null) {
                registry = new Dictionary<Guid, ProviderCreator>();
                enumeration = new List<ProviderDesc>();
                enumWrapper = new ProviderEnumeration(enumeration);
            }
            Type type = typeof(ProviderT);
            Guid id = type.GUID;
            if (!registry.ContainsKey(id)) {
                registry.Add(id, new ProviderCreator(name, () => { return new ProviderT(); }));
                enumeration.Add(new ProviderDesc(id, name));
            }
        }


        public static IMessageProvider Create(Guid id) {
            return null;
        }

        public static ProviderEnumeration Enumerator {
            get {
                return enumWrapper;
            }
        }

        public class ProviderDesc {
            public ProviderDesc(Guid id, string name) {
                this.id = id;
                this.name = name;
            }
            public readonly Guid id;
            public readonly string name;
        }

        private delegate IMessageProvider CreatorDelegate();

        private class ProviderCreator {
            ProviderCreator() { }
            public ProviderCreator(string name, CreatorDelegate creator) {
                this.name = name;
                this.creator = creator;
            } 
            public string name;
            public CreatorDelegate creator;
        }

        public class ProviderEnumeration {
            public ProviderEnumeration(List<ProviderDesc> data) {
                this.data = data;
            }
            private List<ProviderDesc> data;

            public int Count {
                get {
                    return data != null ? data.Count : 0;
                }
            }

            public ProviderDesc this[int index] {
                get {
                    return data[index];
                }
            }
        }

        private static Dictionary<Guid, ProviderCreator> registry;
        private static List<ProviderDesc> enumeration;
        private static ProviderEnumeration enumWrapper;
    }
}
