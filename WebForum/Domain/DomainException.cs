using System;

namespace Domain
{
    public class DomainException: Exception
    {
        internal DomainException(string businessMessage)
            :base(businessMessage)
        {

        }

        internal static void When(bool hasError, string message)
        {
            if (hasError)
                throw new Exception(message);
        }
    }
}
