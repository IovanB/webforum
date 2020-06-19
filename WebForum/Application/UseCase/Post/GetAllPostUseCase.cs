using System;
using System.Collections.Generic;
using WebForum.Application.Repositories;

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
