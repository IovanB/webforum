using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.Repositories;
using WebForum.Domain.Entities;

namespace WebForum.Application.UseCase.Comment
{
    public class GetAllCommentUseCase : IGetAllCommentUseCase
    {
        private readonly ICommentReadOnlyUseCase commentReadOnlyUseCase;

        public GetAllCommentUseCase(ICommentReadOnlyUseCase commentReadOnlyUseCase)
        {
            this.commentReadOnlyUseCase = commentReadOnlyUseCase;
        }

        public List<Domain.Entities.Comment> GetAll()
        {
            return commentReadOnlyUseCase.GetAll();
        }
    }
}