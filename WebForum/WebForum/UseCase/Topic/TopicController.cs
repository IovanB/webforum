using Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebForumApi.UseCase.Topic
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ICommonUseCase<Domain.Entities.Topic> useCase;

        public TopicController(ICommonUseCase<Domain.Entities.Topic> useCase)
        {
            this.useCase = useCase;
        }

        [HttpPost]
        [Route("CreateTopic")]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> CreateTopic([FromBody] TopicInput input)
        {
            try
            {
                await useCase.Insert(new Domain.Entities.Topic(0, input.Name, input.CategoryId));
                return Ok("Topic created");
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }

        [HttpDelete]
        [Route("DeleteTopic/{id}")]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            try
            {
                await useCase.DeleteEntity(id);
                return Ok("Topic deleted");
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }
        [HttpPost]
        [Route("GetTopicById")]
        [ProducesResponseType(typeof(Domain.Entities.Topic), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> GetTopicById([FromBody] TopicInput input)
        {
            try
            {
                var topic = await useCase.GetById(input.Id);
                if (topic == null)
                    return NotFound("Topic Not Found");
                return Ok(topic);
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }

        [HttpPost]
        [Route("GetAllTopic")]
        [ProducesResponseType(typeof(List<Domain.Entities.Topic>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> GetAllTopic()
        {
            try
            {
                var topics = await useCase.GetAll();
                if (topics.Count == 0)
                    return NotFound("Topic Not Found");
                return Ok(topics);
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }

        [HttpPut]
        [Route("UpdateTopic")]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> UpdateTopic([FromBody] TopicInput input)
        {
            try
            {
                await useCase.UpdateEntity(new Domain.Entities.Topic(input.Id, input.Name, input.CategoryId));
                return Ok("Topic has been updated.");
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }
    }
}
