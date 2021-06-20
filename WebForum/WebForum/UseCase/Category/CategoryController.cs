using System;
using Microsoft.AspNetCore.Mvc;
using WebForum.Domain.Validators;
using WebForum.Application.UseCase.Category;
using Microsoft.AspNetCore.Authorization;
using Application.UseCase.Category.Add;
using Application.UseCase.Category.Delete;
using Application.UseCase.Category.Update;
using Application.UseCase.Category.Get;

namespace WebForum.WebForumApi.UseCase.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IAddCategoryUseCase addCategoryUseCase;
        private readonly IRemoveCategoryUseCase removeCategoryUseCase;
        private readonly IUpdateCategoryUseCase updateCategoryUseCase;
        private readonly IGetAllCategoryUseCase getAllCategoryUseCase;
        private readonly IGetByIdCategoryUseCase getByIdCategoryUseCase;

        public CategoryController(
            IAddCategoryUseCase addCategoryUseCase,
            IRemoveCategoryUseCase removeCategoryUseCase,
            IUpdateCategoryUseCase updateCategoryUseCase,
            IGetAllCategoryUseCase getAllCategoryUseCase,
            IGetByIdCategoryUseCase getByIdCategoryUseCase)
        {
            this.addCategoryUseCase = addCategoryUseCase;
            this.removeCategoryUseCase = removeCategoryUseCase;
            this.updateCategoryUseCase = updateCategoryUseCase;
            this.getAllCategoryUseCase = getAllCategoryUseCase;
            this.getByIdCategoryUseCase = getByIdCategoryUseCase;
        }
        /// <summary>
        /// Create a category
        /// </summary>
        /// <response code="200">Category has been created. It returns a Guid</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("CreateCategory")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        /*[Authorize("Bearer")]*/
        public IActionResult CreateCategory(string name)
        {
            var category = new Domain.Entities.Category(name);

            var validationResult = new CategoryValidator().Validate(category);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            addCategoryUseCase.Add(category);
            return new OkObjectResult(category);
        }

        /// <summary>
        /// Get Category Id
        /// </summary>
        /// <response code="200">Get Category Id</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("GetCategoryId")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult GetCategoryId(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var category = getByIdCategoryUseCase.GetById(id);
            return new OkObjectResult(category);
        }
        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <response code="200">Get All Categories</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("GetAllCategory")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [AllowAnonymous]
        public IActionResult GetAllCategory()
        {
            var category = getAllCategoryUseCase.GetAll();

            return new OkObjectResult(category);
        }
        /// <summary>
        /// Update a category
        /// </summary>
        /// <response code="200">Category has been created. It returns the whole object</response>
        /// <response code="400">Bad request.</response>
        [HttpPut]
        [Route("UpdateCategory")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult UpdateCategory(Guid id, string name)
        {
            if (getByIdCategoryUseCase.GetById(id) == null)
            {
                return BadRequest();
            }

            var category = new Domain.Entities.Category(id,name);
            var validationResult = new CategoryValidator().Validate(category);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            updateCategoryUseCase.Update(category);
            return new OkObjectResult(category);
        }
        /// <summary>
        /// Delete a category
        /// </summary>
        /// <response code="200">Category has been created. It returns the whole object</response>
        /// <response code="400">Bad request.</response>
        [HttpDelete]
         [Route("RemoveCategory")]
         [ProducesResponseType(typeof(Guid), 200)]
         [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult RemoveCategory(Guid id)
         {
             if (getByIdCategoryUseCase.GetById(id) == null)
             {
                 return BadRequest();
             }

             var category = new Domain.Entities.Category(id);
             removeCategoryUseCase.Remove(category);
             return new OkObjectResult(category);
         }
    }
}