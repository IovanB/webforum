using System;
using WebForum.Domain.Validators;

namespace WebForum.Domain.Entities

{
    public class Topic : Entity
    {
        public string Name{ get; private set; }
        public Category Category { get; set; }

        public Topic(string name, Category category)
        {
            Id = Guid.NewGuid();
            Name = name;
            Category = category;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            new TopicValidator();
        }
    }
}
