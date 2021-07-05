using Application.UseCase.Post.Delete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Post.Delete
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostPresenter presenter;
        private readonly IPostRemoveUseCase postRemoveUseCase;

        public PostController(PostPresenter presenter, IPostRemoveUseCase postRemoveUseCase)
        {
            this.presenter = presenter;
            this.postRemoveUseCase = postRemoveUseCase;
        }

        [HttpDelete]
        [Route("DeletePost")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult DeletePost([FromBody] PostInput input)
        {
            postRemoveUseCase.Execute(new PostRemoveRequest(input.Id));
            return presenter.ViewModel;
        }
    }
}
