using Application.UseCases.Category.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Category.Update
{
    public class CategoryController : ControllerBase
    {
        private readonly CategoryPresenter presenter;
        private readonly ICategorySaveUseCase categorytSaveUseCase;

        public CategoryController(CategoryPresenter presenter, ICategorySaveUseCase categorytSaveUseCase)
        {
            this.presenter = presenter;
            this.categorytSaveUseCase = categorytSaveUseCase;
        }

        [HttpPut]
        [Route("UpdateCategory")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult UpdateCategory([FromBody] CategoryInput input)
        {
            var request = new CategorySaveRequest(input.Id, input.Name);
            categorytSaveUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
