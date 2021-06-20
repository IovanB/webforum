using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Post
{
    public class AddPostUseCase
    {
        private readonly IWriteOnlyUseCase<Domain.Entities.Post> postWriteOnlyUseCase;

        public int Add(Domain.Entities.Post post)
        {
            return postWriteOnlyUseCase.Add(post);
        }
        public AddPostUseCase(IWriteOnlyUseCase<Domain.Entities.Post> postWriteOnlyUseCase)
        {
            this.postWriteOnlyUseCase = postWriteOnlyUseCase;
        }
    }
}
