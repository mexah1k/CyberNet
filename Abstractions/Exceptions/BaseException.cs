using System;

namespace Abstractions.Exceptions
{
    public abstract class BaseException : Exception
    {
        protected BaseException()
        {
        }

        protected BaseException(string message)
            : base(message)
        {
        }

        protected BaseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}