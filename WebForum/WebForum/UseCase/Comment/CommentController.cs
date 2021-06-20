using System;
using Application.UseCase.Comment.Add;
using Application.UseCase.Comment.Delete;
using Application.UseCase.Comment.Get;
using Application.UseCase.Comment.Update;
using Application.UseCase.Post.Get;
using Application.UseCase.User.Get;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebForum.Domain.Validators;

namespace WebForum.WebForumApi.UseCase.Comment
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IAddCommentUseCase addCommentUseCase;
        private readonly IRemoveCommentUseCase removeCommentUseCase;
        private readonly IUpdateCommentUseCase updateCommentUseCase;
        private readonly IGetAllCommentUseCase getAllCommentUseCase;
        private readonly IGetByIdCommentUseCase getByIdCommentUseCase;
        private readonly IGetByIdPostUseCase getByIdPostUseCase;
        private readonly IGetByIdUserUseCase getByIdUserUseCase;

        public CommentController(
            IAddCommentUseCase addCommentUseCase,
            IRemoveCommentUseCase removeCommentUseCase,
            IUpdateCommentUseCase updateCommentUseCase,
            IGetAllCommentUseCase getAllCommentUseCase,
            IGetByIdCommentUseCase getByIdCommentUseCase,
            IGetByIdPostUseCase getByIdPostUseCase,
            IGetByIdUserUseCase getByIdUserUseCase)
        {
            this.addCommentUseCase = addCommentUseCase;
            this.removeCommentUseCase = removeCommentUseCase;
            this.updateCommentUseCase = updateCommentUseCase;
            this.getAllCommentUseCase = getAllCommentUseCase;
            this.getByIdCommentUseCase = getByIdCommentUseCase;
            this.getByIdPostUseCase = getByIdPostUseCase;
            this.getByIdUserUseCase = getByIdUserUseCase;
        }

        /// <summary>
        /// Create a Comment
        /// </summary>
        /// <response code="200">Comment has been created.</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("CreateComment")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult CreateComment(string content, Guid postId, Guid userId)
        {
            var post = getByIdPostUseCase.GetById(postId);
            var user = getByIdUserUseCase.GetById(userId);
            if (post == null && user == null)
            {
                return BadRequest();
            }
            var comment = new Domain.Entities.Comment(content, post, user);

            var validationResult = new CommentValidator().Validate(comment);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            addCommentUseCase.Add(comment);
            return new OkObjectResult(comment);
        }

        /// <summary>
        /// Get Comment Id
        /// </summary>
        /// <response code="200">Get Comment Id</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("GetCommentId")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult GetCommentId(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var topic = getByIdCommentUseCase.GetById(id);
            return new OkObjectResult(topic);
        }
        /// <summary>
        /// Get All Comments
        /// </summary>
        /// <response code="200">Get All Comments</response>
        /// <response code="400">Bad request.</response>
        [HttpPost]
        [Route("GetAllComment")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult GetAllComment()
        {
            var topic = getAllCommentUseCase.GetAll();

            return new OkObjectResult(topic);
        }
        /// <summary>
        /// Update a Comment
        /// </summary>
        /// <response code="200">Comment has been created. It returns the whole object</response>
        /// <response code="400">Bad request.</response>
        [HttpPut]
        [Route("UpdateComment")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult UpdateComment(Guid id, Guid userId, Guid postId, string content)
        {
            var userType = getByIdUserUseCase.GetById(userId);
             
            var post = getByIdPostUseCase.GetById(postId);

            var commentId = getByIdCommentUseCase.GetById(id);

            if (userType.Id == null || userType.UserType != 1)
            {
                return BadRequest("Erro ao reconhecer o usuario");
            }
            if (commentId == null && post == null)
            {
                return BadRequest();
            }
            if (getByIdCommentUseCase.GetById(id) == null && getByIdPostUseCase.GetById(postId) == null && getByIdUserUseCase.GetById(userId) == null)
            {
                return BadRequest();
            }

            var comment = new Domain.Entities.Comment(commentId.Id, content, post, userType, commentId.CreatedAt);

            updateCommentUseCase.Update(comment);
            return new OkObjectResult(comment);
        }
        /// <summary>
        /// Delete a Comment
        /// </summary>
        /// <response code="200">Comment has been created. It returns the whole object</response>
        /// <response code="400">Bad request.</response>
        [HttpDelete]
        [Route("RemoveComment")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Authorize("Bearer")]
        public IActionResult RemoveCategory(Guid id)
        {
            var comment = getByIdCommentUseCase.GetById(id);
            if (comment == null)
            {
                return BadRequest();
            }

            removeCommentUseCase.Remove(comment);
            return new OkObjectResult(comment);
        }


    }
}