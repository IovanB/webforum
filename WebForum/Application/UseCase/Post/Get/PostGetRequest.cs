using System;

namespace Application.UseCase.Post.Get
{
    public class PostGetRequest
    {
        public Guid Id{ get; private set; }

        public PostGetRequest(Guid id)
        {
            Id = id;
        }
    }
}
