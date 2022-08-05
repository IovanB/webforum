using System;

namespace Infrastructure.Data.Entity.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Comment Comment{ get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
