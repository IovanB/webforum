using Application.Repositories.Interfaces;
using Application.UseCase.Category.Update;

namespace WebForum.Application.UseCase.Category
{
    public class UpdateCategoryUseCase : IUpdateCategoryUseCase
    {
        private readonly ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase;

        public int Update(Domain.Entities.Category entity)
        {
            return categoryWriteOnlyUseCase.Update(entity);
        }
        public UpdateCategoryUseCase(ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase)
        {
            this.categoryWriteOnlyUseCase = categoryWriteOnlyUseCase;
        }
    }
}
