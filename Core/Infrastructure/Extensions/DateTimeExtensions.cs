using System;

namespace Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool GreaterThan(this DateTime source, DateTime target)
        {
            return target.Equals(DateTime.MinValue) || source.Date > target.Date;
        }

        public static bool LessThan(this DateTime source, DateTime target)
        {
            return target.Equals(DateTime.MinValue) || source.Date < target.Date;
        }
    }
}