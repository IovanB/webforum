using System;
using Domain.Validators;

namespace Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Category(Guid id,string name)
        {
            Id = id;
            Name = name;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Validate(this,new CategoryValidator());
        }
    }
}
