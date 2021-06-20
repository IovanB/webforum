namespace Application.UseCase.Post.Delete
{
    public interface IRemovePostUseCase
    {
        int Remove(WebForum.Domain.Entities.Post post);
    }
}
