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
                output = output.Substring(0, output.Length - 1) + "\r\n  ";
                currLineLength = 2;
            }
            currLineLength += 24;
        }

        private object[] GetIntBytes(int value) {
            return new object[] { (byte)(value >> 24), (byte)((value >> 16) & 0xff), (byte)((value >> 8) & 0xff), (byte)(value & 0xff) };
        }

        private void WriteCoefficients() {
            const string format = "0x{0:X2}, 0x{1:X2}, 0x{2:X2}, 0x{3:X2}, ";
            int maxLineLength = (int)lineLengthSelect.Value;
            int currLineLength = 2;
            var output = "{ ";
            foreach (var f in config.filters1) {
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += string.Format(format, GetIntBytes(f.FP_b0));
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += string.Format(format, GetIntBytes(f.FP_b1));
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += string.Format(format, GetIntBytes(f.FP_b2));
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += string.Format(format, GetIntBytes(f.FP_a1));
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += string.Format(format, GetIntBytes(f.FP_a2));
            }
            channel1Box.Text = output.Substring(0, output.Length - 2) + " }";
            currLineLength = 2;
            output = "{ ";
            foreach (var f in config.filters2) {
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += string.Format(format, GetIntBytes(f.FP_b0));
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += string.Format(format, GetIntBytes(f.FP_b1));
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += string.Format(format, GetIntBytes(f.FP_b2));
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += string.Format(format, GetIntBytes(f.FP_a1));
                CheckSplitLine(maxLineLength, ref currLineLength, ref output);
                output += string.Format(format, GetIntBytes(f.FP_a2));
            }
            channel2Box.Text = output.Substring(0, output.Length - 2) + " }";
            gain1Box.Text = string.Format("0x{0:X8}", BiquadFilter.ToFP((decimal)config.gain1));
            gain2Box.Text = string.Format("0x{0:X8}", BiquadFilter.ToFP((decimal)config.gain2));
        }

        private void CoefficientExport_Load(object sender, EventArgs e) {
            WriteCoefficients();
        }

        private void lineLengthSelect_ValueChanged(object sender, EventArgs e) {
            WriteCoefficients();
        }
    }
}
