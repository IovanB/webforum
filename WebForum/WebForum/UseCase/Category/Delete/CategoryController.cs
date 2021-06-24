﻿using Application.UseCase.Category.Delete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebForumApi.UseCase.Category.Delete
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly CategoryPresenter presenter;
        private readonly ICategoryDeleteUseCase categoryDeleteUseCase;

        public CategoryController(CategoryPresenter presenter, ICategoryDeleteUseCase categoryDeleteUseCase)
        {
            this.presenter = presenter;
            this.categoryDeleteUseCase = categoryDeleteUseCase;
        }
        [HttpDelete]
        [Route("DeleteCategory")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult DeleteCategory([FromBody] CategoryInput input)
        {
            var request = new CategoryDeleteRequest(input.Id);
            categoryDeleteUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
