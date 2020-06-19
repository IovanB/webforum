using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Post
{
    public class RemovePostUseCase : IRemovePostUseCase
    {
        private readonly IPostWriteOnlyUseCase postWriteOnlyUseCase;

        public int Remove(Domain.Entities.Post post)
        {
            return postWriteOnlyUseCase.Remove(post);
        }
        public RemovePostUseCase(IPostWriteOnlyUseCase postWriteOnlyUseCase)
        {
            this.postWriteOnlyUseCase = postWriteOnlyUseCase;
        }
    }
}
