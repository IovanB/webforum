using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Comment
{
    public class AddCommentUseCase : IAddCommentUseCase
    {
        private readonly ICommentWriteOnlyUseCase commentWriteOnlyUseCase;

        public AddCommentUseCase(ICommentWriteOnlyUseCase commentWriteOnlyUseCase)
        {
            this.commentWriteOnlyUseCase = commentWriteOnlyUseCase;
        }

        public int Add(Domain.Entities.Comment entity)
        {
           /* string Guid = entity..Entities.Post.Id.ToString();
            if (string.IsNullOrEmpty(Guid))
                throw new NotImplementedException();*/

            return commentWriteOnlyUseCase.Add(entity);
        }
    }
}
