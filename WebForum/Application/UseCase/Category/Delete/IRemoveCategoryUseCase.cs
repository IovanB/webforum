namespace Application.UseCase.Category.Delete
{
    public interface IRemoveCategoryUseCase
    {
        int Remove(WebForum.Domain.Entities.Category category);
    }
}
