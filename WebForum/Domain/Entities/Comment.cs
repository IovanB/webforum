using System;

namespace WebForum.Domain.Entities
{
    public class Comment : Entity
    {
        public User Author { get; private set; }
        public string Content { get; private set; }
        
        public Post Post { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime CreatedAt { get; private set; }

        public Comment( string content, Post postId, User user)
        {
            Id = Guid.NewGuid();
            Content = content;
            Post = postId;
            Author = user;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
