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
                    client.Connect("127.0.0.1", 5640);

                    // do stuff
                    // ...

                    client.Disconnect();
                }
            }
            catch (Exception e) {
                Console.WriteLine("An error occured");
            }
        }
    }
}
