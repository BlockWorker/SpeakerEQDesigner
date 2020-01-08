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
    public partial class SpeakerResponseForm : Form {
        public List<DPoint> response;
        private LinearAxis splAxis;
        private LineSeries series;
        private int currPoint = 0;

        public SpeakerResponseForm() {
            InitializeComponent();
            response = new List<DPoint>();
            response.Add(new DPoint(10, 90));
            response.Add(new DPoint(30000, 90));
        }

        public SpeakerResponseForm(List<DPoint> _response) {
            response = _response;
            pointNumberLabel.Text = response.Count.ToString();
            pointSelect.Maximum = response.Count;
        }

        private void SpeakerResponseForm_Load(object sender, EventArgs e) {
            var model = new PlotModel();
            var freqAxis = new LogarithmicAxis {
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
            model.Axes.Add(freqAxis);
            splAxis = new LinearAxis {
                Title = "SPL",
                Unit = "dB",
                AbsoluteMinimum = 0,
                AbsoluteMaximum = 150,
                Minimum = 70,
                Maximum = 110,
                MajorStep = 10,
                MinorStep = 5,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Solid,
                Position = AxisPosition.Left
            };
            model.Axes.Add(splAxis);
            series = new LineSeries() {
                ItemsSource = response,
                Color = OxyColors.Red,
                LineStyle = LineStyle.Solid,
                Mapping = (p) => new DataPoint((double)((DPoint)p).X, (double)((DPoint)p).Y)
            };
            model.Series.Add(series);
            plotView.Model = model;
        }

        private void pointSelect_ValueChanged(object sender = null, EventArgs e = null) {
            currPoint = ((int)pointSelect.Value) - 1;
            deleteButton.Enabled = freqSelect.Enabled = currPoint != 0 && currPoint != response.Count - 1;
            if (currPoint > 0) freqSelect.Minimum = response[currPoint - 1].X;
            else freqSelect.Minimum = 10;
            if (currPoint < response.Count - 1) freqSelect.Maximum = response[currPoint + 1].X;
            else freqSelect.Maximum = 30000;
            freqSelect.Value = response[currPoint].X;
            splSelect.Value = response[currPoint].Y;
        }

        private void freqSelect_ValueChanged(object sender, EventArgs e) {
            response[currPoint].X = freqSelect.Value;
            plotView.InvalidatePlot(true);
        }

        private void splSelect_ValueChanged(object sender, EventArgs e) {
            response[currPoint].Y = splSelect.Value;
            plotView.InvalidatePlot(true);
        }

        private void insertButton_Click(object sender, EventArgs e) {
            if (currPoint == response.Count - 1) {
                freqSelect.Enabled = true;
                deleteButton.Enabled = true;
            }
            response.Insert(currPoint + 1, new DPoint(response[currPoint]));
            pointNumberLabel.Text = response.Count.ToString();
            pointSelect.Maximum = response.Count;
            plotView.InvalidatePlot(true);
        }

        private void deleteButton_Click(object sender, EventArgs e) {
            response.RemoveAt(currPoint);
            pointSelect_ValueChanged();
            plotView.InvalidatePlot(true);
        }
    }

    public class DPoint {
        public DPoint(decimal x, decimal y) {
            X = x;
            Y = y;
        }

        public DPoint(DPoint other) {
            X = other.X;
            Y = other.Y;
        }

        public decimal X { get; set; }
        public decimal Y { get; set; }
    }
}
