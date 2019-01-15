using System;

namespace Infrastructure.Extensions
{
    public static class DigitExtensions
    {
        public static bool EqualWithNull<T>(this T? digit, T? target) where T : struct, IComparable, IComparable<T>,
            IConvertible, IEquatable<T>, IFormattable
        {
            return !target.HasValue || Equals(digit, target);
        }

        public static bool EqualWithNull<T>(this T digit, T? target) where T : struct, IComparable, IComparable<T>,
            IConvertible, IEquatable<T>, IFormattable
        {
            return !target.HasValue || Equals(digit, target);
        }
    }
}