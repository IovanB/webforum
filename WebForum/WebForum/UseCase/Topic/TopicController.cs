using System;
using Application.UseCase.Category.Get;
using Application.UseCase.Topic.Add;
using Application.UseCase.Topic.Delete;
using Application.UseCase.Topic.Get;
using Application.UseCase.Topic.Update;
using Application.UseCase.User.Get;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebForum.Domain.Validators;

namespace WebForum.WebForumApi.UseCase.Topic
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly IAddTopicUseCase addTopicUseCase;
        private readonly IGetAllTopicUseCase getAllTopicUseCase;
        private readonly IGetByIdTopicUseCase getByIdTopicUseCase;
        private readonly IUpdateTopicUseCase updateTopicUseCase;
        private readonly IRemoveTopicUseCase removeTopicUseCase;
        private readonly IGetByIdCategoryUseCase getByIdCategoryUseCase;
        private readonly IGetByIdUserUseCase getByIdUserUseCase;

        public TopicController(
            IAddTopicUseCase addTopicUseCase,
            IGetAllTopicUseCase getAllTopicUseCase,
            IGetByIdTopicUseCase getByIdTopicUseCase,
            IUpdateTopicUseCase updateTopicUseCase,
            IRemoveTopicUseCase removeTopicUseCase,
            IGetByIdCategoryUseCase getByIdCategoryUseCase,
            IGetByIdUserUseCase getByIdUserUseCase
            )
        {
            this.addTopicUseCase = addTopicUseCase;
            this.getAllTopicUseCase = getAllTopicUseCase;
            this.getByIdTopicUseCase = getByIdTopicUseCase;
            this.updateTopicUseCase = updateTopicUseCase;
            this.removeTopicUseCase = removeTopicUseCase;
            this.getByIdCategoryUseCase = getByIdCategoryUseCase;
            this.getByIdUserUseCase = getByIdUserUseCase;
        }
        /// <summary>
        /// Create a Topic
        /// </summary>
        /// <response code="200">Category has been created. It returns a Guid</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("CreateTopic")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        /*[Authorize("Bearer")]*/
        [AllowAnonymous]
        public IActionResult CreateTopic(string name, Guid categoryId)
        {
            var category = getByIdCategoryUseCase.GetById(categoryId);

            if (category == null)
                return BadRequest("Category PK not found");

            var topic = new Domain.Entities.Topic(name, category);

            var validationResult = new TopicValidator().Validate(topic);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            addTopicUseCase.Add(topic);
            return new OkObjectResult(topic);
        }

        /// <summary>
        /// Get Topic Id
        /// </summary>
        /// <response code="200">Get Topic Id</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("GetTopicId")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult GetTopicId(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var topic = getByIdTopicUseCase.GetById(id);
            return new OkObjectResult(topic);
        }
        /// <summary>
        /// Get All Topics
        /// </summary>
        /// <response code="200">Get All Topics</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("GetAllTopic")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        /*[Authorize("Bearer")]*/
        [AllowAnonymous]
        public IActionResult GetAllTopic()
        {
            var topic = getAllTopicUseCase.GetAll();
            if (topic == null)
                return BadRequest("No list to be displayed");

            return new OkObjectResult(topic);
        }
        /// <summary>
        /// Update a category
        /// </summary>
        /// <response code="200">Category has been created. It returns the whole object</response>
        /// <response code="400">Bad request.</response>
        [HttpPut]
        [Route("UpdateTopic")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult UpdateTopic(Guid userTypeId, Guid categoryId , Guid id, string name)
        {
            var userType = getByIdUserUseCase.GetById(userTypeId);
            var category = getByIdCategoryUseCase.GetById(categoryId);
            var topicId = getByIdTopicUseCase.GetById(id);
            if (userType.Id == null || userType.UserType != 1)
            {
                return BadRequest("Erro ao reconhecer o usuario");
            }
            if (category == null && topicId == null)
            {
                return BadRequest();
            }

            var topic = new Domain.Entities.Topic(topicId.Id, name, topicId.CreatedAt);

            updateTopicUseCase.Update(topic);
            return new OkObjectResult(topic);
        }
        /// <summary>
        /// Delete a Topic
        /// </summary>
        /// <response code="200">Category has been created. It returns the whole object</response>
        /// <response code="400">Bad request.</response>
        [HttpDelete]
        [Route("RemoveTopic")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult RemoveCategory(Guid id)
        {
            var topic = getByIdTopicUseCase.GetById(id);
            if (topic == null)
            {
                return BadRequest();
            }

            removeTopicUseCase.Remove(topic);
            return new OkObjectResult(topic);
        }
    }
}