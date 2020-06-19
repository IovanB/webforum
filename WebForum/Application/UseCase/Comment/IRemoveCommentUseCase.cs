namespace WebForum.Application.UseCase.Comment
{
    public interface IRemoveCommentUseCase
    {
        int Remove(Domain.Entities.Comment comment);
    }
}
