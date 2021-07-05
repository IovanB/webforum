namespace Application.UseCases.Comment.Delete
{
    public interface ICommentDeleteUseCase
    {
        void Execute(CommentDeleteRequest deleteRequest);
    }
}
