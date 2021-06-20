using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Post
{
    public class UpdatePostUseCase 
    {
        private readonly IWriteOnlyUseCase<Domain.Entities.Post> postWriteOnlyUseCase;

        public int Update(Domain.Entities.Post post)
        {
            return postWriteOnlyUseCase.Update(post);
        }
        public UpdatePostUseCase(IWriteOnlyUseCase<Domain.Entities.Post> postWriteOnlyUseCase)
        {
            this.postWriteOnlyUseCase = postWriteOnlyUseCase;
        }
    }
}
