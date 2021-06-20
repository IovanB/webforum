namespace Application.UseCase.Comment.Update
{
    public interface IUpdateCommentUseCase
    {
        int Update(WebForum.Domain.Entities.Comment comment);
    }
}
