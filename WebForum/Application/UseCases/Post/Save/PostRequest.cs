
using System;

namespace Application.UseCases.Post.Save
{
    public class PostRequest
    {
        public Domain.Entities.Post Post { get; set; }
        public string Title{ get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid TopicId { get; set; }
        public PostRequest(string title, string content, Domain.Entities.Topic topic , Domain.Entities.User user)
        {
            Post = new Domain.Entities.Post(title, content, topic, user);
        }
        public PostRequest(string title, string content, Guid topic , Guid user)
        {
            Title = title;
            Content = content;
            UserId = user;
            TopicId = topic;
        }
        public PostRequest(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}
