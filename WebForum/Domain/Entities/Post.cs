using System;
using Domain.Validators;

namespace Domain.Entities
{
    public class Post : Entity
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public Guid TopicId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Post(string title, string content, Guid topicId, Guid userId)
        {
            Id = Guid.NewGuid();
            Title = title;
            Content = content;
            CreatedAt = DateTime.Now;
            TopicId = topicId;
            UserId = userId;
            UpdatedAt = DateTime.Now;
            Validate(this,new PostValidator());
        }
        public Post()
        {

        }
    }
}
