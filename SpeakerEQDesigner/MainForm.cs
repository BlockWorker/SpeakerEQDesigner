using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace SpeakerEQDesigner {
    public partial class MainForm : Form {
        List<BiquadFilter> s1Filters, s2Filters;
        LogFunctionSeries s1GainSeries, s2GainSeries;
        bool blockUpdates = false;

        public MainForm() {
            InitializeComponent();
            s1Filters = new List<BiquadFilter>();
            s2Filters = new List<BiquadFilter>();
            for (int i = 0; i < 7; i++) {
                s1Filters.Add(new BiquadFilter());
                s2Filters.Add(new BiquadFilter());
            }
        }

        private void s1FiltAdd_Click(object sender, EventArgs e) {
            s1Filters.Add(new BiquadFilter());
        }

        private void s1FiltRemove_Click(object sender, EventArgs e) {
            if (s1Filters.Count > 1) s1Filters.RemoveAt(s1Filters.Count - 1);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            var s1Model = new PlotModel();
            var s1FAxis = new LogarithmicAxis() {
                AbsoluteMinimum = 10,
                AbsoluteMaximum = 30000,
                Minimum = 10,
                Maximum = 30000,
                //MajorStep = 1000,
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
                Position = AxisPosition.Left,
                Key = "SPL",
            };
            s1Model.Axes.Add(s1FAxis);
            s1Model.Axes.Add(s1SPLAxis);
            s1Model.Axes.Add(s1GainAxis);
            s1GainSeries = new LogFunctionSeries(x => s1Filters.Sum(f => f.Response(x)), 10, 30000, 1.01m) {
                YAxisKey = "Gain",
                Color = OxyColors.Green
            };
            s1Model.Series.Add(s1GainSeries);
            s1PlotView.Model = s1Model;
        }
    }
}
