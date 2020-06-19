using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.Repositories;
using WebForum.Domain.Entities;

namespace WebForum.Application.UseCase.Topic
{
    public class RemoveTopicUseCase : IRemoveTopicUseCase
    {
        private readonly ITopicWriteOnlyUseCase topicWriteOnlyUseCase;

        public RemoveTopicUseCase(ITopicWriteOnlyUseCase topicWriteOnlyUseCase)
        {
            this.topicWriteOnlyUseCase = topicWriteOnlyUseCase;
        }

        public int Remove(Domain.Entities.Topic entity)
        {
            return topicWriteOnlyUseCase.Remove(entity);
        }
    }
}
