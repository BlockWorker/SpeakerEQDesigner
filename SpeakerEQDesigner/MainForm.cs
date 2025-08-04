using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace SpeakerEQDesigner {
    public partial class MainForm : Form {
        private static readonly XmlSerializer cfgSer = new XmlSerializer(typeof(Config));

        public Config cfg;
        LinePlusLogFunctionSeries s1SPLSeries, s2SPLSeries;
        DoubleFilteredResponseSeries sumSPLSeries;
        LineSeries avgSPLSeries;
        bool blockUpdates = false;
        int[] filterIndex;
        BiquadFilter[] currFilter;

        public MainForm() {
            InitializeComponent();
            cfg = new Config() {
                filters1 = new List<BiquadFilter>(),
                filters2 = new List<BiquadFilter>(),
                response1 = new List<DPoint>(),
                response2 = new List<DPoint>(),
                fpFormatIndex = 0,
                fpPostShift1 = 0,
                fpPostShift2 = 0,
            };
            for (int i = 0; i < 7; i++) {
                cfg.filters1.Add(new BiquadFilter {
                    cfg = cfg
                });
                cfg.filters2.Add(new BiquadFilter {
                    cfg = cfg
                });
            }
            filterIndex = new int[] { 0, 0 };
            currFilter = new BiquadFilter[] { cfg.filters1[0], cfg.filters2[0] };
            cfg.response1.Add(new DPoint(10, 90));
            cfg.response1.Add(new DPoint(30000, 90));
            cfg.response2.Add(new DPoint(10, 90));
            cfg.response2.Add(new DPoint(30000, 90));
        }

        private void OnFilterTypeSelect(int speaker) {
            var filt = currFilter[speaker];
            var type = filt.Type;
            blockUpdates = true;
            switch (speaker) {
                case 0:
                    s1TypeSelect.SelectedIndex = (int)type;
                    s1FreqSelect.Enabled = s1QSelect.Enabled = type != FilterType.Disabled && type != FilterType.Custom;
                    s1GainSelect.Enabled = type == FilterType.EQ || type == FilterType.LowShelf || type == FilterType.HighShelf;
                    s1b0Select.Enabled = s1b1Select.Enabled = s1b2Select.Enabled = s1a1Select.Enabled = s1a2Select.Enabled = type == FilterType.Custom;
                    break;
                case 1:
                    s2TypeSelect.SelectedIndex = (int)type;
                    s2FreqSelect.Enabled = s2QSelect.Enabled = type != FilterType.Disabled && type != FilterType.Custom;
                    s2GainSelect.Enabled = type == FilterType.EQ || type == FilterType.LowShelf || type == FilterType.HighShelf;
                    s2b0Select.Enabled = s2b1Select.Enabled = s2b2Select.Enabled = s2a1Select.Enabled = s2a2Select.Enabled = type == FilterType.Custom;
                    break;
            }
            OnFilterParamChange(speaker);
            blockUpdates = false;
        }

        private void OnFilterParamChange(int speaker) {
            var filt = currFilter[speaker];
            filt.UpdateFilter();
            cfg.RecomputeFPShifts();
            blockUpdates = true;
            switch (speaker) {
                case 0:
                    s1FreqSelect.Value = filt.Frequency;
                    s1QSelect.Value = filt.Q;
                    s1GainSelect.Value = filt.Gain;
                    s1b0Select.Value = filt.rounded_b0;
                    s1b1Select.Value = filt.rounded_b1;
                    s1b2Select.Value = filt.rounded_b2;
                    s1a1Select.Value = filt.rounded_a1;
                    s1a2Select.Value = filt.rounded_a2;
                    s1a1Label.Text = filt.NegateA ? "-a1:" : "a1:";
                    s1a2Label.Text = filt.NegateA ? "-a2:" : "a2:";
                    s1b0Hex.Text = filt.FP_b0.ToString("X8");
                    s1b1Hex.Text = filt.FP_b1.ToString("X8");
                    s1b2Hex.Text = filt.FP_b2.ToString("X8");
                    s1a1Hex.Text = filt.FP_a1.ToString("X8");
                    s1a2Hex.Text = filt.FP_a2.ToString("X8");
                    s1NegBox.Checked = filt.NegateA;
                    s1SRSelect.Value = filt.SampleRate;
                    s1SpkGainSelect.Value = (decimal)cfg.gain1;
                    s1Shift.Text = cfg.fpPostShift1.ToString();
                    s1PlotView.InvalidatePlot(true);
                    break;
                case 1:
                    s2FreqSelect.Value = filt.Frequency;
                    s2QSelect.Value = filt.Q;
                    s2GainSelect.Value = filt.Gain;
                    s2b0Select.Value = filt.rounded_b0;
                    s2b1Select.Value = filt.rounded_b1;
                    s2b2Select.Value = filt.rounded_b2;
                    s2a1Select.Value = filt.rounded_a1;
                    s2a2Select.Value = filt.rounded_a2;
                    s2a1Label.Text = filt.NegateA ? "-a1:" : "a1:";
                    s2a2Label.Text = filt.NegateA ? "-a2:" : "a2:";
                    s2b0Hex.Text = filt.FP_b0.ToString("X8");
                    s2b1Hex.Text = filt.FP_b1.ToString("X8");
                    s2b2Hex.Text = filt.FP_b2.ToString("X8");
                    s2a1Hex.Text = filt.FP_a1.ToString("X8");
                    s2a2Hex.Text = filt.FP_a2.ToString("X8");
                    s2NegBox.Checked = filt.NegateA;
                    s2SRSelect.Value = filt.SampleRate;
                    s2SpkGainSelect.Value = (decimal)cfg.gain2;
                    s2Shift.Text = cfg.fpPostShift2.ToString();
                    s2PlotView.InvalidatePlot(true);
                    break;
            }
            sumPlotView.InvalidatePlot(true);
            blockUpdates = false;
        }

        public void UpdateResponse(int speaker) {
            switch (speaker) {
                case 0:
                    s1PlotView.InvalidatePlot(true);
                    break;
                case 1:
                    s2PlotView.InvalidatePlot(true);
                    break;
            }
            sumPlotView.InvalidatePlot(true);
        }

        private void FiltAdd_Click(object sender, EventArgs e) {
            var but = (Button)sender;
            int spk = (int)but.Tag;
            cfg.Filters(spk).Add(new BiquadFilter {
                cfg = cfg
            });
            switch (spk) {
                case 0:
                    s1FiltSelect.Maximum = cfg.Filters(spk).Count;
                    break;
                case 1:
                    s2FiltSelect.Maximum = cfg.Filters(spk).Count;
                    break;
            }
        }

        private void FiltSelect_ValueChanged(object sender, EventArgs e) {
            var box = (NumericUpDown)sender;
            int spk = (int)box.Tag;
            if (blockUpdates) return;
            filterIndex[spk] = (int)box.Value - 1;
            currFilter[spk] = cfg.Filters(spk)[filterIndex[spk]];
            OnFilterTypeSelect(spk);
        }

        private void FiltRemove_Click(object sender, EventArgs e) {
            var but = (Button)sender;
            int spk = (int)but.Tag;
            if (cfg.Filters(spk).Count > 1) cfg.Filters(spk).RemoveAt(cfg.Filters(spk).Count - 1);
            switch (spk) {
                case 0:
                    s1FiltSelect.Maximum = cfg.Filters(spk).Count;
                    s1PlotView.InvalidatePlot(true);
                    break;
                case 1:
                    s2FiltSelect.Maximum = cfg.Filters(spk).Count;
                    s2PlotView.InvalidatePlot(true);
                    break;
            }
            sumPlotView.InvalidatePlot(true);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            var s1Model = new PlotModel();
            var s1FAxis = new LogarithmicAxis() {
                AbsoluteMinimum = 10,
                AbsoluteMaximum = 30000,
                Minimum = 10,
                Maximum = 30000,
                MajorGridlineStyle = LineStyle.Solid,
                Base = 10,
                Position = AxisPosition.Bottom,
                PowerPadding = false,
                Unit = "Hz",
                Title = "f"
            };
            var s1GainAxis = new LinearAxis() {
                Title = "Gain",
                Unit = "dB",
                AbsoluteMinimum = -120,
                AbsoluteMaximum = 20,
                Minimum = -12,
                Maximum = 12,
                MajorStep = 6,
                MinorStep = 3,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Solid,
                TitleColor = OxyColors.Green,
                Position = AxisPosition.Right,
                Key = "Gain",
            };
            var s1SPLAxis = new LinearAxis() {
                Title = "SPL",
                Unit = "dB",
                AbsoluteMinimum = 0,
                AbsoluteMaximum = 150,
                Minimum = 60,
                Maximum = 120,
                MajorStep = 10,
                MinorStep = 5,
                MajorGridlineStyle = LineStyle.Dash,
                MinorGridlineStyle = LineStyle.Dot,
                TitleColor = OxyColors.Red,
                Position = AxisPosition.Left,
                Key = "SPL",
            };
            s1Model.Axes.Add(s1FAxis);
            s1Model.Axes.Add(s1SPLAxis);
            s1Model.Axes.Add(s1GainAxis);
            var s1GainSeries = new LogFunctionSeries(x => cfg.filters1.Sum(f => f.Response(x)) + cfg.gain1, 10, 30000, 1.05d) {
                YAxisKey = "Gain",
                Color = OxyColors.Green
            };
            s1SPLSeries = new LinePlusLogFunctionSeries(cfg.response1, x => cfg.filters1.Sum(f => f.Response(x)) + cfg.gain1, 10, 30000, 1.05d) {
                YAxisKey = "SPL",
                Color = OxyColors.Red
            };
            s1Model.Series.Add(s1GainSeries);
            s1Model.Series.Add(s1SPLSeries);
            s1PlotView.Model = s1Model;

            var s2Model = new PlotModel();
            var s2FAxis = new LogarithmicAxis() {
                AbsoluteMinimum = 10,
                AbsoluteMaximum = 30000,
                Minimum = 10,
                Maximum = 30000,
                MajorGridlineStyle = LineStyle.Solid,
                Base = 10,
                Position = AxisPosition.Bottom,
                PowerPadding = false,
                Unit = "Hz",
                Title = "f"
            };
            var s2GainAxis = new LinearAxis() {
                Title = "Gain",
                Unit = "dB",
                AbsoluteMinimum = -120,
                AbsoluteMaximum = 20,
                Minimum = -12,
                Maximum = 12,
                MajorStep = 6,
                MinorStep = 3,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Solid,
                TitleColor = OxyColors.Green,
                Position = AxisPosition.Right,
                Key = "Gain",
            };
            var s2SPLAxis = new LinearAxis() {
                Title = "SPL",
                Unit = "dB",
                AbsoluteMinimum = 0,
                AbsoluteMaximum = 150,
                Minimum = 60,
                Maximum = 120,
                MajorStep = 10,
                MinorStep = 5,
                MajorGridlineStyle = LineStyle.Dash,
                MinorGridlineStyle = LineStyle.Dot,
                TitleColor = OxyColors.Red,
                Position = AxisPosition.Left,
                Key = "SPL",
            };
            s2Model.Axes.Add(s2FAxis);
            s2Model.Axes.Add(s2SPLAxis);
            s2Model.Axes.Add(s2GainAxis);
            var s2gainSeries = new LogFunctionSeries(x => cfg.filters2.Sum(f => f.Response(x)) + cfg.gain2, 10, 30000, 1.05d) {
                YAxisKey = "Gain",
                Color = OxyColors.Green
            };
            s2SPLSeries = new LinePlusLogFunctionSeries(cfg.response2, x => cfg.filters2.Sum(f => f.Response(x)) + cfg.gain2, 10, 30000, 1.05d) {
                YAxisKey = "SPL",
                Color = OxyColors.Red
            };
            s2Model.Series.Add(s2gainSeries);
            s2Model.Series.Add(s2SPLSeries);
            s2PlotView.Model = s2Model;

            var sumModel = new PlotModel();
            var sumFAxis = new LogarithmicAxis() {
                AbsoluteMinimum = 10,
                AbsoluteMaximum = 30000,
                Minimum = 10,
                Maximum = 30000,
                MajorGridlineStyle = LineStyle.Solid,
                Base = 10,
                Position = AxisPosition.Bottom,
                PowerPadding = false,
                Unit = "Hz",
                Title = "f"
            };
            var sumSPLAxis = new LinearAxis() {
                Title = "Total SPL",
                Unit = "dB",
                AbsoluteMinimum = 0,
                AbsoluteMaximum = 150,
                Minimum = 60,
                Maximum = 120,
                MajorStep = 10,
                MinorStep = 5,
                MajorGridlineStyle = LineStyle.Dash,
                MinorGridlineStyle = LineStyle.Dot,
                Position = AxisPosition.Left,
            };
            sumModel.Axes.Add(sumFAxis);
            sumModel.Axes.Add(sumSPLAxis);
            sumSPLSeries = new DoubleFilteredResponseSeries(cfg.response1, cfg.response2, x => cfg.filters1.Sum(f => f.Response(x)) + cfg.gain1,
                x => cfg.filters2.Sum(f => f.Response(x)) + cfg.gain2, 10, 30000, 1.05d) {
                Color = OxyColors.Red
            };
            sumSPLSeries.OnUpdate += UpdateFlatness;
            sumModel.Series.Add(sumSPLSeries);
            avgSPLSeries = new LineSeries() {
                Color = OxyColors.Orange,
                LineStyle = LineStyle.Dash,
                StrokeThickness = 1d
            };
            avgSPLSeries.Points.Add(new DataPoint(10d, 90d));
            avgSPLSeries.Points.Add(new DataPoint(30000d, 90d));
            sumModel.Series.Add(avgSPLSeries);
            sumPlotView.Model = sumModel;
        }

        private void UpdateFlatness(object sender, EventArgs e) {
            var values = new List<double>();
            foreach (var point in sumSPLSeries.Points) {
                if (point.X >= (double)flatnessStartSel.Value && point.X <= (double)flatnessEndSel.Value) values.Add(point.Y);
            }

            if (values.Count == 0) {
                avgSPLSeries.IsVisible = false;
                flatnessMeanBox.Text = flatnessPeakBox.Text = flatnessStdDevBox.Text = "--- dB";
            } else {
                var mean = values.Sum() / values.Count;
                var peak = values.Max() - values.Min();
                var stddev = Math.Sqrt(values.Sum(x => (x - mean) * (x - mean)) / (values.Count - 1));
                flatnessMeanBox.Text = string.Format("{0:F2} dB", mean);
                flatnessPeakBox.Text = string.Format("{0:F2} dB", peak);
                flatnessStdDevBox.Text = string.Format("{0:F3} dB", stddev);
                avgSPLSeries.Points[0] = new DataPoint(10d, mean);
                avgSPLSeries.Points[1] = new DataPoint(30000d, mean);
                avgSPLSeries.IsVisible = true;
            }

            sumPlotView.Invalidate(true);
        }

        private void TypeSelect_SelectedIndexChanged(object sender, EventArgs e) {
            var box = (ComboBox)sender;
            int spk = (int)box.Tag;
            if (blockUpdates) return;
            currFilter[spk].Type = (FilterType)box.SelectedIndex;
            OnFilterTypeSelect(spk);
        }

        private void FiltParamSelect_ValueChanged(object sender, EventArgs e) {
            var box = (NumericUpDown)sender;
            int spk = (int)box.Tag & 0xF;
            int param = (int)box.Tag & 0xF0;
            if (blockUpdates) return;
            switch (param) {
                case 0x00:
                    currFilter[spk].Frequency = box.Value;
                    break;
                case 0x10:
                    currFilter[spk].Q = box.Value;
                    break;
                case 0x20:
                    currFilter[spk].Gain = box.Value;
                    break;
                case 0x30:
                    currFilter[spk].b0 = box.Value;
                    break;
                case 0x40:
                    currFilter[spk].b1 = box.Value;
                    break;
                case 0x50:
                    currFilter[spk].b2 = box.Value;
                    break;
                case 0x60:
                    currFilter[spk].a1 = box.Value;
                    break;
                case 0x70:
                    currFilter[spk].a2 = box.Value;
                    break;
                case 0x80:
                    currFilter[spk].SampleRate = box.Value;
                    break;
            }
            OnFilterParamChange(spk);
        }

        private void NegBox_CheckedChanged(object sender, EventArgs e) {
            var box = (CheckBox)sender;
            int spk = (int)box.Tag;
            if (blockUpdates) return;
            currFilter[spk].NegateA = box.Checked;
            OnFilterParamChange(spk);
        }

        private void SpkResponse_Click(object sender, EventArgs e) {
            var but = (Button)sender;
            int spk = (int)but.Tag;
            new SpeakerResponseForm(cfg.Response(spk), spk).ShowDialog(this);
        }

        private void QCrit_Click(object sender, EventArgs e) {
            var but = (Button)sender;
            int spk = (int)but.Tag;
            currFilter[spk].Q = 0.7071067811865475244008443621m;
            OnFilterParamChange(spk);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (saveDialog.ShowDialog() != DialogResult.OK) return;
            var path = saveDialog.FileName;
            var stream = File.OpenWrite(path);
            cfgSer.Serialize(stream, cfg);
            stream.Close();
        }

        private void SpkGainSelect_ValueChanged(object sender, EventArgs e) {
            var box = (NumericUpDown)sender;
            int spk = (int)box.Tag;
            if (blockUpdates) return;
            switch (spk) {
                case 0:
                    cfg.gain1 = (double)box.Value;
                    break;
                case 1:
                    cfg.gain2 = (double)box.Value;
                    break;
            }
            OnFilterParamChange(spk);
        }

        private void exportCoefficientsToolStripMenuItem_Click(object sender, EventArgs e) {
            new CoefficientExport(cfg).ShowDialog();
        }

        private void flatnessSel_ValueChanged(object sender, EventArgs e) {
            if (flatnessStartSel.Value >= flatnessEndSel.Value) {
                if (sender == flatnessEndSel) flatnessStartSel.Value = flatnessEndSel.Value - 1;
                else flatnessEndSel.Value = flatnessStartSel.Value + 1;
            } else {
                UpdateFlatness(null, null);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openDialog.ShowDialog() != DialogResult.OK) return;
            var path = openDialog.FileName;
            var stream = File.OpenRead(path);
            cfg = (Config)cfgSer.Deserialize(stream);
            stream.Close();
            foreach (var f in cfg.filters1) {
                f.cfg = cfg;
                f.UpdateFilter();
            }
            foreach (var f in cfg.filters2) {
                f.cfg = cfg;
                f.UpdateFilter();
            }
            s1FiltSelect.Value = s2FiltSelect.Value = 1;
            filterIndex = new int[] { 0, 0 };
            currFilter = new BiquadFilter[] { cfg.filters1[0], cfg.filters2[0] };
            s1FiltSelect.Maximum = cfg.filters1.Count;
            s2FiltSelect.Maximum = cfg.filters2.Count;
            SelectFPFormat(cfg.fpFormatIndex);
            sumSPLSeries.LineSeries1 = s1SPLSeries.LineSeries = cfg.response1;
            sumSPLSeries.LineSeries2 = s2SPLSeries.LineSeries = cfg.response2;
        }

        private void format523toolStripMenuItem_Click(object sender, EventArgs e) {
            SelectFPFormat(0);
        }

        private void format131toolStripMenuItem_Click(object sender, EventArgs e) {
            SelectFPFormat(1);
        }

        private void RecalculateShifts(object sender, EventArgs e) {
            foreach (var f in cfg.filters1) {
                f.UpdateFilter();
            }
            foreach (var f in cfg.filters2) {
                f.UpdateFilter();
            }

            cfg.RecomputeFPShifts();
        }

        private void SelectFPFormat(int format) {
            if (format > 1) {
                throw new ArgumentException("Invalid FP format!");
            }

            cfg.SetFPFormat(format);
            if (format == 0) {
                format523toolStripMenuItem.Checked = true;
                format131toolStripMenuItem.Checked = false;
            } else if (format == 1) {
                format523toolStripMenuItem.Checked = false;
                format131toolStripMenuItem.Checked = true;
            }

            OnFilterTypeSelect(0);
            OnFilterTypeSelect(1);
        }
    }

    public class Config {
        //FP formats: 0 = 5.23, 1 = 1.31
        public readonly decimal[] FPMults = { 8388608m, 2147483648m };
        public readonly decimal[] FPMins = { -16m, -1m };
        public readonly decimal[] FPMaxs = { 15.99999988079071m, 0.9999999995343387m };

        public List<DPoint> response1, response2;
        public List<BiquadFilter> filters1, filters2;
        public double gain1, gain2;

        public int fpFormatIndex;
        public decimal FPMult { get => FPMults[fpFormatIndex]; }
        public decimal FPMin { get => FPMins[fpFormatIndex]; }
        public decimal FPMax { get => FPMaxs[fpFormatIndex]; }

        public int fpPostShift1, fpPostShift2;

        public void SetFPFormat(int format) {
            if (fpFormatIndex == format) return;

            fpFormatIndex = format;

            foreach (var f in filters1) {
                f.UpdateFilter();
            }
            foreach (var f in filters2) {
                f.UpdateFilter();
            }
            RecomputeFPShifts();
        }

        public void RecomputeFPShifts() {
            fpPostShift1 = filters1.Max(f => f.FP_shift);
            foreach (var f in filters1) {
                f.RecomputeFPForGivenShift(fpPostShift1);
            }

            fpPostShift2 = filters2.Max(f => f.FP_shift);
            foreach (var f in filters2) {
                f.RecomputeFPForGivenShift(fpPostShift2);
            }
        }

        public List<DPoint> Response(int speaker) {
            return speaker == 0 ? response1 : response2;
        }

        public List<BiquadFilter> Filters(int speaker) {
            return speaker == 0 ? filters1 : filters2;
        }
    }
}
