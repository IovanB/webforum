using Application.Repositories.Interfaces;
using Application.UseCase.Post.Get;
using System.Collections.Generic;

namespace WebForum.Application.UseCase.Post
{
    public class GetAllPostUseCase : IGetAllPostUseCase
    {
        private readonly IPostReadOnlyUseCase postReadOnlyUseCase;

        public List<Domain.Entities.Post> GetAll()
        {
            return postReadOnlyUseCase.GetAll();
        }
        public GetAllPostUseCase(IPostReadOnlyUseCase postReadOnlyUseCase)
        {
            this.postReadOnlyUseCase = postReadOnlyUseCase;
        }
    }
}
