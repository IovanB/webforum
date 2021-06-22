namespace Application.UseCase.Comment.Save
{
    public interface ICommentSaveUseCase
    {
        void Execute(CommentRequest request);
    }
}
