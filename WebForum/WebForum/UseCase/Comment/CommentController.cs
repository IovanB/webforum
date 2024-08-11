﻿using Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebForumApi.UseCase.Comment
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommonUseCase<Domain.Entities.Comment> useCase;

        public CommentController(ICommonUseCase<Domain.Entities.Comment> useCase)
        {
            this.useCase = useCase;
        }

        [HttpPost]
        [Route("CreateComment")]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> CreateComment([FromBody] CommentInput input)
        {
            try
            {
                await useCase.Insert(new Domain.Entities.Comment(0, input.Content, input.PostId));
                return Ok("Comment created");
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }

        [HttpDelete]
        [Route("DeleteComment/{id}")]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
            {
                await useCase.DeleteEntity(id);
                return Ok("Comment deleted");
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }

        [HttpPost]
        [Route("GetCommentById/{id}")]
        [ProducesResponseType(typeof(Domain.Entities.Comment), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> GetCommentById(int id)
        {
            try
            {
                var comment = await useCase.GetById(id);
                if (comment == null)
                    return NotFound("Comment Not Found");
                return Ok(comment);
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }

        [HttpPost]
        [Route("GetAllComment")]
        [ProducesResponseType(typeof(List<Domain.Entities.Comment>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> GetAllComment()
        {
            try
            {
                var comments = await useCase.GetAll();
                if (comments.Count == 0)
                    return NotFound("Comment Not Found");
                return Ok(comments);
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }

        [HttpPost]
        [Route("UpdateComment")]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<IActionResult> UpdateComment([FromBody] CommentInput input)
        {
            try
            {
                await useCase.UpdateEntity(new Domain.Entities.Comment(input.Id, input.Content, input.PostId));
                return Ok("Comment has been updated.");
            }
            catch (Exception)
            {
                return BadRequest("An error has occured");
            }
        }
    }
}
