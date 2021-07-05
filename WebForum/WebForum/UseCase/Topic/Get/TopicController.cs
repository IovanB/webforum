using Application.UseCase.Topic.Get;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Topic.Get
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly TopicPresenter presenter;
        private readonly ITopicGetUseCase topicGetUseCase;

        public TopicController(TopicPresenter presenter, ITopicGetUseCase topicGetUseCase)
        {
            this.presenter = presenter;
            this.topicGetUseCase = topicGetUseCase;
        }
        [HttpPost]
        [Route("GetTopicById")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetTopicById([FromBody] TopicInput input)
        {
            topicGetUseCase.Execute(new TopicGetRequest(input.Id));
            
            return presenter.ViewModel;
        }
    }
}
