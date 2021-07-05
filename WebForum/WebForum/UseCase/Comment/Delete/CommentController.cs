using Application.UseCases.Comment.Delete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Comment.Delete
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentPresenter presenter;
        private readonly ICommentDeleteUseCase commentDeleteUseCase;

        public CommentController(CommentPresenter presenter, ICommentDeleteUseCase commentDeleteUseCase )
        {
            this.presenter = presenter;
            this.commentDeleteUseCase = commentDeleteUseCase;
        }

        [HttpDelete]
        [Route("DeleteComment")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult DeleteComment([FromBody] CommentInput input)
        {
            commentDeleteUseCase.Execute(new CommentDeleteRequest(input.Id));

            return presenter.ViewModel;
        }
    }
}
