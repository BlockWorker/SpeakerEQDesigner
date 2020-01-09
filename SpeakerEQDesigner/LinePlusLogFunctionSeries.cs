using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using DecimalMath;

namespace SpeakerEQDesigner {
    class LinePlusLogFunctionSeries : LineSeries {
        private List<DPoint> lineSeries;
        public List<DPoint> LineSeries {
            get { return lineSeries; }
            set { UpdateFunc(value, func, lowLim, upLim, step); }
        }

        private Func<double, double> func;
        public Func<double, double> Function {
            get { return func; }
            set { UpdateFunc(lineSeries, value, lowLim, upLim, step); }
        }

        private double lowLim;
        public double LowerLimit {
            get { return lowLim; }
            set { UpdateFunc(lineSeries, func, value, upLim, step); }
        }

        private double upLim;
        public double UpperLimit {
            get { return upLim; }
            set { UpdateFunc(lineSeries, func, lowLim, value, step); }
        }

        private double step;
        public double Step {
            get { return step; }
            set { UpdateFunc(lineSeries, func, lowLim, upLim, value); }
        }

        public LinePlusLogFunctionSeries(List<DPoint> linePts, Func<double, double> f, double lowerLim, double upperLim, double logStep) {
            UpdateFunc(linePts, f, lowerLim, upperLim, logStep);
        }

        private void UpdateFunc(List<DPoint> linePts, Func<double, double> f, double lowerLim, double upperLim, double logStep) {
            lineSeries = linePts;
            func = f;
            lowLim = lowerLim;
            upLim = upperLim;
            step = logStep;

            Points.Clear();
            int lpIndex = 0;
            double lpIntercept = 0d;
            double lpSlope = 0d;

            for (double x = lowerLim; x < upLim * logStep; x *= logStep) {
                if (x > upLim) x = upLim;

                double lineValue = 0;
                
                if (lineSeries[lpIndex].X <= x) {
                    while (lpIndex < lineSeries.Count && lineSeries[lpIndex].X <= x) lpIndex++;
                    if (lpIndex < lineSeries.Count) {
                        var cp = lineSeries[lpIndex - 1];
                        var np = lineSeries[lpIndex];
                        lpSlope = (np.Y - cp.Y) / Math.Log10(np.X / cp.X);
                        lpIntercept = cp.Y - lpSlope * Math.Log10(cp.X);
                    }
                }

                if (lpIndex == 0 && lineSeries[0].X >= x) lineValue = lineSeries[0].Y;
                else if (lpIndex < lineSeries.Count) lineValue = lpIntercept + lpSlope * (Math.Log10(x));
                else lineValue = lineSeries.Last().Y;

                Points.Add(new DataPoint(x, (func(x) + lineValue)));
            }
        }

        protected override void UpdateData() {
            UpdateFunc(lineSeries, func, lowLim, upLim, step);
            base.UpdateData();
        }
    }
}
