using System;

namespace Application.UseCases.Topic.Get
{
    public class TopicGetRequest
    {
        public Guid Id { get; private set; }

        public TopicGetRequest(Guid id)
        {
            Id = id;
        }
    }
}
