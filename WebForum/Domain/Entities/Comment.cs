using System;
using Domain.Validators;

namespace Domain.Entities
{
    public class Comment : Entity
    {
        public string Content { get; private set; }
        public Guid UserId { get; private set; }
        public Guid PostId { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Comment(string content, Guid userId, Guid postId)
        {
            Id = Guid.NewGuid();
            Content = content;
            UserId = userId;
            PostId = postId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Validate(this, new CommentValidator());
        }
        public Comment()
        {

        }
    }
}
