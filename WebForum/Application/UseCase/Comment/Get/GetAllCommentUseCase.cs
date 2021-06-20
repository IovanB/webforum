using System.Collections.Generic;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Comment
{
    public class GetAllCommentUseCase
    {
        private readonly IReadOnlyUseCase<Domain.Entities.Comment> commentReadOnlyUseCase;

        public GetAllCommentUseCase(IReadOnlyUseCase<Domain.Entities.Comment> commentReadOnlyUseCase)
        {
            this.commentReadOnlyUseCase = commentReadOnlyUseCase;
        }

        public List<Domain.Entities.Comment> GetAll()
        {
            return commentReadOnlyUseCase.GetAll();
        }
    }
}