using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeakerEQDesigner {
    public partial class CoefficientExport : Form {
        private Config config;

        public CoefficientExport(Config cfg) {
            InitializeComponent();
            config = cfg;
        }

        private void CheckSplitLine(int maxLineLength, ref int currLineLength, ref string output) {
            if (currLineLength + 24 > maxLineLength) {
                output = output.Substring(0, output.Length - 1) + "\r\n";
                currLineLength = 2;
            }
            currLineLength += 24;
        }

        private object[] GetIntBytes(int value) {
            return new object[] { (byte)(value >> 24), (byte)((value >> 16) & 0xff), (byte)((value >> 8) & 0xff), (byte)(value & 0xff) };
        }

        private string FormatInt(int value) {
            switch (formatBox.SelectedIndex) {
                case 1:
                    return string.Format("0x{0:X2}, 0x{1:X2}, 0x{2:X2}, 0x{3:X2}, ", GetIntBytes(value));
                case 2:
                    return string.Format("0x{3:X2}, 0x{2:X2}, 0x{1:X2}, 0x{0:X2}, ", GetIntBytes(value));
                default:
                    return string.Format("0x{0:X8}, ", value);
            }
        }

        private void WriteCoefficients() {
            int maxLineLength = (int)lineLengthSelect.Value;
            int currLineLength = 2;
            var output = "";
            foreach (var f in config.filters1) {
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += FormatInt(f.FP_b0);
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += FormatInt(f.FP_b1);
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += FormatInt(f.FP_b2);
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += FormatInt(f.FP_a1);
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += FormatInt(f.FP_a2);
            }
            channel1Box.Text = output.Substring(0, output.Length - 2);
            currLineLength = 2;
            output = "";
            foreach (var f in config.filters2) {
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += FormatInt(f.FP_b0);
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += FormatInt(f.FP_b1);
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += FormatInt(f.FP_b2);
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += FormatInt(f.FP_a1);
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += FormatInt(f.FP_a2);
            }
            channel2Box.Text = output.Substring(0, output.Length - 2);
            shift1Box.Text = config.fpPostShift1.ToString();
            shift2Box.Text = config.fpPostShift2.ToString();
            gain1Box.Text = config.gain1.ToString();
            gain2Box.Text = config.gain2.ToString();
        }

        private void CoefficientExport_Load(object sender, EventArgs e) {
            formatBox.SelectedIndex = 0;
            WriteCoefficients();
        }

        private void lineLengthSelect_ValueChanged(object sender, EventArgs e) {
            WriteCoefficients();
        }

        private void formatBox_SelectedIndexChanged(object sender, EventArgs e) {
            WriteCoefficients();
        }
    }
}
