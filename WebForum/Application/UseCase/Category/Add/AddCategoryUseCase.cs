using WebForum.Application.Repositories;

namespace WebForum.Application.UseCase.Category
{
    public class AddCategoryUseCase
    {
        private readonly IWriteOnlyUseCase<Domain.Entities.Category> categoryWriteOnlyUseCase;

        public int Add(Domain.Entities.Category entity)
        {
            return categoryWriteOnlyUseCase.Add(entity);
        }
        public AddCategoryUseCase(IWriteOnlyUseCase<Domain.Entities.Category> categoryWriteOnlyUseCase)
        {
            this.categoryWriteOnlyUseCase = categoryWriteOnlyUseCase;
        }
    }
}
