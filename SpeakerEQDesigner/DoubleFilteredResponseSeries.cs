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

        private Func<decimal, decimal> func1;
        public Func<decimal, decimal> Function1 {
            get { return func1; }
            set { UpdateFunc(lineSeries1, lineSeries2, value, func2, lowLim, upLim, step); }
        }

        private Func<decimal, decimal> func2;
        public Func<decimal, decimal> Function2 {
            get { return func2; }
            set { UpdateFunc(lineSeries1, lineSeries2, func1, value, lowLim, upLim, step); }
        }

        private decimal lowLim;
        public decimal LowerLimit {
            get { return lowLim; }
            set { UpdateFunc(lineSeries1, lineSeries2, func1, func2, value, upLim, step); }
        }

        private decimal upLim;
        public decimal UpperLimit {
            get { return upLim; }
            set { UpdateFunc(lineSeries1, lineSeries2, func1, func2, lowLim, value, step); }
        }

        private decimal step;
        public decimal Step {
            get { return step; }
            set { UpdateFunc(lineSeries1, lineSeries2, func1, func2, lowLim, upLim, value); }
        }

        public DoubleFilteredResponseSeries(List<DPoint> linePts1, List<DPoint> linePts2, Func<decimal, decimal> f1, Func<decimal, decimal> f2, decimal lowerLim, decimal upperLim, decimal logStep) {
            UpdateFunc(linePts1, linePts2, f1, f2, lowerLim, upperLim, logStep);
        }

        private void UpdateFunc(List<DPoint> linePts1, List<DPoint> linePts2, Func<decimal, decimal> f1, Func<decimal, decimal> f2, decimal lowerLim, decimal upperLim, decimal logStep) {
            lineSeries1 = linePts1;
            lineSeries2 = linePts2;
            func1 = f1;
            func2 = f2;
            lowLim = lowerLim;
            upLim = upperLim;
            step = logStep;

            Points.Clear();

            int lpIndex1 = 0;
            decimal lpIntercept1 = 0m;
            decimal lpSlope1 = 0m;
            int lpIndex2 = 0;
            decimal lpIntercept2 = 0m;
            decimal lpSlope2 = 0m;

            for (decimal x = lowerLim; x < upLim * logStep; x *= logStep) {
                if (x > upLim) x = upLim;

                decimal lineValue1 = 0;
                
                if (lineSeries1[lpIndex1].X <= x) {
                    while (lpIndex1 < lineSeries1.Count && lineSeries1[lpIndex1].X <= x) lpIndex1++;
                    if (lpIndex1 < lineSeries1.Count) {
                        var cp = lineSeries1[lpIndex1 - 1];
                        var np = lineSeries1[lpIndex1];
                        lpSlope1 = (np.Y - cp.Y) / DecimalEx.Log10(np.X / cp.X);
                        lpIntercept1 = cp.Y - lpSlope1 * DecimalEx.Log10(cp.X);
                    }
                }

                if (lpIndex1 == 0 && lineSeries1[0].X >= x) lineValue1 = lineSeries1[0].Y;
                else if (lpIndex1 < lineSeries1.Count) lineValue1 = lpIntercept1 + lpSlope1 * (DecimalEx.Log10(x));
                else lineValue1 = lineSeries1.Last().Y;

                decimal lineValue2 = 0;

                if (lineSeries2[lpIndex2].X <= x) {
                    while (lpIndex2 < lineSeries2.Count && lineSeries2[lpIndex2].X <= x) lpIndex2++;
                    if (lpIndex2 < lineSeries2.Count) {
                        var cp = lineSeries2[lpIndex2 - 1];
                        var np = lineSeries2[lpIndex2];
                        lpSlope2 = (np.Y - cp.Y) / DecimalEx.Log10(np.X / cp.X);
                        lpIntercept2 = cp.Y - lpSlope2 * DecimalEx.Log10(cp.X);
                    }
                }

                if (lpIndex2 == 0 && lineSeries2[0].X >= x) lineValue2 = lineSeries2[0].Y;
                else if (lpIndex2 < lineSeries2.Count) lineValue2 = lpIntercept2 + lpSlope2 * (DecimalEx.Log10(x));
                else lineValue2 = lineSeries2.Last().Y;

                var val1 = DecimalEx.Pow(10m, (func1(x) + lineValue1) / 10m);
                var val2 = DecimalEx.Pow(10m, (func2(x) + lineValue2) / 10m);
                var total = 10m * DecimalEx.Log10(val1 + val2);

                Points.Add(new DataPoint((double)x, (double)total));
            }
        }

        protected override void UpdateData() {
            UpdateFunc(lineSeries1, lineSeries2, func1, func2, lowLim, upLim, step);
            base.UpdateData();
        }
    }
}
