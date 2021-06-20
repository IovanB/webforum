namespace Application.UseCase.Category.Update
{
    public interface IUpdateCategoryUseCase
    {
        int Update(WebForum.Domain.Entities.Category category);
    }
}
