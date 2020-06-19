using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebForum.Domain.Entities
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedAt { get; private set; }

        public Topic Topic { get; private set; }
        public User Author { get; private set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UpdatedAt { get; private set; }

        public Post(string title, string content, Topic topicId, User user)
        {
            Id = Guid.NewGuid();
            Title = title;
            Content = content;
            CreatedAt = DateTime.Now;
            Topic = topicId;
            Author = user;
            UpdatedAt = DateTime.Now;
        }
        public Post(Guid id, string title, string content, Topic topicId, DateTime createdAt)
        {
            Id = id;
            Title = title;
            Content = content;
            CreatedAt = createdAt;
            Topic = topicId;
            UpdatedAt = DateTime.Now;
        } 
        public Post()
        {

        }
    }
}
