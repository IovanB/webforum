using System;
using Domain.Validators;

namespace Domain.Entities
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
        public Category()
        {

        }
    }
}
