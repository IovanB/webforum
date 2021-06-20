using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Comment
{
    public class UpdateCommentUseCase 
    {
        private readonly IWriteOnlyUseCase<Domain.Entities.Comment> commentWriteOnlyUseCase;

        public UpdateCommentUseCase(IWriteOnlyUseCase<Domain.Entities.Comment> commentWriteOnlyUseCase)
        {
            this.commentWriteOnlyUseCase = commentWriteOnlyUseCase;
        }

        public int Update(Domain.Entities.Comment entity)
        {
            return commentWriteOnlyUseCase.Update(entity);
        }
    }
}
