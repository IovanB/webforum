using Application.UseCases.Post.Get;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Post.Get
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostPresenter presenter;
        private readonly IPostGetUseCase postGetUseCase;

        public PostController(PostPresenter presenter, IPostGetUseCase postGetUseCase )
        {
            this.presenter = presenter;
            this.postGetUseCase = postGetUseCase;
        }

        [HttpPost]
        [Route("GetPostById")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetPostById([FromBody]PostInput input)
        {
            postGetUseCase.Execute(new PostGetRequest(input.Id));

            return presenter.ViewModel;
        }
    }
}
