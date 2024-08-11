using Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebForumApi.UseCase.Post
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ICommonUseCase<Domain.Entities.Post> useCase;

        public PostController(ICommonUseCase<Domain.Entities.Post> useCase)
        {
            this.useCase = useCase;
        }

        [HttpPost]
        [Route("CreatePost")]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> CreatePost([FromBody] PostInput input)
        {
            try
            {
                await useCase.Insert(new Domain.Entities.Post(0, input.Title, input.Content, input.TopicId));
                return Ok("Post created");
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }

        [HttpDelete]
        [Route("DeletePost/{id}")]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await useCase.DeleteEntity(id);
                return Ok("Post deleted");
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }

        [HttpPost]
        [Route("GetPostById/{id}")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> GetPostById(int id)
        {
            try
            {
                var post = await useCase.GetById(id);
                if (post == null)
                    return NotFound("Post Not Found");
                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }

        [HttpPost]
        [Route("GetAllPost")]
        [ProducesResponseType(typeof(List<Domain.Entities.Post>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> GetAllPost()
        {
            try
            {
                var posts = await useCase.GetAll();
                if (posts.Count == 0)
                    return NotFound("Post Not Found");
                return Ok(posts);
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }

        [HttpPut]
        [Route("UpdatePost")]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> UpdatePost([FromBody] PostInput input)
        {
            try
            {
                await useCase.UpdateEntity(new Domain.Entities.Post(input.Id, input.Title, input.Content, input.TopicId));
                return Ok("Post has been updated.");
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }
    }
}
