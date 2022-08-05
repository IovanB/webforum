using Application.UseCases.Comment.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Comment.Add
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
        [Route("CreateComment")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult CreateComment([FromBody]CommentInput input)
        {
            commentSaveUseCase.Execute(new CommentRequest(input.Content, input.PostId, input.UserId));

            return presenter.ViewModel;
        }
    }
}
