namespace Application.UseCases.Comment.Get
{
    public interface ICommentGetUseCase
    {
        void Execute(CommentGetRequest commentGetRequest);
    }
}
