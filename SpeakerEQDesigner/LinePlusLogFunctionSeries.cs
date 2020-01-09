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

        private Func<decimal, decimal> func;
        public Func<decimal, decimal> Function {
            get { return func; }
            set { UpdateFunc(lineSeries, value, lowLim, upLim, step); }
        }

        private decimal lowLim;
        public decimal LowerLimit {
            get { return lowLim; }
            set { UpdateFunc(lineSeries, func, value, upLim, step); }
        }

        private decimal upLim;
        public decimal UpperLimit {
            get { return upLim; }
            set { UpdateFunc(lineSeries, func, lowLim, value, step); }
        }

        private decimal step;
        public decimal Step {
            get { return step; }
            set { UpdateFunc(lineSeries, func, lowLim, upLim, value); }
        }

        public LinePlusLogFunctionSeries(List<DPoint> linePts, Func<decimal, decimal> f, decimal lowerLim, decimal upperLim, decimal logStep) {
            UpdateFunc(linePts, f, lowerLim, upperLim, logStep);
        }

        private void UpdateFunc(List<DPoint> linePts, Func<decimal, decimal> f, decimal lowerLim, decimal upperLim, decimal logStep) {
            lineSeries = linePts;
            func = f;
            lowLim = lowerLim;
            upLim = upperLim;
            step = logStep;

            Points.Clear();
            int lpIndex = 0;
            decimal lpIntercept = 0m;
            decimal lpSlope = 0m;

            for (decimal x = lowerLim; x < upLim * logStep; x *= logStep) {
                if (x > upLim) x = upLim;

                decimal lineValue = 0;
                
                if (lineSeries[lpIndex].X <= x) {
                    while (lpIndex < lineSeries.Count && lineSeries[lpIndex].X <= x) lpIndex++;
                    if (lpIndex < lineSeries.Count) {
                        var cp = lineSeries[lpIndex - 1];
                        var np = lineSeries[lpIndex];
                        lpSlope = (np.Y - cp.Y) / DecimalEx.Log10(np.X / cp.X);
                        lpIntercept = cp.Y - lpSlope * DecimalEx.Log10(cp.X);
                    }
                }

                if (lpIndex == 0 && lineSeries[0].X >= x) lineValue = lineSeries[0].Y;
                else if (lpIndex < lineSeries.Count) lineValue = lpIntercept + lpSlope * (DecimalEx.Log10(x));
                else lineValue = lineSeries.Last().Y;

                Points.Add(new DataPoint((double)x, (double)(func(x) + lineValue)));
            }
        }

        protected override void UpdateData() {
            UpdateFunc(lineSeries, func, lowLim, upLim, step);
            base.UpdateData();
        }
    }
}
