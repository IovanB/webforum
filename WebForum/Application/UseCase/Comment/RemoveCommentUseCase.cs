using System;
using System.Collections.Generic;
using System.Text;
using WebForum.Application.Repositories;
using WebForum.Domain.Entities;

namespace WebForum.Application.UseCase.Comment
{
    public class RemoveCommentUseCase : IRemoveCommentUseCase
    {
        private readonly ICommentWriteOnlyUseCase commentWriteOnlyUseCase;

        public RemoveCommentUseCase(ICommentWriteOnlyUseCase commentWriteOnlyUseCase)
        {
            this.commentWriteOnlyUseCase = commentWriteOnlyUseCase;
        }

        public int Remove(Domain.Entities.Comment entity)
        {
            return commentWriteOnlyUseCase.Remove(entity);
        }
    }
}
