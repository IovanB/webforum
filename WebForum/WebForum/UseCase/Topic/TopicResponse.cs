using System;

namespace WebForumApi.UseCase.Topic
{
    public class TopicResponse
    {
        public Guid id { get; set; }
        public Domain.Entities.Category Category { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public TopicResponse(Guid id, Domain.Entities.Category category, string name, DateTime createdAt, DateTime updatedAt)
        {
            this.id = id;
            Category = category;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

    }
}
