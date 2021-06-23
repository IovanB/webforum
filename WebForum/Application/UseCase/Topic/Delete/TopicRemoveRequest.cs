using System;

namespace Application.UseCase.Topic.Delete
{
    public class TopicRemoveRequest
    {
        public Guid Id{ get; private set; }
        public TopicRemoveRequest(Guid id)
        {
            Id = id;
        }
    }
}
