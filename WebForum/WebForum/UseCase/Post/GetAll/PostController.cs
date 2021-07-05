using Application.UseCase.Post.GetAll;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Post.GetAll
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostPresenter presenter;
        private readonly IPostGetAllUseCase postGetAllUseCase;

        public PostController(PostPresenter presenter, IPostGetAllUseCase postGetAllUseCase)
        {
            this.presenter = presenter;
            this.postGetAllUseCase = postGetAllUseCase;
        }

        [HttpPost]
        [Route("GetAllPost")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetAllPost()
        {
            postGetAllUseCase.Execute();

            return presenter.ViewModel;
        }
    }
}
