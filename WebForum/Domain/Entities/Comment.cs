using System;
using WebForum.Domain.Validators;

namespace WebForum.Domain.Entities
{
    public class Comment : Entity
    {
        public User Author { get; private set; }
        public string Content { get; private set; }
        
        public Post Post { get; set; }
        public Comment( string content, Post postId, User user)
        {
            Id = Guid.NewGuid();
            Content = content;
            Post = postId;
            Author = user;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Validate(this, new CommentValidator());
        }
    }
}
