using Application.Boundaries.User;
using System;
using System.Collections.Generic;

namespace WebForumApi.UseCase.User
{
    public class UserPresenter : IOutputPort
    {
        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void NotFound(string message)
        {
            throw new NotImplementedException();
        }

        public void Standard(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Standard(Domain.Entities.User user)
        {
            throw new NotImplementedException();
        }

        public void Standard(IList<Domain.Entities.User> user)
        {
            throw new NotImplementedException();
        }
    }
}
