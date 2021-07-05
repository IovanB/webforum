using Application.UseCase.Category.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Category.Add
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategorytSaveUseCase categorytSaveUseCase;
        private readonly CategoryPresenter categoryPresenter;

        public CategoryController(ICategorytSaveUseCase categorytSaveUseCase, CategoryPresenter categoryPresenter)
        {
            this.categorytSaveUseCase = categorytSaveUseCase;
            this.categoryPresenter = categoryPresenter;
        }

        [HttpPost]
        [Route("CreateCategory")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult CreateCategory([FromBody] CategoryInput input)
        {
            var request = new CategorytRequest(input.Name);
            categorytSaveUseCase.Execute(request);
            return categoryPresenter.ViewModel;
        }
    }
}
