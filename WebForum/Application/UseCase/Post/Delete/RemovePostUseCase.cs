using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Post
{
    public class RemovePostUseCase
    {
        private readonly IWriteOnlyUseCase<Domain.Entities.Post> postWriteOnlyUseCase;

        public int Remove(Domain.Entities.Post post)
        {
            return postWriteOnlyUseCase.Remove(post);
        }
        public RemovePostUseCase(IWriteOnlyUseCase<Domain.Entities.Post> postWriteOnlyUseCase)
        {
            this.postWriteOnlyUseCase = postWriteOnlyUseCase;
        }
    }
}
