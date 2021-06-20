
namespace Application.UseCase.Comment.Add
{
    public interface IAddCommentUseCase
    {
        int Add(WebForum.Domain.Entities.Comment comment);
    }
}
