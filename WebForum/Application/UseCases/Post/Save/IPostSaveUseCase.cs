namespace Application.UseCases.Post.Save
{
    public interface IPostSaveUseCase
    {
        void Execute(PostRequest request);
    }
}
