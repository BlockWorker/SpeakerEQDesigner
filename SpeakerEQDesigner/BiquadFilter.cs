using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecimalMath;
using System.Xml.Serialization;

namespace SpeakerEQDesigner {
    public class BiquadFilter {
        private const decimal FPMult = 8388608m; //2^23

        public decimal b0 = 1;
        public decimal b1 = 0;
        public decimal b2 = 0;
        public decimal a1 = 0;
        public decimal a2 = 0;
        [XmlIgnore] public uint FP_b0 { get; private set; } = 0x00800000;
        [XmlIgnore] public uint FP_b1 { get; private set; } = 0;
        [XmlIgnore] public uint FP_b2 { get; private set; } = 0;
        [XmlIgnore] public uint FP_a1 { get; private set; } = 0;
        [XmlIgnore] public uint FP_a2 { get; private set; } = 0;
        public FilterType Type { get; set; } = FilterType.Disabled;
        public decimal Frequency { get; set; } = 1000m;
        public decimal Q { get; set; } = 1m;
        public decimal Gain { get; set; } = 0;
        public decimal SampleRate { get; set; } = 96000;
        public bool NegateA { get; set; } = true;

        public static uint ToFP(decimal value) {
            var raw = (int)Math.Round(value * FPMult, MidpointRounding.AwayFromZero);
            if (raw < 0) return (uint)(-raw | 0x08000000);
            else return (uint)raw;
        }

        public static decimal FromFP(uint value) {
            int raw = (int)value;
            if ((raw & 0x08000000) > 0) raw = -(raw ^ 0x08000000);
            return raw / FPMult;
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
                    FP_b0 = 0x00800000;
                    FP_b1 = FP_b2 = FP_a1 = FP_a2 = 0;
                    return;
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
            FP_b0 = ToFP(b0);
            FP_b1 = ToFP(b1);
            FP_b2 = ToFP(b2);
            FP_a1 = ToFP(a1);
            FP_a2 = ToFP(a2);
            b0 = FromFP(FP_b0);
            b1 = FromFP(FP_b1);
            b2 = FromFP(FP_b2);
            a1 = FromFP(FP_a1);
            a2 = FromFP(FP_a2);
        }

        public decimal Response(decimal f) {
            var w = DecimalEx.TwoPi * f / SampleRate;
            var cosw = DecimalEx.Cos(w);
            var cos2w = DecimalEx.Cos(2 * w);
            var num = b0 * b0 + b1 * b1 + b2 * b2 + 2 * (b0 * b1 + b1 * b2) * cosw + 2 * b0 * b2 * cos2w;
            var denom = NegateA ? 1 + a1 * a1 + a2 * a2 - 2 * (a1 - a1 * a2) * cosw - 2 * a2 * cos2w : 
                1 + a1 * a1 + a2 * a2 + 2 * (a1 + a1 * a2) * cosw + 2 * a2 * cos2w;
            return 20m * DecimalEx.Log10(DecimalEx.Sqrt(num / denom));
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
