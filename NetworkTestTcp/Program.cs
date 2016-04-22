using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Diagnostics;
using VehicleTelemetry;


namespace NetworkTestTcp {
    class Program {
        private static bool isRunning;
        private static Random gaussGen;

        static Program() {
            gaussGen = new Random();
        }

        static void Main(string[] args) {
            // display usage info
            Console.WriteLine("Testing Vehicle Telemetry Application");
            Console.WriteLine("The program will now predefined data to the telemetry application over TCP.");
            Console.WriteLine("Press CTRL+C to cancel.\n");

            // register control-c handler
            Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                Program.isRunning = false;
            };

            // start communication
            Console.WriteLine("Connecting to 127.0.0.1 : 5640");
            isRunning = true;
            try {
                MessageClientTcp client = new MessageClientTcp();
                using (client) {
                    // connect to server
                    client.Connect("127.0.0.1", 5640);

                    // send layout
                    LayoutMessage layoutMsg = new LayoutMessage();
                    layoutMsg.Count = 3;
                    layoutMsg[0].Dimension = 4;
                    layoutMsg[0].Name = "GPS";
                    layoutMsg[0].Id = 1;
                    layoutMsg[0].AppendPathId = 10;
                    layoutMsg[0].AppendPathEnabled = true;
                    layoutMsg[0].UpdateMap = true;
                    layoutMsg[0][0] = "Latitude";
                    layoutMsg[0][1] = "Longitude";
                    layoutMsg[0][2] = "Altitude";
                    layoutMsg[0][3] = "Speed (kph)";

                    layoutMsg[1].Dimension = 3;
                    layoutMsg[1].Name = "Speed";
                    layoutMsg[1].Id = 2;
                    layoutMsg[1].AppendPathId = 0;
                    layoutMsg[1].AppendPathEnabled = false;
                    layoutMsg[1].UpdateMap = false;
                    layoutMsg[1][0] = "Forward";
                    layoutMsg[1][1] = "Right";
                    layoutMsg[1][2] = "Upward";

                    layoutMsg[2].Dimension = 4;
                    layoutMsg[2].Name = "Motors";
                    layoutMsg[2].Id = 3;
                    layoutMsg[2].AppendPathId = 0;
                    layoutMsg[2].AppendPathEnabled = false;
                    layoutMsg[2].UpdateMap = false;
                    layoutMsg[2][0] = "Motor #1";
                    layoutMsg[2][1] = "Motor #2";
                    layoutMsg[2][2] = "Motor #3";
                    layoutMsg[2][3] = "Motor #4";

                    Console.WriteLine("Sending layout...");
                    client.Send(layoutMsg);

                    PathMessage pathMsg = new PathMessage();
                    pathMsg.action = PathMessage.eAction.ADD_PATH;
                    pathMsg.path = 10;

                    client.Send(pathMsg);
                    Console.WriteLine("Configuring paths...");
                    Console.WriteLine();

                    // keep sending some data periodically
                    long iteration = 1;
                    GeoPoint currentPoint = new GeoPoint(47.5, 19, 130);
                    GeoPoint lastPoint = currentPoint;
                    double elapsedTotal = 0;
                    double frameTime = 1;
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    while (isRunning) {
                        Console.WriteLine("updating data... #" + iteration.ToString());
                        Console.SetCursorPosition(0, Console.CursorTop-1);
                        iteration++;
                        DataMessage dataMsg = new DataMessage();

                        // gps
                        currentPoint = new GeoPoint(
                            47.5 + 0.05 * Math.Sin(0.01 * elapsedTotal),
                            19 + 0.1 * Math.Cos(0.01 * elapsedTotal),
                            130);
                        dataMsg.Id = 1;
                        dataMsg.Dimension = 4;
                        dataMsg[0] = (float)currentPoint.Lat;
                        dataMsg[1] = (float)currentPoint.Lng;
                        dataMsg[2] = (float)130;
                        dataMsg[3] = (float)(GeoPoint.DistanceDirect(currentPoint, lastPoint) / frameTime * 3.6);
                        lastPoint = currentPoint;

                        client.Send(dataMsg);

                        // speed
                        dataMsg.Id = 2;
                        dataMsg.Dimension = 3;
                        dataMsg[0] = 0.0f;
                        dataMsg[1] = 0.0f;
                        dataMsg[2] = 0.0f;

                        client.Send(dataMsg);

                        // motors
                        dataMsg.Id = 3;
                        dataMsg.Dimension = 4;
                        dataMsg[0] = (float)RandomGauss(40, 1.5);
                        dataMsg[1] = (float)RandomGauss(40, 2.5);
                        dataMsg[2] = (float)RandomGauss(40, 1.3);
                        dataMsg[3] = (float)RandomGauss(40, 1.8);

                        client.Send(dataMsg);

                        // wait a little
                        Thread.Sleep(200);

                        double elapsedTotalNew = timer.Elapsed.TotalSeconds;
                        frameTime = elapsedTotalNew - elapsedTotal;
                        elapsedTotal = elapsedTotalNew;
                        
                    }

                    // close connection
                    Console.WriteLine("Disconnecting...");
                    client.Disconnect();
                }
            }
            catch (Exception e) {
                Console.WriteLine("An error occured: " + e.Message + "\n");
            }
        }



        private static double RandomGauss(double mean, double standardDeviation) {
            double u1 = gaussGen.NextDouble(); //these are uniform(0,1) random doubles
            double u2 = gaussGen.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal =
                         mean + standardDeviation * randStdNormal; //random normal(mean,stdDev^2)

            return randNormal;
        }
    }
}
