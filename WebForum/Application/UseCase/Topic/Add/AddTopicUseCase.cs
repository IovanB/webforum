using Application.Repositories.Interfaces;
using Application.UseCase.Topic.Add;

namespace WebForum.Application.UseCase.Topic
{
    public class AddTopicUseCase : IAddTopicUseCase
    {
        private readonly ITopicWriteOnlyUseCase topicWriteOnlyUseCase;

        public AddTopicUseCase(ITopicWriteOnlyUseCase topicWriteOnlyUseCase)
        {
            this.topicWriteOnlyUseCase = topicWriteOnlyUseCase;
        }

        public int Add(Domain.Entities.Topic topic)
        {
            return topicWriteOnlyUseCase.Add(topic);
        }
    }
}
