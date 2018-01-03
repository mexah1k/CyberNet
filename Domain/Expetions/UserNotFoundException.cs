using Abstractions.Exceptions;

namespace Domain.Expetions
{
    public class UserNotFoundException : BaseException
    {
        public UserNotFoundException() : base(ExceptionMessages.UserNotFoundException)
        {
        }
    }
}