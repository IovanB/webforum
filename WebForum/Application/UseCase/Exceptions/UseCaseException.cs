using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Application.UseCase.Exceptions
{
    public class UseCaseException : ApplicationException
    {
        public UseCaseException(string message) : base(message)
        {

        }
    }
}
