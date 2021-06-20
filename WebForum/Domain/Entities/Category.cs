using System;
using WebForum.Domain.Validators;

namespace WebForum.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            new CategoryValidator();
        }
    }
}
