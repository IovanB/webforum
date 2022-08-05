using System;
using System.Collections.Generic;

namespace WebForumApi.UseCase.Topic
{
    public class TopicResponse
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public TopicResponse(Guid id, Guid categoryId, string name, DateTime? createdAt, DateTime updatedAt)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

    }
}
