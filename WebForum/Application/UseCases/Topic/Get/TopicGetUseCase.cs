using Application.Boundaries.Topic;
using Application.Repositories.Interfaces;
using Application.UseCases.Topic.Get;
using System;

namespace WebForum.Application.UseCases.Topic
{
    public class TopicGetUseCase : ITopicGetUseCase
    {
        private readonly IOutputPort output;
        private readonly ITopicReadOnlyUseCase topicReadOnlyUseCase;

        public TopicGetUseCase(IOutputPort output, ITopicReadOnlyUseCase topicReadOnlyUseCase)
        {
            this.output = output;
            this.topicReadOnlyUseCase = topicReadOnlyUseCase;
        }

        public void Execute(TopicGetRequest request)
        {
            try
            {
                var req = topicReadOnlyUseCase.GetById(request.Id);
                if (req == null)
                    throw new ArgumentException("There is no topic");

                output.Standard(req);
            }
            catch (Exception ex)
            {
                output.Error($"Error while processing Topic {ex.Message}");
            }
        }
        
    }
}
