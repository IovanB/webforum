using System;

namespace Application.UseCases.Topic.Delete
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
