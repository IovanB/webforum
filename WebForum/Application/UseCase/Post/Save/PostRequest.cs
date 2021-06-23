
namespace Application.UseCase.Post.Save
{
    public class PostRequest
    {
        public WebForum.Domain.Entities.Post Post { get; set; }
        public PostRequest(string title, string content, WebForum.Domain.Entities.Topic topic , WebForum.Domain.Entities.User user)
        {
            Post = new WebForum.Domain.Entities.Post(title, content, topic, user);
        }
    }
}
