using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleTelemetry {
    public abstract partial class Panel : WeifenLuo.WinFormsUI.Docking.DockContent {
        public Panel() {
            InitializeComponent();
        }
    }
}
