namespace WebForum.Application.UseCase.Post
{
    public interface IRemovePostUseCase
    {
        int Remove(Domain.Entities.Post post);
    }
}
