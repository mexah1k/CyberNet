﻿using System;

namespace Infrastructure.Exceptions
{
    public static class Throw
    {
        public static void IfNull(object source)
        {
            if (source == null)
                throw new ArgumentNullException($"Argument {nameof(source)} can not be null.");
        }
    }
}