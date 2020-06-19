using System;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Post
{
    public class GetByIdPostUseCase : IGetByIdPostUseCase
    {
        private readonly IPostReadOnlyUseCase postReadOnlyUseCase;

        public Domain.Entities.Post GetById(Guid id)
        {
            return postReadOnlyUseCase.GetById(id);
        }
        public GetByIdPostUseCase(IPostReadOnlyUseCase postReadOnlyUseCase)
        {
            this.postReadOnlyUseCase = postReadOnlyUseCase;
        }
    }
}
