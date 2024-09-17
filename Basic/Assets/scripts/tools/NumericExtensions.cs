using System;
using System.Resources;

namespace Tools
{
    public static class NumericExtensions
    {
        public static bool IsInRange(this int number, int minValue, int maxValue)
        {
            return number >= minValue && number <= maxValue;
        }

        public static decimal NoFrac(this decimal dec)
        {
            return Math.Truncate(dec);
        }

        public static double NoFrac(this double dbl)
        {
            return Math.Truncate(dbl);
        }

        public static float NoFrac(this float flt)
        {
            return (float)Math.Truncate(flt);
        }

        public static int ClampMin0(this int val)
        {
            return Math.Clamp(val, 0, int.MaxValue);
        }
    }

}
