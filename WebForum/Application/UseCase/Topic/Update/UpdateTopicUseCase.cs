using Application.Repositories.Interfaces;
using Application.UseCase.Topic.Update;

namespace WebForum.Application.UseCase.Topic
{
    public class UpdateTopicUseCase : IUpdateTopicUseCase
    {
        private readonly ITopicWriteOnlyUseCase topicWriteOnlyUseCase;

        public UpdateTopicUseCase(ITopicWriteOnlyUseCase topicWriteOnlyUseCase)
        {
            this.topicWriteOnlyUseCase = topicWriteOnlyUseCase;
        }

        public int Update(Domain.Entities.Topic topic)
        {

            return topicWriteOnlyUseCase.Update(topic);
        }
    }
}
