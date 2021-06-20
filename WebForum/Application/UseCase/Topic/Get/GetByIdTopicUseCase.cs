using System;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Topic
{
    public class GetByIdTopicUseCase
    {
        private readonly IReadOnlyUseCase<Domain.Entities.Topic> topicReadOnlyUseCase;

        public GetByIdTopicUseCase(IReadOnlyUseCase<Domain.Entities.Topic> topicReadOnlyUseCase)
        {
            this.topicReadOnlyUseCase = topicReadOnlyUseCase;
        }

        public Domain.Entities.Topic GetById(Guid id)
        {
            return topicReadOnlyUseCase.GetById(id);
        }
    }
}
