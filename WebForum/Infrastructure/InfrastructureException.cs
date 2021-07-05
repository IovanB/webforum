using System;

namespace Infrastructure
{
    public class InfrastructureException: Exception
    {
        public InfrastructureException(string businessMessage)
            :base(businessMessage)
        {

        }
    }
}
