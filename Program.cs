using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleTelemetry {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            //MessageTester.Test();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = new Form_VehicleTelemetryMain();

            mainForm.DataSnippets.Count = 4;

            mainForm.DataSnippets[0].Count = 3;
            mainForm.DataSnippets[0].Title = "Navigation";

            mainForm.DataSnippets[0].Labels[0] = "Latitude =";
            mainForm.DataSnippets[0].Labels[1] = "Longitude =";
            mainForm.DataSnippets[0].Labels[2] = "Altitude =";

            mainForm.DataSnippets[0].Values[0] = "47.5";
            mainForm.DataSnippets[0].Values[1] = "19";
            mainForm.DataSnippets[0].Values[2] = "136";


            mainForm.DataSnippets[1].Count = 3;
            mainForm.DataSnippets[1].Title = "Velocity";
            mainForm.DataSnippets[1].Labels[0] = "X =";
            mainForm.DataSnippets[1].Labels[1] = "Y =";
            mainForm.DataSnippets[1].Labels[2] = "Z =";

            mainForm.DataSnippets[1].Values[0] = "0.6";
            mainForm.DataSnippets[1].Values[1] = "2.8";
            mainForm.DataSnippets[1].Values[2] = "0.05";


            mainForm.DataSnippets[2].Count = 2;
            mainForm.DataSnippets[2].Title = "Electronics";

            mainForm.DataSnippets[2].Labels[0] = "Voltage (V)";
            mainForm.DataSnippets[2].Labels[1] = "Current (A)";

            mainForm.DataSnippets[2].Values[0] = "12.41";
            mainForm.DataSnippets[2].Values[1] = "6.8";


            mainForm.DataSnippets[3].Count = 4;
            mainForm.DataSnippets[3].Title = "Motors";

            mainForm.DataSnippets[3].Labels[0] = "Motor #1 (%)";
            mainForm.DataSnippets[3].Labels[1] = "Motor #2 (%)";
            mainForm.DataSnippets[3].Labels[2] = "Motor #3 (%)";
            mainForm.DataSnippets[3].Labels[3] = "Motor #4 (%)";

            mainForm.DataSnippets[3].Values[0] = "41";
            mainForm.DataSnippets[3].Values[1] = "44";
            mainForm.DataSnippets[3].Values[2] = "43";
            mainForm.DataSnippets[3].Values[3] = "41";



            Application.Run(mainForm);            
        }
    }
}
