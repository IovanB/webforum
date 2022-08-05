using System;
using Domain.Validators;

namespace Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get;  set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Category(Guid id,string name, DateTime? createdAt, DateTime? updatedAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Validate(this,new CategoryValidator());
        }
        public Category(Guid id,string name)
        {
            Id = id;
            Name = name;
            CreatedAt = CreatedAt;
            UpdatedAt = DateTime.UtcNow;
            Validate(this,new CategoryValidator());
        }
    }
}
