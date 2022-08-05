﻿using Application.UseCases.Topic.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Topic.Add
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

        [HttpPost]
        [Route("CreateTopic")]
        [ProducesResponseType(typeof(TopicResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult CreateTopic([FromBody]TopicInput input)
        {
            topicSaveUseCase.Execute(new TopicSaveRequest(input.Name,input.CategoryId));

            return presenter.ViewModel;
        }
    }
}
