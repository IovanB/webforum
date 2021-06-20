using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Category
{
    public class RemoveCategoryUseCase 
    {
        private readonly IWriteOnlyUseCase<Domain.Entities.Category> categoryWriteOnlyUseCase;

        public int Remove(Domain.Entities.Category entity)
        {
            return categoryWriteOnlyUseCase.Remove(entity);
        }
        public RemoveCategoryUseCase(IWriteOnlyUseCase<Domain.Entities.Category> categoryWriteOnlyUseCase)
        {
            this.categoryWriteOnlyUseCase = categoryWriteOnlyUseCase;
        }
    }
}
