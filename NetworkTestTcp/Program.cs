using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTelemetry;

namespace NetworkTestTcp {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Connecting to 127.0.0.1 : 5640");
            try {
                MessageClientTcp client = new MessageClientTcp();
                using (client) {
                    // connect to server
                    client.Connect("127.0.0.1", 5640);

                    // send layout
                    LayoutMessage layoutMsg = new LayoutMessage();
                    layoutMsg.Count = 2;
                    layoutMsg[0].Dimension = 1;
                    layoutMsg[0].Name = "Test1";
                    layoutMsg[0].Id = 1;
                    layoutMsg[0].AppendPathIndex = 0;
                    layoutMsg[0].AppendToPath = false;
                    layoutMsg[0].UpdateMap = false;
                    layoutMsg[0][0] = "value1";

                    layoutMsg[1].Dimension = 2;
                    layoutMsg[1].Name = "Test2";
                    layoutMsg[1].Id = 2;
                    layoutMsg[1].AppendPathIndex = 0;
                    layoutMsg[1].AppendToPath = false;
                    layoutMsg[1].UpdateMap = false;
                    layoutMsg[1][0] = "value1";
                    layoutMsg[1][1] = "value2";

                    client.Send(layoutMsg);

                    // send data
                    DataMessage dataMsg = new DataMessage();
                    dataMsg.Id = 1;
                    dataMsg.Dimension = 1;
                    dataMsg[0] = 1.0f;

                    client.Send(dataMsg);

                    dataMsg.Id = 2;
                    dataMsg.Dimension = 2;
                    dataMsg[0] = 2.0f;
                    dataMsg[1] = 3.0f;

                    client.Send(dataMsg);

                    // close connection
                    client.Disconnect();
                }
            }
            catch (Exception e) {
                Console.WriteLine("An error occured: " + e.Message + "\n");
            }
        }
    }
}
