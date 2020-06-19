using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebForum.Domain.Entities
{
    public class Comment
    {
        [Key]
        public Guid Id { get; private set; }
        public User Author { get; private set; }
        public string Content { get; private set; }
        
        public Post Post { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedAt { get; private set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UpdatedAt { get; private set; }


        public Comment( string content, Post postId, User user)
        {
            Id = Guid.NewGuid();
            Content = content;
            Post = postId;
            Author = user;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public Comment(Guid id, string content, Post post, User user, DateTime createdAt)
        {
            Id = Guid.NewGuid();
            Content = content;
            Post = post;
            Author = user;
            CreatedAt = createdAt;
            UpdatedAt = DateTime.Now;
        }
        
        public Comment()
        {

        }
    }
}
