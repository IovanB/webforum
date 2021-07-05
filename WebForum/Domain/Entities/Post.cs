using System;
using Domain.Validators;

namespace Domain.Entities
{
    public class Post : Entity
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public Topic Topic { get; private set; }
        public User Author { get; private set; }
        public DateTime CreatedAt { get; private set; }
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
            Validate(this,new PostValidator());
        }
        public Post()
        {

        }
    }
}
