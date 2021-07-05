using Application.Boundaries.Topic;
using Application.UseCases.Topic.Save.Handler;
using System;

namespace Application.UseCases.Topic.Save
{
    public class TopicSaveUseCase : ITopicSaveUseCase
    {
        private readonly IOutputPort output;
        private readonly ValidateSaveRequest validateSaveRequest;

        public TopicSaveUseCase(IOutputPort output, ValidateSaveRequest validateSaveRequest, TopicSaveHandler topicSaveHandler)
        {
            this.output = output;
            this.validateSaveRequest = validateSaveRequest;
            validateSaveRequest.SetSucessor(topicSaveHandler);
        }
        public void Execute(TopicSaveRequest request)
        {
            try
            {
                validateSaveRequest.ProcessRequest(request);
                output.Standard(request.Topic.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Error while processing {ex.Message}");
            }
        }
    }
}
