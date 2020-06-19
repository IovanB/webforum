namespace WebForum.Application.UseCase.Post
{
    public interface IUpdatePostUseCase
    {
        int Update(Domain.Entities.Post post);
    }
}
