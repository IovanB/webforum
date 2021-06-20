using Application.UseCase.Comment.Add;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Comment
{
    public class AddCommentUseCase: IAddCommentUseCase
    {
        private readonly IWriteOnlyUseCase<Domain.Entities.Comment> commentWriteOnlyUseCase;

        public AddCommentUseCase(IWriteOnlyUseCase<Domain.Entities.Comment> commentWriteOnlyUseCase)
        {
            this.commentWriteOnlyUseCase = commentWriteOnlyUseCase;
        }

        public int Add(Domain.Entities.Comment entity)
        {
            return commentWriteOnlyUseCase.Add(entity);
        }
    }
}
