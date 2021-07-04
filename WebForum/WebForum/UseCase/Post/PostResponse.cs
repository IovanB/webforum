using System;

namespace WebForumApi.UseCase.Post
{
    public class PostResponse
    {
        public Guid Id { get; set; }
        public Domain.Entities.User Author{ get; set; } 
        public Domain.Entities.Topic Topic { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public PostResponse(Guid id, Domain.Entities.User user, Domain.Entities.Topic topic, string title, string content, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Author = user;
            Topic = topic;
            Title = title;
            Content = content;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
