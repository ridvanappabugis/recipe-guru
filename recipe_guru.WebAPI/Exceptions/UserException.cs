using System;
namespace recipeguru.WebAPI.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string message)
            : base(message)
        {

        }
    }
}
