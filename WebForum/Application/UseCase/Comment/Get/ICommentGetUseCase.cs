namespace Application.UseCase.Comment.Get
{
    public interface ICommentGetUseCase
    {
        void Execute(CommentGetRequest commentGetRequest);
    }
}
