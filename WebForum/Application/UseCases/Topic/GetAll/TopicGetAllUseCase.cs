using Application.Boundaries.Topic;
using Application.Repositories.Interfaces;
using System;

namespace Application.UseCases.Topic.GetAll
{
    public class TopicGetAllUseCase : ITopicGetAllUseCase
    {
        private readonly IOutputPort output;
        private readonly ITopicReadOnlyUseCase topicReadOnlyUseCase;

        public TopicGetAllUseCase(IOutputPort output, ITopicReadOnlyUseCase topicReadOnlyUseCase)
        {
            this.output = output;
            this.topicReadOnlyUseCase = topicReadOnlyUseCase;
        }
        public void Execute()
        {
            try
            {
                var req = topicReadOnlyUseCase.GetAll();
                output.Standard(req);
            }
            catch (Exception ex)
            {
                output.Error($"Erro while processing {ex.Message}");
            }
        }
    }
}
