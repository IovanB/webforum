using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Topic
{
    public class AddTopicUseCase
    {
        private readonly IWriteOnlyUseCase<Domain.Entities.Topic> topicWriteOnlyUseCase;

        public AddTopicUseCase(IWriteOnlyUseCase<Domain.Entities.Topic> topicWriteOnlyUseCase)
        {
            this.topicWriteOnlyUseCase = topicWriteOnlyUseCase;
        }

        public int Add(Domain.Entities.Topic topic)
        {
            return topicWriteOnlyUseCase.Add(topic);
        }
    }
}
