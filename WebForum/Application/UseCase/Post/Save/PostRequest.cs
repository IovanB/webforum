
namespace Application.UseCase.Post.Save
{
    public class PostRequest
    {
        public Domain.Entities.Post Post { get; set; }
        public PostRequest(string title, string content, Domain.Entities.Topic topic , Domain.Entities.User user)
        {
            Post = new Domain.Entities.Post(title, content, topic, user);
        }
    }
}
