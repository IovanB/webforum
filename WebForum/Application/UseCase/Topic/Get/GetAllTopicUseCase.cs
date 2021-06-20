using System.Collections.Generic;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Topic
{
    public class GetAllTopicUseCase 
    {
        private readonly IReadOnlyUseCase<Domain.Entities.Topic> topicReadOnlyUseCase;

        public GetAllTopicUseCase(IReadOnlyUseCase<Domain.Entities.Topic> topicReadOnlyUseCase)
        {
            this.topicReadOnlyUseCase = topicReadOnlyUseCase;
        }

        public List<Domain.Entities.Topic> GetAll()
        {
            return topicReadOnlyUseCase.GetAll();
        }
    }
}
