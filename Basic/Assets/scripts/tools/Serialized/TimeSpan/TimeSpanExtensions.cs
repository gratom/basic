using System;

namespace Tools
{
    public static class TimeSpanExtensions
    {
        public static string ToCustomString(this TimeSpan timeSpan)
        {
            // Get the days, hours, minutes, and seconds
            int days = timeSpan.Days;
            int hours = timeSpan.Hours;
            int minutes = timeSpan.Minutes;
            int seconds = timeSpan.Seconds;

            // Format the string as "dddd.hh:mm:ss"
            return $"{days}days {hours:D2}h:{minutes:D2}m:{seconds:D2}s";
        }
    }
}
