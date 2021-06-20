using Application.Repositories.Interfaces;
using Application.UseCase.Category.Get;
using System.Collections.Generic;

namespace WebForum.Application.UseCase.Category
{
    public class GetAllCategoryUseCase : IGetAllCategoryUseCase
    {
        private readonly ICategoryReadOnlyUseCase categoryReadOnlyUseCase;

        public List<Domain.Entities.Category> GetAll()
        {
            return categoryReadOnlyUseCase.GetAll();
        }
        public GetAllCategoryUseCase(ICategoryReadOnlyUseCase categoryReadOnlyUseCase)
        {
            this.categoryReadOnlyUseCase = categoryReadOnlyUseCase;
        }
    }
}
