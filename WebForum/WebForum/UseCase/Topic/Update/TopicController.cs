using Application.UseCases.Topic.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Topic.Update
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly TopicPresenter presenter;
        private readonly ITopicSaveUseCase topicSaveUseCase;

        public TopicController(TopicPresenter presenter, ITopicSaveUseCase topicSaveUseCase)
        {
            this.presenter = presenter;
            this.topicSaveUseCase = topicSaveUseCase;
        }
        [HttpPut]
        [Route("UpdateTopic")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult UpdateTopic([FromBody]TopicInput input)
        {
            topicSaveUseCase.Execute(new TopicSaveRequest(input.Id, input.Name));

            return presenter.ViewModel;
        }
    }
}
