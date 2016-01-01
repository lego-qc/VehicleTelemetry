using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QCTracker {
    public partial class DataDisplay : UserControl {
        public DataDisplay() {
            InitializeComponent();

            count = 0;
            title = null;
            labels = new StringTable();
            values = new StringTable();

            labels.OnChanged += this.OnLabelChanged;
            values.OnChanged += this.OnValueChanged;
        }


        private int count;
        private string title;
        private StringTable labels;
        private StringTable values;
        private Label titleLabel = new Label();
        private Button graphButton = new Button();

        public int Count {
            get {
                return count;
            }
            set {
                count = value;
                if (count == 0) {
                    labels.strings = null;
                    values.strings = null;
                }
                else {
                    labels.strings = new string[count];
                    values.strings = new string[count];
                }
                UpdateLayout();
            }
        }

        public string Title {
            get {
                return title;
            }
            set {
                title = value;
                if (title != null) {
                    titleLabel.Text = title;
                }
                else {
                    titleLabel.Text = "";
                }
            }
        }

        private void OnLabelChanged(int index, string value) {
            Label label = (Label)mainTable.GetControlFromPosition(0, index + 1);
            label.Text = (value != null ? value : "");
        }
        private void OnValueChanged(int index, string value) {
            TextBox textBox = (TextBox)mainTable.GetControlFromPosition(0, index + 1);
            textBox.Text = (value != null ? value : "");
        }

        private void UpdateLayout() {
            mainTable.Controls.Clear();
            if (count == 0) {
                mainTable.RowCount = 0;
                return;
            }

            // initialize table layout
            mainTable.RowCount = count + 1;
            foreach (RowStyle style in mainTable.RowStyles) {
                style.SizeType = SizeType.Absolute;
                style.Height = 26;
            }
            mainTable.MinimumSize = new Size(0, 26 * mainTable.RowCount);
            mainTable.Size = new Size(mainTable.Size.Width, 26 * mainTable.RowCount);


            for (int row = 1; row < count; row++) {
                // add label
                Label label = new Label();
                mainTable.Controls.Add(label, 0, row);
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleLeft;

                // add textbox
                TextBox textBox = new TextBox();
                mainTable.Controls.Add(textBox, 1, row);
                textBox.Dock = DockStyle.Fill;
                textBox.TextAlign = HorizontalAlignment.Left;
                textBox.ReadOnly = true;
            }

            // add graph button
            mainTable.Controls.Add(graphButton, 2, mainTable.RowCount - 1);
            graphButton.Text = "G";

            // add title
            mainTable.Controls.Add(titleLabel, 0, 0);
            mainTable.SetColumnSpan(titleLabel, 3);           
        }

        public class StringTable {
            public delegate void OnChangedEvent(int index, string value);
            public event OnChangedEvent OnChanged;

            public string[] strings = null;
            public string this[int index] {
                get {
                    return strings[index];
                }
                set {
                    strings[index] = value;
                    OnChanged(index, value);
                }
            }
        }
    }
}
