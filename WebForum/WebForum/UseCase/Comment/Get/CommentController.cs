using Application.UseCase.Comment.Get;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Comment.Get
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentPresenter presenter;
        private readonly ICommentGetUseCase commentGetUseCase;

        public CommentController(CommentPresenter presenter, ICommentGetUseCase commentGetUseCase)
        {
            this.presenter = presenter;
            this.commentGetUseCase = commentGetUseCase;
        }

        [HttpPost]
        [Route("GetCommentById")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetCommentById([FromBody] CommentInput input)
        {
            commentGetUseCase.Execute(new CommentGetRequest(input.Id));
            return presenter.ViewModel;
        }
    }
}
