using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.Repositories;
using WebForum.Domain.Entities;

namespace WebForum.Application.UseCase.Comment
{
    public class GetByIdCommentUseCase : IGetByIdCommentUseCase
    {
        private readonly ICommentReadOnlyUseCase commentReadOnlyUseCase;

        public Domain.Entities.Comment GetById(Guid id)
        {
            return commentReadOnlyUseCase.GetById(id);
        }
        public GetByIdCommentUseCase(ICommentReadOnlyUseCase commentReadOnlyUseCase)
        {
            this.commentReadOnlyUseCase = commentReadOnlyUseCase;
        }
    }
}
