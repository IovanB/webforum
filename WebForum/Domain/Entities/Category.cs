using System;
using WebForum.Domain.Validators;

namespace WebForum.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        public Category(Guid id,string name)
        {
            Id = id;
            Name = name;
            Validate(this,new CategoryValidator());
        }
    }
}
