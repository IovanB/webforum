using Application.UseCase.Category.GetAll;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Category.GetAll
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly CategoryPresenter categoryPresenter;
        private readonly ICategoryGetAllUseCase categoryGetAllUseCase;

        public CategoryController(CategoryPresenter categoryPresenter, ICategoryGetAllUseCase categoryGetAllUseCase)
        {
            this.categoryPresenter = categoryPresenter;
            this.categoryGetAllUseCase = categoryGetAllUseCase;
        }
        [HttpPost]
        [Route("GetAllCategories")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetAllCategories()
        {
            categoryGetAllUseCase.Execute();
            return categoryPresenter.ViewModel;
        }
    }
}
