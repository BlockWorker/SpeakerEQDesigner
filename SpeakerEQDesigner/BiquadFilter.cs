using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecimalMath;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace SpeakerEQDesigner {
    public class BiquadFilter {
        [XmlIgnore] public Config cfg;

        public decimal b0 = 1;
        public decimal b1 = 0;
        public decimal b2 = 0;
        public decimal a1 = 0;
        public decimal a2 = 0;
        [XmlIgnore] public int FP_shift = 0;
        [XmlIgnore] public int FP_b0 { get; private set; } = 0x00800000;
        [XmlIgnore] public int FP_b1 { get; private set; } = 0;
        [XmlIgnore] public int FP_b2 { get; private set; } = 0;
        [XmlIgnore] public int FP_a1 { get; private set; } = 0;
        [XmlIgnore] public int FP_a2 { get; private set; } = 0;
        [XmlIgnore] public decimal rounded_b0 { get; private set; } = 1;
        [XmlIgnore] public decimal rounded_b1 { get; private set; } = 0;
        [XmlIgnore] public decimal rounded_b2 { get; private set; } = 0;
        [XmlIgnore] public decimal rounded_a1 { get; private set; } = 0;
        [XmlIgnore] public decimal rounded_a2 { get; private set; } = 0;
        public FilterType Type { get; set; } = FilterType.Disabled;
        public decimal Frequency { get; set; } = 1000m;
        public decimal Q { get; set; } = 1m;
        public decimal Gain { get; set; } = 0;
        public decimal SampleRate { get; set; } = 96000;
        public bool NegateA { get; set; } = true;


        public int ToFP(decimal value) {
            return (int)Math.Round(value / (1 << FP_shift) * cfg.FPMult, MidpointRounding.AwayFromZero);
        }

        public decimal FromFP(int value) {
            return value / cfg.FPMult * (1 << FP_shift);
        }

        public void UpdateFilter() {
            var A = DecimalEx.Pow(10, Gain / 40m);
            var w = DecimalEx.TwoPi * Frequency / SampleRate;
            var cosw = DecimalEx.Cos(w);
            var sinw = DecimalEx.Sin(w);
            var alpha = sinw / (2 * Q);
            var Am1cosw = (A - 1m) * cosw;
            var Ap1cosw = (A + 1m) * cosw;
            var TwoSqrtAalpha = 2m * DecimalEx.Sqrt(A) * alpha;
            decimal a0 = 1m;

            switch (Type) {
                case FilterType.Disabled:
                    b0 = 1;
                    b1 = b2 = a1 = a2 = 0;
                    break;
                case FilterType.EQ:
                    b0 = 1m + alpha * A;
                    b1 = a1 = -2m * cosw;
                    b2 = 1m - alpha * A;
                    a0 = 1m + alpha / A;
                    a2 = 1m - alpha / A;
                    break;
                case FilterType.Lowpass:
                    b1 = 1m - cosw;
                    b2 = b0 = b1 / 2m;
                    a0 = 1m + alpha;
                    a1 = -2m * cosw;
                    a2 = 1m - alpha;
                    break;
                case FilterType.Highpass:
                    b1 = -1m - cosw;
                    b0 = b2 = -b1 / 2m;
                    a0 = 1m + alpha;
                    a1 = -2m * cosw;
                    a2 = 1m - alpha;
                    break;
                case FilterType.Bandpass:
                    b0 = alpha;
                    b1 = 0;
                    b2 = -alpha;
                    a0 = 1m + alpha;
                    a1 = -2m * cosw;
                    a2 = 1m - alpha;
                    break;
                case FilterType.Notch:
                    b0 = b2 = 1m;
                    a0 = 1m + alpha;
                    a1 = b1 = -2m * cosw;
                    a2 = 1m - alpha;
                    break;
                case FilterType.LowShelf:
                    b0 = A * (A + 1m - Am1cosw + TwoSqrtAalpha);
                    b1 = 2m * A * (A - 1m - Ap1cosw);
                    b2 = A * (A + 1m - Am1cosw - TwoSqrtAalpha);
                    a0 = A + 1m + Am1cosw + TwoSqrtAalpha;
                    a1 = -2m * (A - 1m + Ap1cosw);
                    a2 = A + 1m + Am1cosw - TwoSqrtAalpha;
                    break;
                case FilterType.HighShelf:
                    b0 = A * (A + 1m + Am1cosw + TwoSqrtAalpha);
                    b1 = -2m * A * (A - 1m + Ap1cosw);
                    b2 = A * (A + 1m + Am1cosw - TwoSqrtAalpha);
                    a0 = A + 1m - Am1cosw + TwoSqrtAalpha;
                    a1 = 2m * (A - 1m - Ap1cosw);
                    a2 = A + 1m - Am1cosw - TwoSqrtAalpha;
                    break;
                case FilterType.Custom:
                    break;
            }
            b0 /= a0;
            b1 /= a0;
            b2 /= a0;
            a1 /= a0;
            a2 /= a0;
            if (NegateA && Type != FilterType.Custom) {
                a1 *= -1m;
                a2 *= -1m;
            }

            int shift = 0;
            decimal maxVal = Math.Max(b0, Math.Max(b1, Math.Max(b2, Math.Max(a1, a2))));
            if (maxVal > cfg.FPMax) {
                shift = Math.Max(shift, (int)DecimalEx.Ceiling(DecimalEx.Log2(maxVal / cfg.FPMax)));
            }
            decimal minVal = Math.Min(b0, Math.Min(b1, Math.Min(b2, Math.Min(a1, a2))));
            if (minVal < cfg.FPMin) {
                shift = Math.Max(shift, (int)DecimalEx.Ceiling(DecimalEx.Log2(minVal / cfg.FPMin)));
            }
            RecomputeFPForGivenShift(shift);
        }

        public void RecomputeFPForGivenShift(int shift) {
            FP_shift = shift;
            FP_b0 = ToFP(b0);
            FP_b1 = ToFP(b1);
            FP_b2 = ToFP(b2);
            FP_a1 = ToFP(a1);
            FP_a2 = ToFP(a2);
            rounded_b0 = FromFP(FP_b0);
            rounded_b1 = FromFP(FP_b1);
            rounded_b2 = FromFP(FP_b2);
            rounded_a1 = FromFP(FP_a1);
            rounded_a2 = FromFP(FP_a2);
        }

        public double Response(double f) {
            var w = 2d * Math.PI * f / (double)SampleRate;
            var cosw = Math.Cos(w);
            var cos2w = Math.Cos(2d * w);
            var num = (double)(b0 * b0 + b1 * b1 + b2 * b2) + 2d * (double)(b0 * b1 + b1 * b2) * cosw + 2d * (double)(b0 * b2) * cos2w;
            var denom = NegateA ? 1d + (double)(a1 * a1 + a2 * a2) - 2d * (double)(a1 - a1 * a2) * cosw - 2 * (double)a2 * cos2w : 
                1 + (double)(a1 * a1 + a2 * a2) + 2 * (double)(a1 + a1 * a2) * cosw + 2 * (double)a2 * cos2w;
            return 20d * Math.Log10(Math.Sqrt(num / denom));
        }
    }

    public enum FilterType {
        Disabled = 0,
        EQ,
        Lowpass,
        Highpass,
        Bandpass,
        Notch,
        LowShelf,
        HighShelf,
        Custom
    }
}
