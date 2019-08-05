using System;

namespace Model.Extension
{
    public static class TimeExtension
    {
        /// <summary>
        /// Convert UnixTime to DateTime
        /// </summary>
        /// <param name="timestamp">Unix time</param>
        /// <returns></returns>
        public static DateTime ToDateTime(long timestamp)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(timestamp).LocalDateTime;
        }

        /// <summary>
        /// Convert date to unix time
        /// </summary>
        /// <param name="time">Date. Example (16.07.2019 21:10:30)</param>
        /// <returns>retun unix time</returns>
        public static long StartTime(string time)
        {
            DateTime parseTime = DateTime.Parse(time);
            return (long)(parseTime.AddHours(-3) - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        /// <summary>
        /// Convert date to unix time. If time = null then we get a UtcNow
        /// </summary>
        /// <param name="time">Date. Example (16.07.2019 21:10:30)</param>
        /// <returns>retun unix time</returns>
        public static long EndTime(string time = null)
        {
            if (time == null)
            {
                return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
            }
            DateTime parseTime = DateTime.Parse(time);
            return (long)(parseTime.AddHours(-3) - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        /// <summary>
        /// Get a current time stamp for UTC
        /// </summary>
        /// <returns>Returns timestamp in milliseconds</returns>
        public static long getTimeStamp()
        {
            var timeSt = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
            return timeSt;
        }
    }
}
