using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace SpeakerEQDesigner {
    class DoubleFilteredResponseSeries : LineSeries {
        private List<DPoint> lineSeries1;
        public List<DPoint> LineSeries1 {
            get { return lineSeries1; }
            set { UpdateFunc(value, lineSeries2, func1, func2, lowLim, upLim, step); }
        }

        private List<DPoint> lineSeries2;
        public List<DPoint> LineSeries2 {
            get { return lineSeries2; }
            set { UpdateFunc(lineSeries1, value, func1, func2, lowLim, upLim, step); }
        }

        private Func<double, double> func1;
        public Func<double, double> Function1 {
            get { return func1; }
            set { UpdateFunc(lineSeries1, lineSeries2, value, func2, lowLim, upLim, step); }
        }

        private Func<double, double> func2;
        public Func<double, double> Function2 {
            get { return func2; }
            set { UpdateFunc(lineSeries1, lineSeries2, func1, value, lowLim, upLim, step); }
        }

        private double lowLim;
        public double LowerLimit {
            get { return lowLim; }
            set { UpdateFunc(lineSeries1, lineSeries2, func1, func2, value, upLim, step); }
        }

        private double upLim;
        public double UpperLimit {
            get { return upLim; }
            set { UpdateFunc(lineSeries1, lineSeries2, func1, func2, lowLim, value, step); }
        }

        private double step;
        public double Step {
            get { return step; }
            set { UpdateFunc(lineSeries1, lineSeries2, func1, func2, lowLim, upLim, value); }
        }



        public event EventHandler OnUpdate;

        public DoubleFilteredResponseSeries(List<DPoint> linePts1, List<DPoint> linePts2, Func<double, double> f1, Func<double, double> f2, double lowerLim, double upperLim, double logStep) {
            UpdateFunc(linePts1, linePts2, f1, f2, lowerLim, upperLim, logStep);
        }

        private void UpdateFunc(List<DPoint> linePts1, List<DPoint> linePts2, Func<double, double> f1, Func<double, double> f2, double lowerLim, double upperLim, double logStep) {
            lineSeries1 = linePts1;
            lineSeries2 = linePts2;
            func1 = f1;
            func2 = f2;
            lowLim = lowerLim;
            upLim = upperLim;
            step = logStep;

            Points.Clear();

            int lpIndex1 = 0;
            double lpIntercept1 = 0d;
            double lpSlope1 = 0d;
            int lpIndex2 = 0;
            double lpIntercept2 = 0d;
            double lpSlope2 = 0d;

            for (double x = lowerLim; x < upLim * logStep; x *= logStep) {
                if (x > upLim) x = upLim;

                double lineValue1 = 0;
                
                if (lineSeries1[lpIndex1].X <= x) {
                    while (lpIndex1 < lineSeries1.Count && lineSeries1[lpIndex1].X <= x) lpIndex1++;
                    if (lpIndex1 < lineSeries1.Count) {
                        var cp = lineSeries1[lpIndex1 - 1];
                        var np = lineSeries1[lpIndex1];
                        lpSlope1 = (np.Y - cp.Y) / Math.Log10(np.X / cp.X);
                        lpIntercept1 = cp.Y - lpSlope1 * Math.Log10(cp.X);
                    }
                }

                if (lpIndex1 == 0 && lineSeries1[0].X >= x) lineValue1 = lineSeries1[0].Y;
                else if (lpIndex1 < lineSeries1.Count) lineValue1 = lpIntercept1 + lpSlope1 * (Math.Log10(x));
                else lineValue1 = lineSeries1.Last().Y;

                double lineValue2 = 0;

                if (lineSeries2[lpIndex2].X <= x) {
                    while (lpIndex2 < lineSeries2.Count && lineSeries2[lpIndex2].X <= x) lpIndex2++;
                    if (lpIndex2 < lineSeries2.Count) {
                        var cp = lineSeries2[lpIndex2 - 1];
                        var np = lineSeries2[lpIndex2];
                        lpSlope2 = (np.Y - cp.Y) / Math.Log10(np.X / cp.X);
                        lpIntercept2 = cp.Y - lpSlope2 * Math.Log10(cp.X);
                    }
                }

                if (lpIndex2 == 0 && lineSeries2[0].X >= x) lineValue2 = lineSeries2[0].Y;
                else if (lpIndex2 < lineSeries2.Count) lineValue2 = lpIntercept2 + lpSlope2 * (Math.Log10(x));
                else lineValue2 = lineSeries2.Last().Y;

                var val1 = Math.Pow(10d, (func1(x) + lineValue1) / 10d);
                var val2 = Math.Pow(10d, (func2(x) + lineValue2) / 10d);
                var total = 10d * Math.Log10(val1 + val2);

                Points.Add(new DataPoint(x, total));
            }

            OnUpdate?.Invoke(this, EventArgs.Empty);
        }

        protected override void UpdateData() {
            UpdateFunc(lineSeries1, lineSeries2, func1, func2, lowLim, upLim, step);
            base.UpdateData();
        }
    }
}
