using Application.Repositories.Common;
using Application.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCase.Topic.Save.Handler
{
    public class TopicSaveHandler : Handler<TopicSaveRequest>
    {
        private readonly ITopicWriteOnlyUseCase topicWriteOnlyUseCase;

        public TopicSaveHandler(ITopicWriteOnlyUseCase topicWriteOnlyUseCase)
        {
            this.topicWriteOnlyUseCase = topicWriteOnlyUseCase;
        }
        public override void ProcessRequest(TopicSaveRequest request)
        {
            var req = topicWriteOnlyUseCase.Save(request.Topic);
            if (req == 0)
                throw new ArgumentException("Cannot add a topic");
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
