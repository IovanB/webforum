using Application.UseCase.Category.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Category.Update
{
    public class CategoryController : ControllerBase
    {
        private readonly CategoryPresenter presenter;
        private readonly ICategorytSaveUseCase categorytSaveUseCase;

        public CategoryController(CategoryPresenter presenter, ICategorytSaveUseCase categorytSaveUseCase)
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
            var request = new CategorytRequest(input.Id, input.Name);
            categorytSaveUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
