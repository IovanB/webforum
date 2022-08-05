using System;

namespace WebForum.Application.UseCases.Exceptions
{
    public class UseCaseException : ApplicationException
    {
        public UseCaseException(string message) : base(message)
        {

        }
    }
}
