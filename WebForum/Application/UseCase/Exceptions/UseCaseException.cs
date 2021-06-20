using System;

namespace WebForum.Application.UseCase.Exceptions
{
    public class UseCaseException : ApplicationException
    {
        public UseCaseException(string message) : base(message)
        {

        }
    }
}
