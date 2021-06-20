namespace Application.UseCase.Post.Add
{
    public interface IAddPostUseCase
    {
        int Add(WebForum.Domain.Entities.Post post);
    }
}
