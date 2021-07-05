using System;
using Domain.Validators;

namespace Domain.Entities
{
    public class Comment : Entity
    {
        public string Content { get; private set; }
        public User Author { get; private set; }
        public Post Post { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Comment(string content, User user, Post post)
        {
            Id = Guid.NewGuid();
            Content = content;
            Author = user;
            Post = post;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Validate(this, new CommentValidator());
        }
        public Comment()
        {

        }
    }
}
