using System;

namespace Tools
{
    [Serializable]
    public struct TimeSpanSerialized
    {
        public long ticks;
        public TimeSpan AdultAge => TimeSpan.FromTicks(ticks);

        public static implicit operator TimeSpan(TimeSpanSerialized d)
        {
            return d.AdultAge;
        }

        public static implicit operator TimeSpanSerialized(TimeSpan d)
        {
            return new TimeSpanSerialized() { ticks = d.Ticks };
        }
    }
}
