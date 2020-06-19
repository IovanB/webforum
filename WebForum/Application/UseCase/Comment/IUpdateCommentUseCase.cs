namespace WebForum.Application.UseCase.Comment
{
    public interface IUpdateCommentUseCase
    {
        int Update(Domain.Entities.Comment comment);
    }
}
