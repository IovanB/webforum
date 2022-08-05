using Application.UseCases.Category.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Category.Add
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryPresenter categoryPresenter;
        private readonly ICategorySaveUseCase categorySaveUseCase;

        public CategoryController(CategoryPresenter categoryPresenter, ICategorySaveUseCase categorySaveUseCase)
        {
            this.categoryPresenter = categoryPresenter;
            this.categorySaveUseCase = categorySaveUseCase;
        }

        [HttpPost]
        [Route("CreateCategory")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult CreateCategory([FromBody] CategoryInput input)
        {
            var request = new CategorySaveRequest(input.Name);
            categorySaveUseCase.Execute(request);
            return categoryPresenter.ViewModel;
        }
    }
}
