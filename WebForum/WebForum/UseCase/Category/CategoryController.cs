using Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebForumApi.UseCase.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICommonUseCase<Domain.Entities.Category> useCase) : ControllerBase
    {
        [HttpPost]
        [Route("CreateCategory")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryInput input)
        {
            try
            {
                await useCase.Insert(new Domain.Entities.Category(0, input.Name));
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }

        }

        [HttpDelete]
        [Route("DeleteCategory")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> DeleteCategory([FromBody] CategoryInput input)
        {
            try
            {
                await useCase.DeleteEntity(input.Id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }

        [HttpPost]
        [Route("GetCategoryById")]
        [ProducesResponseType(typeof(Guid), 200)]
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
        [ProducesResponseType(typeof(Guid), 200)]
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
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryInput input)
        {
            try
            {
                await useCase.UpdateEntity(new Domain.Entities.Category(input.Id, input.Name));
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }
    }
}
