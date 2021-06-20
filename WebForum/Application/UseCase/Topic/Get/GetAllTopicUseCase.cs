using Application.Repositories.Interfaces;
using Application.UseCase.Topic.Get;
using System.Collections.Generic;

namespace WebForum.Application.UseCase.Topic
{
    public class GetAllTopicUseCase : IGetAllTopicUseCase
    {
        private readonly ITopicReadOnlyUseCase topicReadOnlyUseCase;

        public GetAllTopicUseCase(ITopicReadOnlyUseCase topicReadOnlyUseCase)
        {
            this.topicReadOnlyUseCase = topicReadOnlyUseCase;
        }

        public List<Domain.Entities.Topic> GetAll()
        {
            return topicReadOnlyUseCase.GetAll();
        }
    }
}
