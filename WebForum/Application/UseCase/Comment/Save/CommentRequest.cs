namespace Application.UseCase.Comment.Save
{
    public class CommentRequest
    {
        public Domain.Entities.Comment Comment { get; private set; }

        public CommentRequest(string content, Domain.Entities.Post post, Domain.Entities.User user)
        {
            Comment = new Domain.Entities.Comment(content, post, user);
        }
    }
}
