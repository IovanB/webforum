namespace Application.UseCase.Category.Add
{
    public interface IAddCategoryUseCase
    {
        int Add(WebForum.Domain.Entities.Category category);
    }
}
