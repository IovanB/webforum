using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Topic
{
    public class RemoveTopicUseCase
    {
        private readonly IWriteOnlyUseCase<Domain.Entities.Topic> topicWriteOnlyUseCase;

        public RemoveTopicUseCase(IWriteOnlyUseCase<Domain.Entities.Topic> topicWriteOnlyUseCase)
        {
            this.topicWriteOnlyUseCase = topicWriteOnlyUseCase;
        }

        public int Remove(Domain.Entities.Topic entity)
        {
            return topicWriteOnlyUseCase.Remove(entity);
        }
    }
}
