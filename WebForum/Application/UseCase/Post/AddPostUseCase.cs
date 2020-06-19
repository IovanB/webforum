using System;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Post
{
    public class AddPostUseCase : IAddPostUseCase
    {
        private readonly IPostWriteOnlyUseCase postWriteOnlyUseCase;

        public int Add(Domain.Entities.Post post)
        {
            return postWriteOnlyUseCase.Add(post);
        }
        public AddPostUseCase(IPostWriteOnlyUseCase postWriteOnlyUseCase)
        {
            this.postWriteOnlyUseCase = postWriteOnlyUseCase;
        }
    }
}
