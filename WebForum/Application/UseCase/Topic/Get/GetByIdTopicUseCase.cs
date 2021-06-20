using Application.Repositories.Interfaces;
using Application.UseCase.Topic.Get;
using System;

namespace WebForum.Application.UseCase.Topic
{
    public class GetByIdTopicUseCase : IGetByIdTopicUseCase
    {
        private readonly ITopicReadOnlyUseCase topicReadOnlyUseCase;

        public GetByIdTopicUseCase(ITopicReadOnlyUseCase topicReadOnlyUseCase)
        {
            this.topicReadOnlyUseCase = topicReadOnlyUseCase;
        }

        public Domain.Entities.Topic GetById(Guid id)
        {
            return topicReadOnlyUseCase.GetById(id);
        }
    }
}
