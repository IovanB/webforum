using System;

namespace Application.UseCases.Post.Delete
{
    public class PostRemoveRequest
    {
        public Guid Id { get; private set; }

        public PostRemoveRequest(Guid id)
        {
            Id = id;
        }
    }
}
