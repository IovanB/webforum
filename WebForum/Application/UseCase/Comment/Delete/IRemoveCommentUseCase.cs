
namespace Application.UseCase.Comment.Delete
{
    public interface IRemoveCommentUseCase
    {
        int Remove(WebForum.Domain.Entities.Comment comment);
    }
}
