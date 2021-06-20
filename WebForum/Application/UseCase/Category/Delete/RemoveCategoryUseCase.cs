using Application.Repositories.Interfaces;
using Application.UseCase.Category.Delete;

namespace WebForum.Application.UseCase.Category
{
    public class RemoveCategoryUseCase : IRemoveCategoryUseCase
    {
        private readonly ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase;

        public int Remove(Domain.Entities.Category entity)
        {
            return categoryWriteOnlyUseCase.Remove(entity);
        }
        public RemoveCategoryUseCase(ICategoryWriteOnlyUseCase categoryWriteOnlyUseCase)
        {
            this.categoryWriteOnlyUseCase = categoryWriteOnlyUseCase;
        }
    }
}
