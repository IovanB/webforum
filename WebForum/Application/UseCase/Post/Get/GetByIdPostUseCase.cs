using System;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Post
{
    public class GetByIdPostUseCase
    {
        private readonly IReadOnlyUseCase<Domain.Entities.Post> postReadOnlyUseCase;

        public Domain.Entities.Post GetById(Guid id)
        {
            return postReadOnlyUseCase.GetById(id);
        }
        public GetByIdPostUseCase(IReadOnlyUseCase<Domain.Entities.Post> postReadOnlyUseCase)
        {
            this.postReadOnlyUseCase = postReadOnlyUseCase;
        }
    }
}
