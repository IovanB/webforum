using Application.Repositories.Interfaces;
using Application.UseCase.Post.Update;

namespace WebForum.Application.UseCase.Post
{
    public class UpdatePostUseCase : IUpdatePostUseCase
    {
        private readonly IPostWriteOnlyUseCase postWriteOnlyUseCase;

        public int Update(Domain.Entities.Post post)
        {
            return postWriteOnlyUseCase.Update(post);
        }
        public UpdatePostUseCase(IPostWriteOnlyUseCase postWriteOnlyUseCase)
        {
            this.postWriteOnlyUseCase = postWriteOnlyUseCase;
        }
    }
}
