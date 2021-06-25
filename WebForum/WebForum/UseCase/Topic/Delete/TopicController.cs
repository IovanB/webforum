using Application.UseCase.Topic.Delete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Topic.Delete
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : Controller
    {
        private readonly TopicPresenter presenter;
        private readonly ITopicRemoveUseCase topicRemoveUseCase;

        public TopicController(TopicPresenter presenter, ITopicRemoveUseCase topicRemoveUseCase)
        {
            this.presenter = presenter;
            this.topicRemoveUseCase = topicRemoveUseCase;
        }

        [HttpDelete]
        [Route("DeleteTopic")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult DeleteTopic([FromBody] TopicInput input)
        {
            topicRemoveUseCase.Execute(new TopicRemoveRequest(input.Id));

            return presenter.ViewModel;
        }
    }
}
