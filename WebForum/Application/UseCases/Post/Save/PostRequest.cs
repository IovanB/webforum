
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
        public PostRequest(string title, string content, Guid topicId, Guid userId)
        {
            Post = new Domain.Entities.Post(title, content, topicId, userId);
        }
        public PostRequest(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}
