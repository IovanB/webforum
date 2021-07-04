using Application.Boundaries.Comment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebForumApi.UseCase.Comment
{
    public class CommentPresenter : IOutputPort
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

        public void Standard(Domain.Entities.Comment comment)
        => ViewModel = new OkObjectResult(new CommentResponse(comment.Id, comment.Content, comment.CreatedAt, comment.UpdatedAt));


        public void Standard(IList<Domain.Entities.Comment> comment)
        {
            var commentResponse = new List<CommentResponse>();
            comment.ToList().ForEach(s => commentResponse.Add(new CommentResponse(s.Id, s.Content, s.CreatedAt, s.UpdatedAt)));
            ViewModel = new OkObjectResult(commentResponse);
        }
    }
}
