using System.Collections.Generic;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Category
{
    public class GetAllCategoryUseCase
    {
        private readonly IReadOnlyUseCase<Domain.Entities.Category> categoryReadOnlyUseCase;

        public List<Domain.Entities.Category> GetAll()
        {
            return categoryReadOnlyUseCase.GetAll();
        }
        public GetAllCategoryUseCase(IReadOnlyUseCase<Domain.Entities.Category> categoryReadOnlyUseCase)
        {
            this.categoryReadOnlyUseCase = categoryReadOnlyUseCase;
        }
    }
}
