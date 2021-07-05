using System;
using Domain.Validators;

namespace Domain.Entities

{
    public class Topic : Entity
    {
        public string Name{ get; private set; }
        public Category Category { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Topic(string name, Category category)
        {
            Id = Guid.NewGuid();
            Name = name;
            Category = category;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Validate(this,new TopicValidator());
        }
        public Topic()
        {

        }
    }
}
