using Application.Boundaries.Post;
using System;
using System.Collections.Generic;

namespace WebForumApi.UseCase.Post
{
    public class PostPresenter : IOutputPort
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

        public void Standard(Domain.Entities.Post post)
        {
            throw new NotImplementedException();
        }

        public void Standard(IList<Domain.Entities.Post> post)
        {
            throw new NotImplementedException();
        }
    }
}
