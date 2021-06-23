using System;

namespace Application.UseCase.Post.Delete
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
