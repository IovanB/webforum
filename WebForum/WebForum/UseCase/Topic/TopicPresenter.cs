using Application.Boundaries.Topic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebForumApi.UseCase.Topic
{
    public class TopicPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }
        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);

        public void Standard(Guid id)
          => ViewModel = new OkObjectResult(id);

        public void Standard(Domain.Entities.Topic topic)
        => ViewModel = new OkObjectResult(new TopicResponse(topic.Id, topic.CategoryId, topic.Name, topic.CreatedAt, topic.UpdatedAt));

        public void Standard(IList<Domain.Entities.Topic> topic)
        {
            var topicResponse = new List<TopicResponse>();
            topic.ToList().ForEach(s => topicResponse.Add(new TopicResponse(s.Id, s.CategoryId, s.Name, s.CreatedAt, s.UpdatedAt)));
            ViewModel = new OkObjectResult(topicResponse);
        }
    }
}
