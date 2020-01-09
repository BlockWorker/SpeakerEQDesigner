using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace SpeakerEQDesigner {
    class LogFunctionSeries : LineSeries {
        private Func<double, double> func;
        public Func<double, double> Function {
            get { return func; }
            set { UpdateFunc(value, lowLim, upLim, step); }
        }

        private double lowLim;
        public double LowerLimit {
            get { return lowLim; }
            set { UpdateFunc(func, value, upLim, step); }
        }

        private double upLim;
        public double UpperLimit {
            get { return upLim; }
            set { UpdateFunc(func, lowLim, value, step); }
        }

        private double step;
        public double Step {
            get { return step; }
            set { UpdateFunc(func, lowLim, upLim, value); }
        }

        public LogFunctionSeries(Func<double, double> f, double lowerLim, double upperLim, double logStep) {
            UpdateFunc(f, lowerLim, upperLim, logStep);
        }

        private void UpdateFunc(Func<double, double> f, double lowerLim, double upperLim, double logStep) {
            func = f;
            lowLim = lowerLim;
            upLim = upperLim;
            step = logStep;

            Points.Clear();
            for (double x = lowerLim; x < upLim; x *= logStep) {
                Points.Add(new DataPoint((double)x, func(x)));
            }
            Points.Add(new DataPoint(upLim, func(upLim)));
        }

        protected override void UpdateData() {
            UpdateFunc(func, lowLim, upLim, step);
            base.UpdateData();
        }
    }
}
