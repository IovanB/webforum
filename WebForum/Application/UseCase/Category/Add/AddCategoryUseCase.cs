using Application.Repositories.Interfaces;
using Application.UseCase.Category.Add;

namespace WebForum.Application.UseCase.Category
{
    public class AddCategoryUseCase : IAddCategoryUseCase
    {
        private readonly ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase;

        public int Add(Domain.Entities.Category entity)
        {
            return categoryWriteOnlyUseCase.Add(entity);
        }
        public AddCategoryUseCase(ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase)
        {
            this.categoryWriteOnlyUseCase = categoryWriteOnlyUseCase;
        }
    }
}
