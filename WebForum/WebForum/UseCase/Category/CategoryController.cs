using Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebForumApi.UseCase.Category
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController(ICommonUseCase<Domain.Entities.Category> useCase) : ControllerBase
    {
        [HttpPost]
        [Route("CreateCategory")]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryInput input)
        {
            try
            {
                await useCase.Insert(new Domain.Entities.Category(0, input.Name));
                return Ok("Category created");
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }

        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await useCase.DeleteEntity(id);
                return Ok("Category deleted");
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }

        [HttpPost]
        [Route("GetCategoryById")]
        [ProducesResponseType(typeof(Domain.Entities.Category), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> GetCategoryById([FromBody] CategoryInput input)
        {
            try
            {
                var category = await useCase.GetById(input.Id);
                if (category == null)
                    return NotFound("Category Not Found");
                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }

        [HttpPost]
        [Route("GetAllCategories")]
        [ProducesResponseType(typeof(List<Domain.Entities.Category>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await useCase.GetAll();
                if (categories.Count == 0)
                    return NotFound("Category Not Found");
                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }

        [HttpPut]
        [Route("UpdateCategory")]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryInput input)
        {
            try
            {
                await useCase.UpdateEntity(new Domain.Entities.Category(input.Id, input.Name));
                return Ok("Category has been updated.");
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }
    }
}
