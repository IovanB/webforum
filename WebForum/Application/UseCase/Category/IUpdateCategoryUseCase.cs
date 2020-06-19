namespace WebForum.Application.UseCase.Category
{
    public interface IUpdateCategoryUseCase
    {
        int Update(Domain.Entities.Category category);
    }
}
