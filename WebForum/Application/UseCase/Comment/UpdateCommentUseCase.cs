using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.Repositories;
using WebForum.Domain.Entities;

namespace WebForum.Application.UseCase.Comment
{
    public class UpdateCommentUseCase : IUpdateCommentUseCase
    {
        private readonly ICommentWriteOnlyUseCase commentWriteOnlyUseCase;

        public UpdateCommentUseCase(ICommentWriteOnlyUseCase commentWriteOnlyUseCase)
        {
            this.commentWriteOnlyUseCase = commentWriteOnlyUseCase;
        }

        public int Update(Domain.Entities.Comment entity)
        {
            return commentWriteOnlyUseCase.Update(entity);
        }
    }
}
