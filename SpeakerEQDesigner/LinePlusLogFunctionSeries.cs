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
        private List<List<DPoint>> lineSeries;
        public List<List<DPoint>> LineSeries {
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

        public LinePlusLogFunctionSeries(List<List<DPoint>> linePts, Func<decimal, decimal> f, decimal lowerLim, decimal upperLim, decimal logStep) {
            UpdateFunc(linePts, f, lowerLim, upperLim, logStep);
        }

        private void UpdateFunc(List<List<DPoint>> linePts, Func<decimal, decimal> f, decimal lowerLim, decimal upperLim, decimal logStep) {
            lineSeries = linePts;
            func = f;
            lowLim = lowerLim;
            upLim = upperLim;
            step = logStep;

            Points.Clear();
            var lpIndices = new int[lineSeries.Count];
            var lpIntercept = new decimal[lineSeries.Count];
            var lpSlope = new decimal[lineSeries.Count];

            decimal x;
            for (x = lowerLim; x < upLim * logStep; x *= logStep) {
                if (x > upLim) x = upLim;

                decimal lineValue = 0;
                
                for (int i = 0; i < lineSeries.Count; i++) {
                    var ser = lineSeries[i];
                    if (ser[lpIndices[i]].X <= x) {
                        while (lpIndices[i] < ser.Count && ser[lpIndices[i]].X <= x) lpIndices[i]++;
                        if (lpIndices[i] < ser.Count) {
                            var cp = ser[lpIndices[i] - 1];
                            var np = ser[lpIndices[i]];
                            lpSlope[i] = (np.Y - cp.Y) / DecimalEx.Log10(np.X / cp.X);
                            lpIntercept[i] = cp.Y - lpSlope[i] * DecimalEx.Log10(cp.X);
                        }
                    }

                    if (lpIndices[i] == 0 && ser[0].X >= x) lineValue += ser[0].Y;
                    else if (lpIndices[i] < ser.Count) lineValue += lpIntercept[i] + lpSlope[i] * (DecimalEx.Log10(x));
                    else lineValue += ser.Last().Y;
                }

                Points.Add(new DataPoint((double)x, (double)(func(x) + lineValue)));
            }
        }

        protected override void UpdateData() {
            UpdateFunc(lineSeries, func, lowLim, upLim, step);
            base.UpdateData();
        }
    }
}
