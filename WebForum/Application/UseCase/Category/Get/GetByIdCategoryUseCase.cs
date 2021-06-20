using System;
using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Category
{
    public class GetByIdCategoryUseCase
    { 
        private readonly IReadOnlyUseCase<Domain.Entities.Category> categoryReadOnlyUseCase;

        public Domain.Entities.Category GetById(Guid id)
        {
            return categoryReadOnlyUseCase.GetById(id);
        }
        public GetByIdCategoryUseCase(IReadOnlyUseCase<Domain.Entities.Category> categoryReadOnlyUseCase)
        {
            this.categoryReadOnlyUseCase = categoryReadOnlyUseCase;
        }
    }
}
