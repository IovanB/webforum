using Application.UseCase.Post.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Post.Add
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostPresenter presenter;
        private readonly IPostSaveUseCase postSaveUseCase;

        public PostController(PostPresenter presenter, IPostSaveUseCase postSaveUseCase)
        {
            this.presenter = presenter;
            this.postSaveUseCase = postSaveUseCase;
        }

        [HttpPost]
        [Route("CreatePost")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult CreatePost([FromBody] PostInput input)
        {
            postSaveUseCase.Execute(new PostRequest(input.Title, input.Content, input.TopicId, input.AuthorId));

            return presenter.ViewModel;
        }
    }
}
