using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebForum.Application.UseCase.Post;
using WebForum.Application.UseCase.Topic;
using WebForum.Application.UseCase.User;
using WebForum.Domain.Validators;

namespace WebForum.WebForumApi.UseCase.Post
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IAddPostUseCase addPostUseCase;
        private readonly IRemovePostUseCase removePostUseCase;
        private readonly IUpdatePostUseCase updatePostUseCase;
        private readonly IGetAllPostUseCase getAllPostUseCase;
        private readonly IGetByIdPostUseCase getByIdPostUseCase;
        private readonly IGetByIdTopicUseCase getByIdTopicUseCase;
        private readonly IGetByIdUserUseCase getByIdUserUseCase;

        public PostController(
            IAddPostUseCase addPostUseCase,
            IRemovePostUseCase removePostUseCase,
            IUpdatePostUseCase updatePostUseCase,
            IGetAllPostUseCase getAllPostUseCase,
            IGetByIdPostUseCase getByIdPostUseCase,
            IGetByIdTopicUseCase getByIdTopicUseCase,
            IGetByIdUserUseCase getByIdUserUseCase)
        {
            this.addPostUseCase = addPostUseCase;
            this.removePostUseCase = removePostUseCase;
            this.updatePostUseCase = updatePostUseCase;
            this.getAllPostUseCase = getAllPostUseCase;
            this.getByIdPostUseCase = getByIdPostUseCase;
            this.getByIdTopicUseCase = getByIdTopicUseCase;
            this.getByIdUserUseCase = getByIdUserUseCase;
        }

        /// <summary>
        /// Create a Post
        /// </summary>
        /// <response code="200">Post has been created. It returns a Guid</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("CreatePost")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult CreatePost(string title, string content, Guid topicId, Guid userId)
        {
            var topic = getByIdTopicUseCase.GetById(topicId);
            if (topic == null && getByIdUserUseCase.GetById(userId) == null)
            {
                return BadRequest();
            }
            var user = getByIdUserUseCase.GetById(userId);
            string author = user.Name;

            var post = new Domain.Entities.Post(title, content, topic, user);

            var validationResult = new PostValidator().Validate(post);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            addPostUseCase.Add(post);
            return new OkObjectResult(post);
        }

        /// <summary>
        /// Get Post Id
        /// </summary>
        /// <response code="200">Get Post Id</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("GetPostId")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult GetPostId(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var topic = getByIdTopicUseCase.GetById(id);
            return new OkObjectResult(topic);
        }
        /// <summary>
        /// Get All Posts
        /// </summary>
        /// <response code="200">Get All Posts</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("GetAllPost")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult GetAllPost()
        {
            var post = getAllPostUseCase.GetAll();

            return new OkObjectResult(post);
        }
        /// <summary>
        /// Update a Post
        /// </summary>
        /// <response code="200">Post has been created. It returns the whole object</response>
        /// <response code="400">Bad request.</response>
        [HttpPut]
        [Route("UpdatePost")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult UpdatePost(Guid id, Guid topicId, Guid userId, string content)
        {
            var userType = getByIdUserUseCase.GetById(userId);
            var topic = getByIdTopicUseCase.GetById(topicId);
            var postId = getByIdPostUseCase.GetById(id);
           
            if (postId == null && topic == null && userType == null || userType.UserType != 1)
            {
                return BadRequest("Something went wrong");
            }

            var post = new Domain.Entities.Post(postId.Id, postId.Title, content, topic, postId.CreatedAt);

            updatePostUseCase.Update(post);
            return new OkObjectResult(post);
        }
        /// <summary>
        /// Delete a Post
        /// </summary>
        /// <response code="200">Post has been created. It returns the whole object</response>
        /// <response code="400">Bad request.</response>
        [HttpDelete]
        [Route("RemovePost")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult RemovePost(Guid id)
        {
            if (getByIdPostUseCase.GetById(id) == null)
            {
                return BadRequest();
            }

            var post = getByIdPostUseCase.GetById(id);
            removePostUseCase.Remove(post);
            return new OkObjectResult(post);
        }
    }
}