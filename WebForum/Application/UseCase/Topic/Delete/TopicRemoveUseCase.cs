using Application.Boundaries.Topic;
using Application.Repositories.Interfaces;
using Application.UseCase.Topic.Delete;
using System;

namespace WebForum.Application.UseCase.Topic
{
    public class TopicRemoveUseCase : ITopicRemoveUseCase
    {
        private readonly IOutputPort output;
        private readonly ITopicWriteOnlyUseCase topicWriteOnlyUseCase;

        public TopicRemoveUseCase(IOutputPort output, ITopicWriteOnlyUseCase topicWriteOnlyUseCase)
        {
            this.output = output;
            this.topicWriteOnlyUseCase = topicWriteOnlyUseCase;
        }

        public void Execute(TopicRemoveRequest request)
        {
            try
            {
                var req = topicWriteOnlyUseCase.Remove(request.Id);
                if (req == 0)
                    throw new ArgumentException("No topic to be removed");
                output.Standard(request.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Erro while processing {ex.Message}");
            }
        }
    }
}
