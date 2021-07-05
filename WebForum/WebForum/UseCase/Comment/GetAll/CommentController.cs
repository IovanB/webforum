using Application.UseCase.Comment.GetAll;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Comment.GetAll
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentPresenter presenter;
        private readonly ICommentGetAllUseCase commentGetAllUseCase;

        public CommentController(CommentPresenter presenter, ICommentGetAllUseCase commentGetAllUseCase)
        {
            this.presenter = presenter;
            this.commentGetAllUseCase = commentGetAllUseCase;
        }

        [HttpPost]
        [Route("GetAllComment")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetAllComment()
        {
            commentGetAllUseCase.Execute();

            return presenter.ViewModel;
        }
    }
}
