namespace Application.UseCase.Post.Save
{
    public interface IPostSaveUseCase
    {
        void Execute(PostRequest request);
    }
}
