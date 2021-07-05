using Application.UseCases.Category.Get;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Category.Get
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryPresenter presenter;
        private readonly ICategoryGetUseCase categoryGetUseCase;

        public CategoryController(CategoryPresenter presenter, ICategoryGetUseCase categoryGetUseCase)
        {
            this.presenter = presenter;
            this.categoryGetUseCase = categoryGetUseCase;
        }

        [HttpPost]
        [Route("GetCategoryById")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetCategoryById([FromBody] CategoryInput input)
        {
            var request = new CategoryGetRequest(input.Id);
            categoryGetUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
