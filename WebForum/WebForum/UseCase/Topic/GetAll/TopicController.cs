using Application.UseCase.Topic.GetAll;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Topic.GetAll
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : Controller
    {
        private readonly TopicPresenter presenter;
        private readonly ITopicGetAllUseCase topicGetAllUseCase;

        public TopicController(TopicPresenter presenter, ITopicGetAllUseCase topicGetAllUseCase)
        {
            this.presenter = presenter;
            this.topicGetAllUseCase = topicGetAllUseCase;
        }

        [HttpPost]
        [Route("GetAllTopic")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetAllTopic()
        {
            topicGetAllUseCase.Execute();
            
            return presenter.ViewModel;
        }
    }
}
