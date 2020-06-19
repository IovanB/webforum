using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.Repositories;
using WebForum.Domain.Entities;

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
