namespace Application.UseCase.Comment.Save
{
    public class CommentRequest
    {
        public WebForum.Domain.Entities.Comment Comment { get; private set; }

        public CommentRequest(string content, WebForum.Domain.Entities.Post post, WebForum.Domain.Entities.User user)
        {
            Comment = new WebForum.Domain.Entities.Comment(content, post, user);
        }
    }
}
