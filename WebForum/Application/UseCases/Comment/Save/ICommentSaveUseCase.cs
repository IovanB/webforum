namespace Application.UseCases.Comment.Save
{
    public interface ICommentSaveUseCase
    {
        void Execute(CommentRequest request);
    }
}
