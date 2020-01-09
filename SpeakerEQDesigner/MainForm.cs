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

namespace SpeakerEQDesigner {
    public partial class MainForm : Form {
        private static readonly XmlSerializer filtSer = new XmlSerializer(typeof(List<BiquadFilter>));
        private static readonly XmlSerializer resSer = new XmlSerializer(typeof(List<DPoint>));

        public List<BiquadFilter>[] filters;
        public List<DPoint>[] spkResponses;
        bool blockUpdates = false;
        int[] filterIndex;
        BiquadFilter[] currFilter;

        public MainForm() {
            InitializeComponent();
            filters = new List<BiquadFilter>[] { new List<BiquadFilter>(), new List<BiquadFilter>() };
            for (int i = 0; i < 7; i++) {
                filters[0].Add(new BiquadFilter());
                filters[1].Add(new BiquadFilter());
            }
            filterIndex = new int[] { 0, 0 };
            currFilter = new BiquadFilter[] { filters[0][0], filters[1][0] };
            spkResponses = new List<DPoint>[] { new List<DPoint>(), new List<DPoint>() };
            spkResponses[0].Add(new DPoint(10, 90));
            spkResponses[0].Add(new DPoint(30000, 90));
            spkResponses[1].Add(new DPoint(10, 90));
            spkResponses[1].Add(new DPoint(30000, 90));
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
            blockUpdates = true;
            switch (speaker) {
                case 0:
                    s1FreqSelect.Value = filt.Frequency;
                    s1QSelect.Value = filt.Q;
                    s1GainSelect.Value = filt.Gain;
                    s1b0Select.Value = filt.b0;
                    s1b1Select.Value = filt.b1;
                    s1b2Select.Value = filt.b2;
                    s1a1Select.Value = filt.a1;
                    s1a2Select.Value = filt.a2;
                    s1a1Label.Text = filt.NegateA ? "-a1:" : "a1:";
                    s1a2Label.Text = filt.NegateA ? "-a2:" : "a2:";
                    s1b0Hex.Text = filt.FP_b0.ToString("X8");
                    s1b1Hex.Text = filt.FP_b1.ToString("X8");
                    s1b2Hex.Text = filt.FP_b2.ToString("X8");
                    s1a1Hex.Text = filt.FP_a1.ToString("X8");
                    s1a2Hex.Text = filt.FP_a2.ToString("X8");
                    s1NegBox.Checked = filt.NegateA;
                    s1SRSelect.Value = filt.SampleRate;
                    s1PlotView.InvalidatePlot(true);
                    break;
                case 1:
                    s2FreqSelect.Value = filt.Frequency;
                    s2QSelect.Value = filt.Q;
                    s2GainSelect.Value = filt.Gain;
                    s2b0Select.Value = filt.b0;
                    s2b1Select.Value = filt.b1;
                    s2b2Select.Value = filt.b2;
                    s2a1Select.Value = filt.a1;
                    s2a2Select.Value = filt.a2;
                    s2a1Label.Text = filt.NegateA ? "-a1:" : "a1:";
                    s2a2Label.Text = filt.NegateA ? "-a2:" : "a2:";
                    s2b0Hex.Text = filt.FP_b0.ToString("X8");
                    s2b1Hex.Text = filt.FP_b1.ToString("X8");
                    s2b2Hex.Text = filt.FP_b2.ToString("X8");
                    s2a1Hex.Text = filt.FP_a1.ToString("X8");
                    s2a2Hex.Text = filt.FP_a2.ToString("X8");
                    s2NegBox.Checked = filt.NegateA;
                    s2SRSelect.Value = filt.SampleRate;
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
            filters[spk].Add(new BiquadFilter());
            switch (spk) {
                case 0:
                    s1FiltSelect.Maximum = filters[spk].Count;
                    break;
                case 1:
                    s2FiltSelect.Maximum = filters[spk].Count;
                    break;
            }
        }

        private void FiltSelect_ValueChanged(object sender, EventArgs e) {
            var box = (NumericUpDown)sender;
            int spk = (int)box.Tag;
            if (blockUpdates) return;
            filterIndex[spk] = (int)box.Value - 1;
            currFilter[spk] = filters[spk][filterIndex[spk]];
            OnFilterTypeSelect(spk);
        }

        private void FiltRemove_Click(object sender, EventArgs e) {
            var but = (Button)sender;
            int spk = (int)but.Tag;
            if (filters[spk].Count > 1) filters[spk].RemoveAt(filters[spk].Count - 1);
            switch (spk) {
                case 0:
                    s1FiltSelect.Maximum = filters[spk].Count;
                    s1PlotView.InvalidatePlot(true);
                    break;
                case 1:
                    s2FiltSelect.Maximum = filters[spk].Count;
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
            var s1GainSeries = new LogFunctionSeries(x => filters[0].Sum(f => f.Response(x)), 10, 30000, 1.05m) {
                YAxisKey = "Gain",
                Color = OxyColors.Green
            };
            var s1SPLSeries = new LinePlusLogFunctionSeries(spkResponses[0], x => filters[0].Sum(f => f.Response(x)), 10, 30000, 1.05m) {
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
            var s2gainSeries = new LogFunctionSeries(x => filters[1].Sum(f => f.Response(x)), 10, 30000, 1.05m) {
                YAxisKey = "Gain",
                Color = OxyColors.Green
            };
            var s2SPLSeries = new LinePlusLogFunctionSeries(spkResponses[1], x => filters[1].Sum(f => f.Response(x)), 10, 30000, 1.05m) {
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
            var sumSPLSeries = new DoubleFilteredResponseSeries(spkResponses[0], spkResponses[1], x => filters[0].Sum(f => f.Response(x)), x => filters[1].Sum(f => f.Response(x)), 10, 30000, 1.05m) {
                Color = OxyColors.Red
            };
            sumModel.Series.Add(sumSPLSeries);
            sumPlotView.Model = sumModel;
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
            new SpeakerResponseForm(spkResponses[spk], spk).ShowDialog(this);
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
            resSer.Serialize(stream, spkResponses[0]);
            resSer.Serialize(stream, spkResponses[1]);
            filtSer.Serialize(stream, filters[0]);
            filtSer.Serialize(stream, filters[1]);
            stream.Close();
        }
    }
}
