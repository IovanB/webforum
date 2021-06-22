namespace Application.UseCase.Comment.Delete
{
    public interface ICommentDeleteUseCase
    {
        void Execute(CommentDeleteRequest deleteRequest);
    }
}
