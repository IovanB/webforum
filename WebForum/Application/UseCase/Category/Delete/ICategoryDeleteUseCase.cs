namespace Application.UseCase.Category.Delete
{
    public interface ICategoryDeleteUseCase
    {
        void Execute(CategoryDeleteRequest deleteRequest);
    }
}
