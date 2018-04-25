using System;

namespace Infrastructure.Exceptions
{
    public static class Throw
    {
        public static void IfNull(object source, string sourceName)
        {
            if (source == null)
                throw new ArgumentNullException($"Argument {sourceName} can not be null.");
        }
    }
}