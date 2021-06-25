using Application.Repositories.Common;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCase.Topic.Save.Handler
{
    public class TopicSaveHandler : Handler<TopicSaveRequest>
    {
        private readonly ITopicWriteOnlyUseCase topicWriteOnlyUseCase;
        private readonly ICategoryReadOnlyUseCase categoryReadOnlyUseCase;

        public TopicSaveHandler(ITopicWriteOnlyUseCase topicWriteOnlyUseCase, ICategoryReadOnlyUseCase categoryReadOnlyUseCase)
        {
            this.topicWriteOnlyUseCase = topicWriteOnlyUseCase;
            this.categoryReadOnlyUseCase = categoryReadOnlyUseCase;
        }
        public override void ProcessRequest(TopicSaveRequest request)
        {
            var category = categoryReadOnlyUseCase.GetById(request.Id);
            var topicRequest = new TopicSaveRequest(request.Name, category);
            
            var req = topicWriteOnlyUseCase.Save(topicRequest.Topic);
            if (req == 0)
                throw new ArgumentException("Cannot add a topic");
            
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
