namespace Application.UseCase.Post.Update
{
    public interface IUpdatePostUseCase
    {
        int Update(WebForum.Domain.Entities.Post post);
    }
}
