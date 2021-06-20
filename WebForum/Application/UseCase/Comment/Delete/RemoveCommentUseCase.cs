﻿using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Comment
{
    public class RemoveCommentUseCase
    {
        private readonly IWriteOnlyUseCase<Domain.Entities.Comment> commentWriteOnlyUseCase;

        public RemoveCommentUseCase(IWriteOnlyUseCase<Domain.Entities.Comment> commentWriteOnlyUseCase)
        {
            this.commentWriteOnlyUseCase = commentWriteOnlyUseCase;
        }

        public int Remove(Domain.Entities.Comment entity)
        {
            return commentWriteOnlyUseCase.Remove(entity);
        }
    }
}
