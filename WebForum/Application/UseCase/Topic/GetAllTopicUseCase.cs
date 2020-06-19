using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.Repositories;
using WebForum.Domain.Entities;

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
