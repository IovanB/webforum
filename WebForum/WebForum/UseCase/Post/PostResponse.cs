using System;

namespace WebForumApi.UseCase.Post
{
    public class PostResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; } 
        public Guid TopicId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public PostResponse(Guid id, Guid userId, Guid topicId, string title, string content, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            UserId = userId;
            TopicId = topicId;
            Title = title;
            Content = content;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
