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
    public partial class DataSnippet : UserControl {
        private int count;
        private string title;
        private StringTable labels;
        private StringTable values;
        private Label titleLabel;
        private Button graphButton;
        private const int ROW_SIZE = 20;
        private const int MARGIN = 1;
        private bool isShowingGraph;


        public DataSnippet() {
            InitializeComponent();

            count = 0;
            title = null;
            labels = new StringTable();
            values = new StringTable();
            titleLabel = new Label();
            graphButton = new Button();

            labels.OnChanged += this.OnLabelChanged;
            values.OnChanged += this.OnValueChanged;
            graphButton.Click += this.OnShowGraph;
            isShowingGraph = false;

            Font oldFont = titleGroup.Font;
            titleGroup.Font = new Font(titleGroup.Font, FontStyle.Bold);
            mainTable.Font = oldFont;
        }


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
                    titleGroup.Text = title;
                }
                else {
                    titleLabel.Text = "";
                    titleGroup.Text = "";
                }
            }
        }

        public StringTable Labels {
            get {
                return labels;
            }
        }

        public StringTable Values {
            get {
                return values;
            }
        }

        private void OnLabelChanged(int index, string value) {
            Label label = (Label)mainTable.GetControlFromPosition(0, index);
            label.Text = (value != null ? value : "");
        }

        private void OnValueChanged(int index, string value) {
            TextBox textBox = (TextBox)mainTable.GetControlFromPosition(1, index);
            textBox.Text = (value != null ? value : "");
        }

        private void OnShowGraph(object sender, EventArgs e) {
            int currentWidth = titleGroup.Size.Width;
            int currentHeight = titleGroup.Size.Height;
            int newWidth = currentWidth;
            int newHeight = currentHeight + (isShowingGraph ? -50 : +50);
            this.Size = new Size(newWidth, newHeight);
            isShowingGraph = !isShowingGraph;
        }

        private void UpdateLayout() {
            mainTable.Controls.Clear();
            if (count == 0) {
                mainTable.RowCount = 0;
                return;
            }

            // initialize table layout
            mainTable.RowCount = count;
            mainTable.RowStyles.Clear();
            for (int i = 0; i < mainTable.RowCount; i++) {
                mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, ROW_SIZE));
            }
            mainTable.MinimumSize = new Size(0, ROW_SIZE * mainTable.RowCount);
            mainTable.Size = new Size(mainTable.Size.Width, ROW_SIZE * mainTable.RowCount + MARGIN);
            this.Size = new Size(this.Size.Width, mainTable.Size.Height + 24);

            for (int row = 0; row < count; row++) {
                // add label
                Label label = new Label();
                mainTable.Controls.Add(label, 0, row);
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleLeft;
                label.Margin = new Padding(MARGIN);

                // add textbox
                TextBox textBox = new TextBox();
                mainTable.Controls.Add(textBox, 1, row);
                textBox.Dock = DockStyle.Fill;
                textBox.TextAlign = HorizontalAlignment.Left;
                textBox.ReadOnly = true;
                textBox.Margin = new Padding(MARGIN);
            }

            // add graph button
            mainTable.Controls.Add(graphButton, 2, mainTable.RowCount - 1);
            graphButton.Text = "G";
            graphButton.Margin = new Padding(MARGIN);

            mainTable.Refresh();
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
