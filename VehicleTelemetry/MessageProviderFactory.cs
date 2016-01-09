using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace VehicleTelemetry {
    public class MessageProviderFactory {
        static MessageProviderFactory() {
            // create internal members
            registry = new Dictionary<Guid, ProviderCreator>();
            enumeration = new List<ProviderDesc>();
            enumWrapper = new ProviderEnumeration(enumeration);

            // get all classes implementing IMessageProvider from all assemblies
            var subclasses =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where typeof(IMessageProvider).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract && type.GetConstructor(Type.EmptyTypes) != null
                select type;

            // register all above classes
            foreach (Type type in subclasses) {
                Guid guid = type.GUID;
                string name = type.Namespace + "." + type.Name;
                if (!registry.ContainsKey(guid)) {
                    registry.Add(guid, new ProviderCreator(name, () => {
                        return (IMessageProvider)Activator.CreateInstance(type);
                    }));
                    enumeration.Add(new ProviderDesc(guid, name));
                }
                else {
                    // should NEVER happen
                    throw new Exception("Subclass found twice, should never happen.");
                }
            }
        }


        public static IMessageProvider Create(Guid id) {
            try {
                return registry[id].creator();
            }
            catch (Exception ex) {
                return null;
            }
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
