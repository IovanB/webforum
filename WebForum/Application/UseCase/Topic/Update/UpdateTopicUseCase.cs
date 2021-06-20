using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Topic
{
    public class UpdateTopicUseCase 
    {
        private readonly IWriteOnlyUseCase<Domain.Entities.Topic> topicWriteOnlyUseCase;

        public UpdateTopicUseCase(IWriteOnlyUseCase<Domain.Entities.Topic> topicWriteOnlyUseCase)
        {
            this.topicWriteOnlyUseCase = topicWriteOnlyUseCase;
        }

        public int Update(Domain.Entities.Topic topic)
        {

            return topicWriteOnlyUseCase.Update(topic);
        }
    }
}
