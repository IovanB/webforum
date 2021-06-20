using System.Collections.Generic;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Post
{
    public class GetAllPostUseCase 
    {
        private readonly IReadOnlyUseCase<Domain.Entities.Post> postReadOnlyUseCase;

        public List<Domain.Entities.Post> GetAll()
        {
            return postReadOnlyUseCase.GetAll();
        }
        public GetAllPostUseCase(IReadOnlyUseCase<Domain.Entities.Post> postReadOnlyUseCase)
        {
            this.postReadOnlyUseCase = postReadOnlyUseCase;
        }
    }
}
