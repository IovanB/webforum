using Application.UseCase.Post.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Post.Update
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly PostPresenter presenter;
        private readonly IPostSaveUseCase postSaveUseCase;

        public PostController(PostPresenter presenter, IPostSaveUseCase postSaveUseCase)
        {
            this.presenter = presenter;
            this.postSaveUseCase = postSaveUseCase;
        }
        [HttpPut]
        [Route("UpdatePost")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult UpdatePost([FromBody] PostInput input)
        {
            postSaveUseCase.Execute(new PostRequest(input.Title, input.Content));
            return presenter.ViewModel;
        }
    }
}
