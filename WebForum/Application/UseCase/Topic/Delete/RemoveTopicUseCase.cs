using Application.Repositories.Interfaces;
using Application.UseCase.Topic.Delete;

namespace WebForum.Application.UseCase.Topic
{
    public class RemoveTopicUseCase : IRemoveTopicUseCase
    {
        private readonly ITopicWriteOnlyUseCase topicWriteOnlyUseCase;

        public int Remove(Domain.Entities.Topic entity)
        {
            return topicWriteOnlyUseCase.Remove(entity);
        }
        public RemoveTopicUseCase(ITopicWriteOnlyUseCase topicWriteOnlyUseCase)
        {
            this.topicWriteOnlyUseCase = topicWriteOnlyUseCase;
        }
    }
}
