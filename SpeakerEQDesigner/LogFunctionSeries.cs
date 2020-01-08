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
        private Func<decimal, decimal> func;
        public Func<decimal, decimal> Function {
            get { return func; }
            set { UpdateFunc(value, lowLim, upLim, step); }
        }

        private decimal lowLim;
        public decimal LowerLimit {
            get { return lowLim; }
            set { UpdateFunc(func, value, upLim, step); }
        }

        private decimal upLim;
        public decimal UpperLimit {
            get { return upLim; }
            set { UpdateFunc(func, lowLim, value, step); }
        }

        private decimal step;
        public decimal Step {
            get { return step; }
            set { UpdateFunc(func, lowLim, upLim, value); }
        }

        public LogFunctionSeries(Func<decimal, decimal> f, decimal lowerLim, decimal upperLim, decimal logStep) {
            UpdateFunc(f, lowerLim, upperLim, logStep);
        }

        private void UpdateFunc(Func<decimal, decimal> f, decimal lowerLim, decimal upperLim, decimal logStep) {
            func = f;
            lowLim = lowerLim;
            upLim = upperLim;
            step = logStep;

            Points.Clear();
            for (decimal x = lowerLim; x < upLim; x *= logStep) {
                Points.Add(new DataPoint((double)x, (double)func(x)));
            }
            Points.Add(new DataPoint((double)upLim, (double)func(upLim)));
        }
    }
}
