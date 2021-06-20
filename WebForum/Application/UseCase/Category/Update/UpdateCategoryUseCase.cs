using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Category
{
    public class UpdateCategoryUseCase
    {
        private readonly IWriteOnlyUseCase<Domain.Entities.Category> categoryWriteOnlyUseCase;

        public int Update(Domain.Entities.Category entity)
        {
            return categoryWriteOnlyUseCase.Update(entity);
        }
        public UpdateCategoryUseCase(IWriteOnlyUseCase<Domain.Entities.Category> categoryWriteOnlyUseCase)
        {
            this.categoryWriteOnlyUseCase = categoryWriteOnlyUseCase;
        }
    }
}
