using Application.Boundaries.Post;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebForumApi.UseCase.Post
{
    public class PostPresenter : IOutputPort
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

        public void Standard(Domain.Entities.Post post)
            => ViewModel = new OkObjectResult(new PostResponse(post.Id, post.Author, post.Topic, post.Title, post.Content, post.CreatedAt, post.UpdatedAt));

        public void Standard(IList<Domain.Entities.Post> post)
        {
            var postResponse = new List<PostResponse>();
            post.ToList().ForEach(s => postResponse.Add(new PostResponse(s.Id, s.Author, s.Topic, s.Title, s.Content, s.CreatedAt, s.UpdatedAt)));
            ViewModel = new OkObjectResult(postResponse);
        }
    }
}
