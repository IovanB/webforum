using System;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Comment
{
    public class GetByIdCommentUseCase
    {
        private readonly IReadOnlyUseCase<Domain.Entities.Comment> commentReadOnlyUseCase;

        public Domain.Entities.Comment GetById(Guid id)
        {
            return commentReadOnlyUseCase.GetById(id);
        }
        public GetByIdCommentUseCase(IReadOnlyUseCase<Domain.Entities.Comment> commentReadOnlyUseCase)
        {
            this.commentReadOnlyUseCase = commentReadOnlyUseCase;
        }
    }
}
