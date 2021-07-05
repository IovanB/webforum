using Application.UseCase.Comment.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Comment.Update
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentPresenter presenter;
        private readonly ICommentSaveUseCase commentSaveUseCase;

        public CommentController(CommentPresenter presenter, ICommentSaveUseCase commentSaveUseCase)
        {
            this.presenter = presenter;
            this.commentSaveUseCase = commentSaveUseCase;
        }
        [HttpPost]
        [Route("UpdateComment")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult UpdateComment([FromBody] CommentInput input)
        {
            commentSaveUseCase.Execute(new CommentRequest(input.Id, input.Content, input.PostId, input.UserId));
            return presenter.ViewModel;
        }
    }
}
