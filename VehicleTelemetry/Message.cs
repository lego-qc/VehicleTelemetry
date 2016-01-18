using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTelemetry {
    public enum eMessageType : byte {
        LAYOUT,
        DATA,
        PATH,
    }

    public abstract class Message {
        public virtual eMessageType Type {
            get;
        }

        public abstract byte[] Serialize();

        public static Message Deserialize(byte[] data) {
            eMessageType type = (eMessageType)data[0];
            Message message;
            switch (type) {
                case eMessageType.LAYOUT:
                    message = new LayoutMessage();
                    break;
                case eMessageType.DATA:
                    message = new DataMessage();
                    break;
                case eMessageType.PATH:
                    message = new PathMessage();
                    break;
                default:
                    message = null;
                    break;
            }
            bool isOk = false;
            if (message != null) {
                isOk = message.DeserializeSelf(data);
            }
            return isOk ? message : null;
        }

        protected abstract bool DeserializeSelf(byte[] data);

        protected uint FloatToUint(float value) {
            return BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
        }
        protected float UintToFloat(uint value) {
            return BitConverter.ToSingle(BitConverter.GetBytes(value), 0);
        }
    }



    public class LayoutMessage : Message {

        private Channel[] channels = null;
        public int Count {
            get {
                return channels != null ? channels.Length : 0;
            }
            set {
                if (value == 0) {
                    channels = null;
                }
                else {
                    Channel[] tmp = new Channel[value];
                    int common = Math.Min(channels != null ? channels.Length : 0, value);
                    int i;
                    for (i = 0; i < common; i++) {
                        tmp[i] = channels[i];
                    }
                    for (; i < value; i++) {
                        tmp[i] = new Channel();
                    }
                    channels = tmp;
                }
            }
        }

        public override eMessageType Type {
            get {
                return eMessageType.LAYOUT;   
            }
        }

        public Channel this[int index] {
            get {
                return channels[index];
            }
            set {
                if (value != null) {
                    channels[index] = value;
                }
            }
        }

        public override byte[] Serialize() {
            List<byte> raw = new List<byte>();
            raw.Add((byte)Type);
            raw.Add((byte)((uint)channels.Length >> 24));
            raw.Add((byte)((uint)channels.Length >> 16));
            raw.Add((byte)((uint)channels.Length >> 8));
            raw.Add((byte)(channels.Length));

            for (int i = 0; i < channels.Length; i++) {
                // name
                uint namelen = (uint)channels[i].Name.Length;
                byte[] nameBytes = System.Text.Encoding.UTF8.GetBytes(channels[i].Name);
                raw.Add((byte)(namelen >> 24));
                raw.Add((byte)(namelen >> 16));
                raw.Add((byte)(namelen >> 8));
                raw.Add((byte)(namelen));
                foreach (var b in nameBytes) {
                    raw.Add(b);
                }

                raw.Add((byte)(channels[i].Id >> 8));
                raw.Add((byte)(channels[i].Id));

                raw.Add((byte)(channels[i].Dimension >> 8));
                raw.Add((byte)(channels[i].Dimension));

                raw.Add((byte)(channels[i].UpdateMap ? 1 : 0));
                raw.Add((byte)(channels[i].AppendPathEnabled ? 1 : 0));

                raw.Add((byte)(channels[i].AppendPathId >> 8));
                raw.Add((byte)(channels[i].AppendPathId));

                for (int j = 0; j < channels[i].Dimension; j++) {
                    uint len = (uint)channels[i][j].Length;
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(channels[i][j]);
                    raw.Add((byte)(len >> 24));
                    raw.Add((byte)(len >> 16));
                    raw.Add((byte)(len >> 8));
                    raw.Add((byte)(len));
                    foreach (var b in bytes) {
                        raw.Add(b);
                    }
                }
            }

            return raw.ToArray();
        }
        protected override bool DeserializeSelf(byte[] data) {
            if (data.Length < 5 || (eMessageType)data[0] != Type) {
                return false;
            }
            uint numChannels =
                ((uint)data[1] << 24)
                + ((uint)data[2] << 16)
                + ((uint)data[3] << 8)
                + ((uint)data[4]);

            Channel[] channels = new Channel[numChannels];
            int currentIndex = 5;
            for (int i = 0; i < numChannels; i++) {
                channels[i] = new Channel();
                // read name length
                if (data.Length < currentIndex + 4) {
                    return false;
                }
                uint namelen =
                    ((uint)data[currentIndex + 0] << 24)
                    + ((uint)data[currentIndex + 1] << 16)
                    + ((uint)data[currentIndex + 2] << 8)
                    + ((uint)data[currentIndex + 3]);
                currentIndex += 4;
                // read name
                if (data.Length < currentIndex + namelen) {
                    return false;
                }
                byte[] namebytes = new byte[namelen];
                for (int j = 0; j < namelen; j++) {
                    namebytes[j] = data[currentIndex + j];
                }
                channels[i].Name = System.Text.Encoding.UTF8.GetString(namebytes);
                currentIndex += (int)namelen;
                // read remaining
                if (data.Length < currentIndex + 8) {
                    return false;
                }
                channels[i].Id = (byte)((data[currentIndex + 0] << 8) + data[currentIndex + 1]);
                channels[i].Dimension = (byte)((data[currentIndex + 2] << 8) + data[currentIndex + 3]);
                channels[i].UpdateMap = 0 < data[currentIndex + 4];
                channels[i].AppendPathEnabled = 0 < data[currentIndex + 5];
                channels[i].AppendPathId = (byte)((data[currentIndex + 6] << 8) + data[currentIndex + 7]);
                currentIndex += 8;

                // read value names
                for (int j = 0; j < channels[i].Dimension; j++) {
                    // read name length
                    if (data.Length < currentIndex + 4) {
                        return false;
                    }
                    uint len =
                        ((uint)data[currentIndex + 0] << 24)
                        + ((uint)data[currentIndex + 1] << 16)
                        + ((uint)data[currentIndex + 2] << 8)
                        + ((uint)data[currentIndex + 3]);
                    currentIndex += 4;
                    // read name
                    if (data.Length < currentIndex + len) {
                        return false;
                    }
                    byte[] bytes = new byte[len];
                    for (int k = 0; k < len; k++) {
                        bytes[k] = data[currentIndex + k];
                    }
                    channels[i][j] = System.Text.Encoding.UTF8.GetString(bytes);
                    currentIndex += (int)len;
                }
            }
            this.channels = channels;
            return true;
        }

        public class Channel {
            public bool UpdateMap = false;
            public bool AppendPathEnabled = false;
            public ushort AppendPathId = 0;
            public ushort Id = 0;
            private ushort dimension = 0;
            private string name = null;
            private string[] valueNames = null;

            public string Name {
                get {
                    return name != null ? name : "";
                }
                set {
                    name = value;
                }
            }

            public ushort Dimension {
                get {
                    return dimension;
                }
                set {
                    if (value > 0) {
                        string[] tmp = new string[value];
                        int common = Math.Min(valueNames != null ? valueNames.Length : 0, value);
                        int i;
                        for (i = 0; i < common; i++) {
                            tmp[i] = valueNames[i];
                        }
                        for (; i < value; i++) {
                            tmp[i] = "unnamed";
                        }
                        valueNames = tmp;
                        dimension = value;
                    }
                    else {
                        dimension = 0;
                        valueNames = null;
                    }

                }
            }

            public string this[int index] {
                get {
                    return valueNames[index];
                }
                set {
                    if (value != null) {
                        valueNames[index] = value;
                    }
                    else {
                        valueNames[index] = "unnamed";
                    }
                }
            }
        }
    }



    public class DataMessage : Message {
        private ushort id = 0;
        private ushort dimension = 0;
        private float[] values = null;

        public ushort Id {
            get {
                return id;
            }
            set {
                id = value;
            }
        }

        public ushort Dimension {
            get {
                return dimension;
            }
            set {
                dimension = value;
                if (dimension == 0) {
                    values = null;
                }
                else {
                    values = new float[dimension];
                }
            }
        }

        public override eMessageType Type {
            get {
                return eMessageType.DATA;   
            }
        }

        public float this[int i] {
            get {
                return values[i];
            }
            set {
                values[i] = value;
            }
        }

        public override byte[] Serialize() {
            int size = 1 + 2 + 2 + dimension * 4;
            byte[] raw = new byte[size];

            raw[0] = (byte)Type;
            raw[1] = (byte)(id >> 8);
            raw[2] = (byte)(id);
            raw[3] = (byte)(dimension >> 8);
            raw[4] = (byte)(dimension);

            for (int i = 0; i < dimension; i++) {
                uint bytes = FloatToUint(values[i]);
                raw[5 + 4 * i + 0] = (byte)(bytes >> 24);
                raw[5 + 4 * i + 1] = (byte)(bytes >> 16);
                raw[5 + 4 * i + 2] = (byte)(bytes >> 8);
                raw[5 + 4 * i + 3] = (byte)(bytes >> 0);
            }

            return raw;
        }
        protected override bool DeserializeSelf(byte[] data) {
            if (data.Length < 5) {
                return false;
            }
            eMessageType type = (eMessageType)data[0];
            if (type != Type) {
                return false;
            }
            ushort id, dimension;
            id = (ushort)((data[1] << 8) + data[2]);
            dimension = (ushort)((data[3] << 8) + data[4]);
            if (data.Length < 5 + dimension * 4) {
                return false;
            }
            values = new float[dimension];
            this.id = id;
            this.dimension = dimension;
            for (int i = 0; i < dimension; i++) {
                uint bytes = 0;
                bytes |= (uint)data[5 + 4 * i + 0] << 24;
                bytes |= (uint)data[5 + 4 * i + 1] << 16;
                bytes |= (uint)data[5 + 4 * i + 2] << 8;
                bytes |= (uint)data[5 + 4 * i + 3] << 0;
                values[i] = UintToFloat(bytes);
            }

            return true;
        }
    }


    public class PathMessage : Message {
        public eAction action;
        public ushort path;
        public uint index;
        public GeoPoint point;
        private const int SIZE = 1 + 1 + 2 + 4 + 4 * 3;

        public override eMessageType Type {
            get {
                return eMessageType.PATH;   
            }
        }

        public override byte[] Serialize() {
            byte[] raw = new byte[SIZE];
            raw[0] = (byte)Type;
            raw[1] = (byte)action;
            raw[2] = (byte)(path >> 8);
            raw[3] = (byte)path;
            raw[4] = (byte)(index >> 24);
            raw[5] = (byte)(index >> 16);
            raw[6] = (byte)(index >> 8);
            raw[7] = (byte)(index >> 0);

            uint lat = 0;
            uint lng = 0;
            uint alt = 0;

            if (point != null) {
                lat = FloatToUint((float)point.Lat);
                lng = FloatToUint((float)point.Lng);
                alt = FloatToUint((float)point.Alt);
            }

            raw[8] = (byte)(lat >> 24);
            raw[9] = (byte)(lat >> 16);
            raw[10] = (byte)(lat >> 8);
            raw[11] = (byte)(lat >> 0);

            raw[12] = (byte)(lng >> 24);
            raw[13] = (byte)(lng >> 16);
            raw[14] = (byte)(lng >> 8);
            raw[15] = (byte)(lng >> 0);

            raw[16] = (byte)(alt >> 24);
            raw[17] = (byte)(alt >> 16);
            raw[18] = (byte)(alt >> 8);
            raw[19] = (byte)(alt >> 0);

            return raw;
        }
        protected override bool DeserializeSelf(byte[] data) {
            if (data.Length < SIZE || (eMessageType)data[0] != Type) {
                return false;
            }
            action = (eAction)data[1];
            path = (ushort)(((uint)data[2] << 8) + data[3]);
            index = ((uint)data[4] << 24)
                + ((uint)data[5] << 16)
                + ((uint)data[6] << 8)
                + (data[7]);

            uint lat = 0, lng = 0, alt = 0;
            lat |= (uint)data[8 + 0] << 24;
            lat |= (uint)data[8 + 1] << 16;
            lat |= (uint)data[8 + 2] << 8;
            lat |= (uint)data[8 + 3];

            lng |= (uint)data[12 + 0] << 24;
            lng |= (uint)data[12 + 1] << 16;
            lng |= (uint)data[12 + 2] << 8;
            lng |= (uint)data[12 + 3];

            alt |= (uint)data[16 + 0] << 24;
            alt |= (uint)data[16 + 1] << 16;
            alt |= (uint)data[16 + 2] << 8;
            alt |= (uint)data[16 + 3];

            point = new GeoPoint(UintToFloat(lat), UintToFloat(lng), UintToFloat(alt));

            return true;
        }

        public enum eAction : byte {
            ADD_POINT,
            UPDATE_POINT,
            CLEAR_PATH,
            ADD_PATH,
            REMOVE_PATH,
            CLEAR_MAP,
        }
    }


    class MessageTester {
        public static bool Test() {
            LayoutMessage layoutMsg = new LayoutMessage();

            layoutMsg.Count = 3;

            layoutMsg[0].Name = "GPS";
            layoutMsg[0].Id = 0;
            layoutMsg[0].AppendPathId = 1;
            layoutMsg[0].UpdateMap = true;
            layoutMsg[0].AppendPathEnabled = false;
            layoutMsg[0].Dimension = 3;
            layoutMsg[0][0] = "Latitude";
            layoutMsg[0][1] = "Longitude";
            layoutMsg[0][2] = "Altitude";

            layoutMsg[1].Name = "Velocity";
            layoutMsg[1].Id = 1;
            layoutMsg[1].AppendPathId = 16;
            layoutMsg[1].UpdateMap = true;
            layoutMsg[1].AppendPathEnabled = true;
            layoutMsg[1].Dimension = 3;
            layoutMsg[1][0] = "X";
            layoutMsg[1][1] = "Y";
            layoutMsg[1][2] = "Z";

            layoutMsg[2].Name = "Temperature";
            layoutMsg[2].Id = 2;
            layoutMsg[2].AppendPathId = 0;
            layoutMsg[2].UpdateMap = false;
            layoutMsg[2].AppendPathEnabled = true;
            layoutMsg[2].Dimension = 1;
            layoutMsg[2][0] = "Value";

            byte[] layoutMsgBytes = layoutMsg.Serialize();
            LayoutMessage layoutMsgRestored = (LayoutMessage)Message.Deserialize(layoutMsgBytes);


            PathMessage pathMsg = new PathMessage();
            pathMsg.action = PathMessage.eAction.UPDATE_POINT;
            pathMsg.index = 5;
            pathMsg.path = 9;
            pathMsg.point = new GeoPoint(47.5, 19, 120);

            byte[] pathMsgBytes = pathMsg.Serialize();
            PathMessage pathMsgRestore = (PathMessage)Message.Deserialize(pathMsgBytes);


            DataMessage dataMsg = new DataMessage();
            dataMsg.Dimension = 3;
            dataMsg.Id = 12345;
            dataMsg[0] = 3.1415926f;
            dataMsg[1] = 2.7182818f;
            dataMsg[2] = 0.5772156f;

            byte[] dataMsgBytes = dataMsg.Serialize();
            DataMessage dataMsgRestored = (DataMessage)Message.Deserialize(dataMsgBytes);




            return true;
        }
    }
}