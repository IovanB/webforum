namespace Application.UseCases.Category.Delete
{
    public interface ICategoryDeleteUseCase
    {
        void Execute(CategoryDeleteRequest deleteRequest);
    }
}
