using System;

namespace Application.UseCases.Post.Get
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
