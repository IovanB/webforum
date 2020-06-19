using WebForum.Domain.Entities;
namespace WebForum.Application.Repositories
{
    public interface ICategoryWriteOnlyUseCase
    {
        int Add(Category category);
        int Remove(Category category);
        int Update(Category category);
    }
}
